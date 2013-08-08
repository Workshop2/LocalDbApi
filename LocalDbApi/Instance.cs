namespace LocalDbApi
{
    public class Instance
    {
        public void Create(string instanceName)
        {
            CommandLine commandLine = new CommandLine();
            string arguments = string.Concat("create ", instanceName);

            commandLine.Execute(arguments);
        }

        public void Delete(string instanceName)
        {
            CommandLine commandLine = new CommandLine();
            string arguments = string.Concat("delete ", instanceName);

            commandLine.Execute(arguments);
        }

        public void Info()
        {
            CommandLine commandLine = new CommandLine();
            string arguments = "info";

            commandLine.Execute(arguments);
        }
    }
}