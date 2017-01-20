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
        public const int PORT = 16969;

        public Server()
        {

            LocalIP = IPAddress.Any;
            Listener = new TcpListener(LocalIP, PORT);
        }

        public void startListening()
        {            
            Listener.Start();
            Console.WriteLine("Starting Listener on port " + PORT + "...");

            while (true)
            {
                TcpClient client = Listener.AcceptTcpClient();

                NetworkStream stream = client.GetStream();
                byte[] incomingData = new byte[client.ReceiveBufferSize];
                int bytesToRead = stream.Read(incomingData, 0, Convert.ToInt32(client.ReceiveBufferSize));
                string receivedMsg = Encoding.ASCII.GetString(incomingData, 0, bytesToRead);
                stream.Flush();

                Console.WriteLine(receivedMsg);
                byte[] outgoingData = Encoding.ASCII.GetBytes("you said: " + receivedMsg);
                int bytesToSend = outgoingData.Length;
                stream.Write(outgoingData, 0, bytesToSend);
                stream.Flush();
            }
        }
    }
}
