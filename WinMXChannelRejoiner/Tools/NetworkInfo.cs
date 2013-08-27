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
using System.Linq;
using System.Net;
using System.Text;

namespace WinMXChannelRejoiner.Tools
{
    class NetworkInfo
    {
        public static List<IPEndPoint> GetActiveConnections(int ProcessID)
        {
            var results = Network.ManagedIpHelper.GetExtendedTcpTable(false)
                .Where(c => c.State == System.Net.NetworkInformation.TcpState.Established && c.ProcessId == ProcessID);

            return results.Select(c => c.RemoteEndPoint).ToList();
        }
    }
}
