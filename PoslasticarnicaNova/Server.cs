using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Server
{
    public class Server
    {
        private readonly Socket socket;
        private readonly List<ClientHandler> handlers = new List<ClientHandler>();
        private readonly object _lock = new object();

        public Server()
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        public void Start()
        {
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9999);
            socket.Bind(endPoint);
            socket.Listen(100);

            Thread thread = new Thread(AcceptClient);
            thread.IsBackground = true;
            thread.Start();
        }

        private void AcceptClient()
        {
            try
            {
                while (true)
                {
                    Socket klijentskiSocket = socket.Accept();
                    ClientHandler handler = new ClientHandler(klijentskiSocket, this);

                    lock (_lock)
                    {
                        handlers.Add(handler);
                    }

                    Thread klijentskaNit = new Thread(handler.HandleRequests);
                    klijentskaNit.IsBackground = true;
                    klijentskaNit.Start();
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }

        public void Stop()
        {
            List<ClientHandler> copy;
            lock (_lock)
            {
                copy = new List<ClientHandler>(handlers);
            }

            foreach (ClientHandler handler in copy)
            {
                handler.CloseSocket();
            }

            lock (_lock)
            {
                handlers.Clear();
            }

            socket.Close();
        }

        internal void RemoveClient(ClientHandler handler)
        {
            lock (_lock)
            {
                handlers.Remove(handler);
            }
        }
    }
}
