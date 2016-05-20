using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using WinMXWindowApi;

namespace WinMXChannelRejoiner.Tools
{
    class ProcessInfo
    {
        [DllImport("user32.dll", SetLastError = true)]
        static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);
     
        /// <summary>
        /// Gets the process id belonging to WinMX.exe using winapi to avoid permission issues.
        /// </summary>
        /// <returns></returns>
        public static int GetWinMXProcessID()
        {
            uint result;
            GetWindowThreadProcessId(API.GetWinMXWindowHandle(), out result);
            return (int)result;
        }
    }
}
