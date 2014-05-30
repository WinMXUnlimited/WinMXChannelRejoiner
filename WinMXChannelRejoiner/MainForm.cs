/*
 *  WinMX Channel Rejoiner - A simple tool that will attempt to auto rejoin chat rooms if you fall out of them. 
 *  Copyright (C) 2013 WinMX Unlimited
 *  Copyright (C) 2013 Josh Glazebrook
 *
 *  WinMX Channel Rejoiner is free software: you can redistribute it and/or modify
 *  it under the terms of the GNU General Public License as published by
 *  the Free Software Foundation, either version 3 of the License, or
 *  (at your option) any later version.
 *
 *  WinMX Channel Rejoiner is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU General Public License for more details.
 *
 *  You should have received a copy of the GNU General Public License
 *  along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WinMXChannelRejoiner.Manager;
using WinMXChannelRejoiner.Properties;
using WinMXWindowApi;

namespace WinMXChannelRejoiner
{
    public partial class MainForm : Form
    {
        ChatManager Manager = new ChatManager();

        public MainForm()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void hideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadUISettings();
        }

        private void LoadUISettings()
        {
            switch (Settings.Default.RejoinDuration)
            {
                case 2:
                    Combo_RejoinDuration.SelectedItem = "two";
                    break;
                case 5:
                    Combo_RejoinDuration.SelectedItem = "five";
                    break;
                case 10:
                    Combo_RejoinDuration.SelectedItem = "ten";
                    break;
                // default and 1
                case 1:
                default:
                    Combo_RejoinDuration.SelectedItem = "one";
                    break;
            }

            switch (Settings.Default.MaximumAttempts)
            {
                case 1:
                    Combo_MaximumAttempts.SelectedItem = "one";
                    break;
                case 5:
                    Combo_MaximumAttempts.SelectedItem = "five";
                    break;
                case 10:
                    Combo_MaximumAttempts.SelectedItem = "ten";
                    break;
                case 20:
                    Combo_MaximumAttempts.SelectedItem = "twenty";
                    break;
                default:
                    Combo_MaximumAttempts.SelectedItem = "unlimited";
                    break;
            }

            if (Settings.Default.OpenOnBootup)
            {
                check_AutoStartOnStartup.CheckState = CheckState.Checked;
                Button_Start.Enabled = false;
                Button_Stop.Enabled = true;
                Manager.Start();
            }
        }

        private void MainIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
                this.Hide();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Manager.Stop();
            Application.Exit();
        }

        private void Button_Start_Click(object sender, EventArgs e)
        {
            Manager.Start();
            Button_Start.Enabled = false;
            Button_Stop.Enabled = true;
        }

        private void Button_Stop_Click(object sender, EventArgs e)
        {
            Manager.Stop();
            Button_Start.Enabled = true;
            Button_Stop.Enabled = false;
        }

        /// <summary>
        /// Updates the list box of open channels.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_ChannelUpdater_Tick(object sender, EventArgs e)
        {
            var openchannels = API.GetOpenChatRooms();
            var excludedchannels = Manager.GetExcludedChannels();
            var current = List_ChatRooms.Items.Cast<String>();

            /*
             * Note: Clearing/Adding all channels on every tick works but is not good for UX since selected items
             * get unselected on every update.
             */

            // Remove items from listbox that no longer need to be there.
            current.Where(c => !openchannels.Contains(c)).ToList().ForEach((channel) => 
                List_ChatRooms.Items.Remove(channel));

            // Add items to the listbox that need to be there.
            openchannels.Where(c => !current.Contains(c)).ToList().ForEach((channel) => 
                List_ChatRooms.Items.Add(channel, !excludedchannels.Contains(channel)));
        }

        private void List_ChatRooms_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Unchecked)
                Manager.AddChannel(List_ChatRooms.Items[e.Index] as string);
            else
                Manager.RemoveChannel(List_ChatRooms.Items[e.Index] as string);
        }

        private void Combo_RejoinDuration_SelectedValueChanged(object sender, EventArgs e)
        {
            int duration = 1;

            switch(Combo_RejoinDuration.Text) {
                case "one":
                    duration = 1;
                    break;
                case "two":
                    duration = 2;
                    break;
                case "five":
                    duration = 5;
                    break;
                case "ten":
                    duration = 10;
                    break;
                default:
                    break;
            }

            Manager.UpdateRejoinDuration(duration);
        }

        private void Combo_MaximumAttempts_SelectedValueChanged(object sender, EventArgs e)
        {
            int maximum = -1;

            switch (Combo_MaximumAttempts.Text)
            {
                case "one":
                    maximum = 1;
                    break;
                case "five":
                    maximum = 5;
                    break;
                case "ten":
                    maximum = 10;
                    break;
                case "twenty":
                    maximum = 20;
                    break;
                case "unlimited":
                    maximum = -1;
                    break;
                default:
                    break;
            }

            Manager.UpdateMaximumAttempts(maximum);
        }

        private void check_AutoStartOnStartup_CheckStateChanged(object sender, EventArgs e)
        {
            Manager.UpdateOpenOnBootup(check_AutoStartOnStartup.CheckState == CheckState.Checked);
        }
        
    }
}
