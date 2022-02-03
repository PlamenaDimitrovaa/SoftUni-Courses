using CommandPattern.Core.Commands;
using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CommandPattern.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            var inputInfo = args.Split();
            string commandName = inputInfo[0] + "Command";
            var parameters = inputInfo.Skip(1).ToArray();

            Type type = Assembly.GetCallingAssembly().GetTypes().Where(x => x.Name == commandName).FirstOrDefault();
            if (type == null)
            {
                throw new InvalidOperationException("Invalid command");
            }

            ICommand command = (ICommand)Activator.CreateInstance(type);

            //if (commandName == nameof(HelloCommand))
            //{
            //    command = new HelloCommand();
            //}
            //else if (commandName == nameof(BeepCommand))
            //{
            //    command = new BeepCommand();
            //}
            //else if (commandName == nameof(ComplexCommand))
            //{
            //    command = new ComplexCommand();
            //}
            //else
            //{
            //    throw new InvalidOperationException("Invalid command");
            //}

            string result = command.Execute(parameters);
            return result;
        }
    }
}
