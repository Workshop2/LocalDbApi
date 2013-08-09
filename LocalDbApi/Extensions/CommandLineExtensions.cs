namespace LocalDbApi.Extensions
{
    public static class CommandLineExtensions
    {
        public static string ToCommandLineArgument(this string argument)
        {
            if (!string.IsNullOrEmpty(argument))
            {
                if (argument.Contains(" "))
                {
                    argument = string.Format("\"{0}\"", argument);
                }
            }

            return argument;
        }
    }
}