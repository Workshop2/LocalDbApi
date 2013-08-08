using System.Diagnostics;

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
         
    }
}