using System.Collections.Generic;
using LocalDbApi.Communications;

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

        public IEnumerable<string> Info()
        {
            const string arguments = "info";

            return Command.ExecuteList(arguments);
        }
         
    }
}