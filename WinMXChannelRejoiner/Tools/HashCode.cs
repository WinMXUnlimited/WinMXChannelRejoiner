using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace WinMXChannelRejoiner.Tools
{
    class HashCode
    {
        public static IPEndPoint HashToEndPoint(string Hash)
        {
            if (Hash.Length > 12)
                Hash = Hash.Substring(Hash.Length - 12, 12);

            return new IPEndPoint(Convert.ToUInt32(Hash.Substring(0, 8), 16), Convert.ToUInt16(Hash.Substring(8, 4), 16));
        }
    }
}
