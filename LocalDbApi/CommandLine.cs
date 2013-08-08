using System;
using System.Diagnostics;
using System.IO;

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
                FileName = Path.Combine(Environment.SystemDirectory, "cmd.exe")
            };
        }

        public void Execute(string arguments)
        {
            Command.Arguments = string.Concat("/C ", ActionName, " ", arguments);

            using (var process = new Process())
            {
                process.Start();
                process.WaitForExit();
            }
        }
    }
}