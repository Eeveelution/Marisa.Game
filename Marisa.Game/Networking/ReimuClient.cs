using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using osu.Framework.Logging;

namespace Marisa.Game.Networking
{
    class ReimuClient
    {
        private TcpClient ReimuConnection;
        private NetworkStream ReimuDataStream;

        private BlockingCollection<byte[]> RequestQueue = new BlockingCollection<byte[]>();

        public void QueueRequest(byte[] buffer)
        {
            RequestQueue.Add(buffer);
        }

        public ReimuClient(string Location)
        {
            this.ReimuConnection = new TcpClient(Location, 47536);
            this.ReimuDataStream = ReimuConnection.GetStream();

            string LoginString = String.Format("{0}\n{1}\n{2}", "TestUsername", "TestPassword", "Alpha1");

            QueueRequest (
                Encoding.ASCII.GetBytes(LoginString)
            );
        }

        public void Run()
        {
            int ReadBytes = 0;
            byte[] ReadBuffer = new byte[1024];

            Begin:
            while (true)
            {
                if(ReimuConnection != null && ReimuConnection.Connected)
                {
                    PacketType PacketType = 0;
                    uint PacketLength = 0;

                    

                    while(ReimuDataStream != null && ReimuDataStream.DataAvailable)
                    {
                        ReadBytes = ReimuDataStream.Read(ReadBuffer, 0, 1024);

                        Array.Copy(ReadBuffer, 0, ReadBuffer, 0, ReadBytes);

                        using(BinaryReader reader = new BinaryReader(new MemoryStream(ReadBuffer)))
                        {
                            PacketType = (PacketType)reader.ReadUInt16();
                            PacketLength = reader.ReadUInt32();

                            byte[] RemainingData = new byte[reader.BaseStream.Length - reader.BaseStream.Position];
                            Array.Copy(ReadBuffer, 6, RemainingData, 0, reader.BaseStream.Length - reader.BaseStream.Position);

                            using (BinaryReader packet = new BinaryReader(new MemoryStream(RemainingData)))
                            {
                                switch (PacketType)
                                {
                                    case PacketType.LoginResponse:
                                        Logger.Log("Got Login Response", LoggingTarget.Network, LogLevel.Important, true);
                                        break;
                                }
                            }
                        }
                    }
                }
            }
        }

    }
}
