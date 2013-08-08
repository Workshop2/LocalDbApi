using System.Collections.Generic;
using System.Diagnostics;

namespace LocalDbApi
{
    internal class CommandLine
    {
        private const string ActionName = "SqlLocalDb";
        private ProcessStartInfo Command { get; set; }

        public CommandLine()
        {
            Command = new ProcessStartInfo
            {
                WindowStyle = ProcessWindowStyle.Hidden,
                FileName = ActionName,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                CreateNoWindow = true
            };
        }

        public void Execute(string arguments)
        {
            ExecuteString(arguments);
        }

        public string ExecuteString(string arguments)
        {
            Command.Arguments = arguments;

            using (var process = new Process())
            {
                process.StartInfo = Command;
                process.Start();
                process.WaitForExit();

                return process.StandardOutput.ReadToEnd();
            }
        }

        public IEnumerable<string> ExecuteList(string arguments)
        {
            Command.Arguments = arguments;

            using (var process = new Process())
            {
                process.StartInfo = Command;
                process.Start();

                while (!process.StandardOutput.EndOfStream)
                {
                    yield return process.StandardOutput.ReadLine();
                }
            }
        }
    }
}