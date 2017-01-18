using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SocketServer
{
    public class Server
    {
        public IPAddress LocalIP { get; set; }
        public TcpListener Listener { get; set; }

        public Server()
        {
            LocalIP = IPAddress.Any;
            Listener = new TcpListener(LocalIP, 26969);
        }

        public void startListening()
        {            
            Listener.Start();

            while (true)
            {
                Console.WriteLine("Starting Listener...");

                Socket clientSocket = Listener.AcceptSocket();

                Console.WriteLine("A thing happened!");
            }
        }
    }
}
