using System;
using System.Collections.Generic;
using System.Text;

namespace _07.TheV_LoggerWithClass
{
    class Vlogger
    {
        public Vlogger()
        {
            this.Followers = new HashSet<string>();
            this.Following = new HashSet<string>();
        }

        public HashSet<string> Followers { get; set; }
        public HashSet<string> Following { get; set; }

    }
}
