using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Marisa.Reimu.Object
{
    class Client
    {
        private TcpClient Connection;
        private NetworkStream DataStream;

        private BlockingCollection<byte[]> RequestQueue = new BlockingCollection<byte[]>();

        #region ClientInformation

        private ClientInformation UserInformation;

        #endregion

        public Client(TcpClient client)
        {
            this.Connection = client;
            this.DataStream = client.GetStream();

            Task.Factory.StartNew(() =>
            {
                foreach (byte[] Request in RequestQueue.GetConsumingEnumerable())
                {
                    try
                    {
                        this.DataStream.Write(Request, 0, Request.Length);
                    }
                    catch
                    {
                        Console.WriteLine("Queued Request Failed to send.");
                    }
                }
            });
        }

        public void QueueRequest(byte[] buffer)
        {
            RequestQueue.Add(buffer);
        }

        public void HandleClient()
        {
            byte[] ReadBuffer = new byte[1024];

            while (Connection.Connected)
            {
                if(Connection.Available != 0 && DataStream.DataAvailable && DataStream.CanRead)
                {
                    int BytesRecieved = DataStream.Read(ReadBuffer, 0, 1024);

                    if (UserInformation == null)
                    {
                        //User hasn't Authenticated yet..

                        string LoginString = Encoding.ASCII.GetString(ReadBuffer, 0, BytesRecieved);
                        string[] ParsedLogin = LoginString.Split('\n');

                        UserInformation = new ClientInformation(ParsedLogin[0], ParsedLogin[1], ParsedLogin[2]);

                    } else
                    {
                        //User has Authenticated and is sending a Data Packet
                    }
                }
            }
        }
    }
}
