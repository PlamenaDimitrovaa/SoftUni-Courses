using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommandPattern.Core.Commands
{
    public class ComplexCommand : ICommand
    {
        public string Execute(string[] args)
        {
            return $"Complex command {args[0]} {args[1]}...";
        }
    }
}
