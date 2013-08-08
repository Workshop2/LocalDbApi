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
    }
}