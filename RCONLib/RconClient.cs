using System;
using System.Net;
using System.Net.Sockets;

namespace RCONLib
{
    public class RconClient : IDisposable
    {
        private readonly IPEndPoint Host;
        private readonly string Password;
        private readonly Socket Channel;

        public RconClient (string hostIp, ushort port, string password) : this(IPAddress.Parse(hostIp), port, password)
        {
        }

        public RconClient(IPAddress host, ushort port, string password) : this(new IPEndPoint(host, port), password)
        {
        }

        public RconClient(IPEndPoint host, string password)
        {
            this.Host = host;
            this.Password = password;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
