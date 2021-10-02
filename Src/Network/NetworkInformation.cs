using System.Net;
using System.Net.Sockets;

namespace WhereWeLivin.Network
{
    public static class NetworkInformation
    {
        // Global network information
        public static IPAddress IpAddress { get; set; }
        public static int Port { get; set; }
    }
}