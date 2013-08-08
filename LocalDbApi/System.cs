using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using LocalDbApi.Communications;
using LocalDbApi.Models;

namespace LocalDbApi
{
    public class System
    {
        private IDbCommunication Command { get; set; }

        public System() : this(new DbCommunication()) {}

        public System(IDbCommunication command)
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