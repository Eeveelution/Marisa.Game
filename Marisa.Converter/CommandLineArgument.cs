using System;
using System.Collections.Generic;
using System.Text;

namespace Marisa.Converter
{
    class CommandLineArgument
    {
        public string Name { get; private set; }
        public string Value { get; private set; }

        public CommandLineArgument(string Name, string Value)
        {
            this.Name = Name;
            this.Value = Value;
        }
    }
}
