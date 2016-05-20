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
