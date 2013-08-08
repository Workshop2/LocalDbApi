using System.Diagnostics;

namespace LocalDbApi
{
    public class Instance
    {
        private ICommandLine Command { get; set; }

        public Instance() : this(new CommandLine()) {}

        public Instance(ICommandLine command)
        {
            Command = command;
        }
        
        public void Create(string instanceName)
        {
            string arguments = string.Concat("create ", instanceName);

            Command.Execute(arguments);
        }

        public void Delete(string instanceName)
        {
            string arguments = string.Concat("delete ", instanceName);

            Command.Execute(arguments);
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