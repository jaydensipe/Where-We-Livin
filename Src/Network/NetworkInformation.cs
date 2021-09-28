using System.Net;
using System.Net.Sockets;

namespace WhereWeLivin.Network
{
    public static class NetworkInformation
    {
        public static IPAddress IpAddress { get; set; }
        public static int Port { get; set; }
    }
}