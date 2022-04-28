using System;
using System.Collections.Generic;
using System.Text;

namespace _07.MilitaryElite
{
    public interface ILieutenantGeneral : IPrivate
    {
        public List<IPrivate> Privates { get; set; }
    }
}
