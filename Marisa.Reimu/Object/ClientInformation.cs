using System;
using System.Collections.Generic;
using System.Text;

namespace Marisa.Reimu.Object
{
    class ClientInformation
    {
        public string Username      { get; private set; }
        public string Password      { get; private set; }
        public string ClientVersion { get; private set; }

        public ClientInformation(string Username, string Password, string ClientVersion)
        {
            this.Username = Username;
            this.Password = Password;
            this.ClientVersion = ClientVersion;
        }
    }
}
