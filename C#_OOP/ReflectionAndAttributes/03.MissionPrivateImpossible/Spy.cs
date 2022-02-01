using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string RevealPrivateMethods(string investigatedClass)
        {
            Type classType = Type.GetType(investigatedClass);
            MethodInfo[] classMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            StringBuilder builder = new StringBuilder();

            builder.AppendLine($"All Private Methods of Class: {investigatedClass}")
                .AppendLine($"Base Class: {classType.BaseType.Name}");

            foreach (MethodInfo method in classMethods)
            {
                builder.AppendLine(method.Name);
            }

            return builder.ToString().Trim();
        }
    }
}
