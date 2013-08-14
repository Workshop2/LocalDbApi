using System.Collections.Generic;
using LocalDbApi.Communications;

namespace LocalDbApi
{
    public class Instance
    {
        private IDbCommunication Command { get; set; }

        public Instance() : this(new DbCommunication()) {}

        public Instance(IDbCommunication command)
        {
            Command = command;
        }
        
        public void Create(string instanceName)
        {
            string arguments = string.Concat("create ", instanceName, " -s");

            Command.Execute(arguments);
        }

        public void Delete(string instanceName)
        {
            StopInstance(instanceName);

            string arguments = string.Concat("delete ", instanceName);

            Command.Execute(arguments);
        }

        public void StartInstance(string instanceName)
        {
            string arguments = string.Concat("start ", instanceName);

            Command.Execute(arguments);
        }

        public void StopInstance(string instanceName)
        {
            string arguments = string.Concat("stop ", instanceName);

            Command.Execute(arguments);
        }

        public IEnumerable<string> ListInstances()
        {
            const string arguments = "info";

            return Command.ExecuteList(arguments);
        }
    }
}