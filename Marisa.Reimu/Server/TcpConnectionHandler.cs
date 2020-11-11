using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Marisa.Reimu.Server
{
    class TcpConnectionHandler
    {
        public static void TcpAcceptThread(string Location)
        {
            IPAddress runAdress = IPAddress.Parse(Location);
            TcpListener listener = new TcpListener(runAdress, 47536);
        }
    }
}
