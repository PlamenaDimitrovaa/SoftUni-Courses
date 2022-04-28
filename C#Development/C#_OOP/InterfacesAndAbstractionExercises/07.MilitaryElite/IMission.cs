using System;
using System.Collections.Generic;
using System.Text;

namespace _07.MilitaryElite
{
    public interface IMission
    {
        public string CodeName { get; set; }
        public Status Status { get; set; }
    }
}
