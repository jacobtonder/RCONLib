using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace RCONLib
{
    public class RconClient : IDisposable
    {
        private readonly IPEndPoint Host;
        private readonly string Password;
        private readonly Socket Channel;
        private bool Connected;

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
            this.Connected = false;
            Channel = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            ConnectAsync().Wait();
        }

        public async Task ConnectAsync()
        {
            if (Connected)
                return;

            await Channel.ConnectAsync(Host);
            Connected = true;
        }

        public void Dispose()
        {
            this.Connected = false;
            this.Channel.Shutdown(SocketShutdown.Both);
            this.Dispose();
        }
    }
}
