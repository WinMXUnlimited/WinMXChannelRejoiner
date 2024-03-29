﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using WinMXWindowApi;
using WinMXChannelRejoiner.Tools;
using System.Diagnostics;
using System.Collections.Specialized;
using System.Runtime.Caching;
using WinMXChannelRejoiner.Properties;
using Microsoft.Win32;

namespace WinMXChannelRejoiner.Manager
{
    public class ChatManager
    {
        Timer Updater;
        Timer MessageSender;
        Timer UptimeManager;
        List<String> ExcludedChannels;
        List<JoinAttempt> Attempts;
        int RejoinDuration;
        int MaximumAttempts;
        bool OpenOnBootup;
        bool SendAutoRejoinMessage;
        string AutoRejoinMessage;
        bool DisabledUntilWinMXRestart = false;
        int WinMXPIDAtDisabledTime;
        bool IsRunning = false;
        public Action<bool, bool> RunningStateChanged;


        public ChatManager()
        {
            ExcludedChannels = new List<string>();
            Attempts = new List<JoinAttempt>();


            LoadSettings();
        }

        void LoadSettings()
        {
            ExcludedChannels.AddRange(Settings.Default.ExcludedChannels.Cast<String>());
            RejoinDuration = Settings.Default.RejoinDuration;
            MaximumAttempts = Settings.Default.MaximumAttempts;
            OpenOnBootup = Settings.Default.OpenOnBootup;
            SendAutoRejoinMessage = Settings.Default.SendAutoRejoinMessage;
            AutoRejoinMessage = Settings.Default.AutoRejoinMessage;
        }

        void SaveSettings()
        {
            var tmp = new StringCollection();
            tmp.AddRange(ExcludedChannels.ToArray());
            Settings.Default.ExcludedChannels = tmp;
            Settings.Default.MaximumAttempts = MaximumAttempts;
            Settings.Default.RejoinDuration = RejoinDuration;
            Settings.Default.OpenOnBootup = OpenOnBootup;
            Settings.Default.SendAutoRejoinMessage = SendAutoRejoinMessage;
            Settings.Default.AutoRejoinMessage = AutoRejoinMessage;
            Settings.Default.Save();
        }

        public void Start(bool fromUptimeManager = false)
        {
            Updater = new Timer(new TimerCallback(ManageChannels), null, 5000, RejoinDuration * 60000);
            MessageSender = new Timer(new TimerCallback(ManageAutoRejoinMessages), null, 30000, 5000);
            if (UptimeManager == null)
            {
                UptimeManager = new Timer(new TimerCallback(ManageUptimeOverflowAutoStop), null, 5000, 5000);
            }
            IsRunning = true;
            if (RunningStateChanged != null)
            {
                RunningStateChanged(true, fromUptimeManager);
            }
        }

        public void Stop(bool fromUptimeManager = false)
        {
            if (Updater != null)
            {
                Updater.Dispose();
            }

            if (MessageSender != null)
            {
                MessageSender.Dispose();
            }
            IsRunning = false;
            if (RunningStateChanged != null)
            {
                RunningStateChanged(false, fromUptimeManager);
            }
        }

        void ManageUptimeOverflowAutoStop(object o)
        {
            // Check if we're within 1 minute of GetTickCount() overflowing (WinMX breaks when this value overflows until it is re-opened. This also causes WinMX to fall out of chat rooms and the rejoiner to constantly re-add users)
            if (IsRunning && ((uint)Environment.TickCount) % uint.MaxValue <= 60000)
            {
                this.WinMXPIDAtDisabledTime = ProcessInfo.GetWinMXProcessID();
                this.DisabledUntilWinMXRestart = true;
                this.Stop(true);
                return;

            }

            // If we're disabled due to the overflow, check for new WinMX PID to enable starting again.
            if (this.DisabledUntilWinMXRestart)
            {
                var pid = ProcessInfo.GetWinMXProcessID();
                if (pid != this.WinMXPIDAtDisabledTime && pid != 0)
                {
                    this.DisabledUntilWinMXRestart = false;
                    this.Start(true);
                }
            }
        }

        void ManageAutoRejoinMessages(object o)
        {
            // If auto rejoin message is turned on and the message is not null or empty.
            if (SendAutoRejoinMessage && AutoRejoinMessage?.Length > 0)
            {
                // Get most attempts (most recent per channel) in the last minute.
                var attempts = Attempts.Where(c => DateTime.UtcNow.Subtract(c.Timestamp).TotalMinutes < 1).OrderByDescending(c => c.Timestamp).GroupBy(d => d.Channel).Select(e => e.First()).ToList();

                // Get active connections
                var connections = NetworkInfo.GetActiveConnections(ProcessInfo.GetWinMXProcessID()).ToList();

                attempts.ForEach((item) =>
                {
                    if (!item.SentMessage && connections.Contains(HashCode.HashToEndPoint(item.Channel)))
                    {
                        API.SendTextToChatRoom(item.Channel, AutoRejoinMessage);
                        item.SentMessage = true;
                    }
                });
            }
        }

        void ManageChannels(object o)
        {
            Attempts.Where(c => DateTime.UtcNow.Subtract(c.Timestamp).TotalHours >= 1).ToList().ForEach((item) =>
                Attempts.Remove(item));

            // Get Open Channels
            var channels = API.GetOpenChatRooms().ToList();
            if (channels.Count == 0) return;

            // Get Open Connections on WinMX.exe
            var connections = NetworkInfo.GetActiveConnections(ProcessInfo.GetWinMXProcessID()).ToList();

            channels.ForEach((room) =>
            {
                if (!connections.Contains(HashCode.HashToEndPoint(room)))
                    if (!ExcludedChannels.Contains(room))
                        if (MaximumAttempts == -1 || Attempts.Count(c => c.Channel == room) < MaximumAttempts)
                        {
                            API.JoinChatRoom(room);
                            Attempts.Add(new JoinAttempt() { Channel = room, Timestamp = DateTime.UtcNow });
                        }
            });
        }

        public void AddChannel(string Channel)
        {
            ExcludedChannels.Add(Channel);
            SaveSettings();
        }

        public void RemoveChannel(string Channel)
        {
            ExcludedChannels.Remove(Channel);
            SaveSettings();
        }

        public List<String> GetExcludedChannels()
        {
            return ExcludedChannels.ToList();
        }

        public void UpdateRejoinDuration(int Minutes)
        {
            RejoinDuration = Minutes;
            SaveSettings();

            if (Updater != null)
                Updater.Change(0, RejoinDuration * 60000);
        }

        public void UpdateMaximumAttempts(int Attempts)
        {
            MaximumAttempts = Attempts;
            SaveSettings();
        }

        public void UpdateOpenOnBootup(bool value)
        {
            OpenOnBootup = value;
            SaveSettings();

            if (value)
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true))
                {
                    key.SetValue("WinMX Channel Rejoiner", "\"" + System.Windows.Forms.Application.ExecutablePath + "\"");
                }
            }
            else
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true))
                {
                    key.DeleteValue("WinMX Channel rejoiner", false);
                }
            }
        }

        public void UpdateSendAutoRejoinMessage(bool value)
        {
            SendAutoRejoinMessage = value;
            SaveSettings();
        }

        public void UpdateAutoRejoinMessage(string value)
        {
            AutoRejoinMessage = value;
            SaveSettings();
        }

        class JoinAttempt
        {
            public string Channel;
            public DateTime Timestamp;
            public bool SentMessage;
        }
    }
}
