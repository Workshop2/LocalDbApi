using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using LocalDbApi.Models;

namespace LocalDbApi
{
    public class System
    {
        private ICommandLine Command { get; set; }

        public System() : this(new CommandLine()) {}

        public System(ICommandLine command)
        {
            Command = command;
        }

        public void Info()
        {
            const string arguments = "info";

            foreach (var argument in Command.ExecuteList(arguments))
            {
                Debug.WriteLine(argument);
            }
        }

        public Info Info(string instanceName)
        {
            string arguments = string.Concat("info ", instanceName);

            List<string> instanceInfo = Command.ExecuteList(arguments).ToList();
            
            return new Info(instanceInfo);
        }
         
    }
}