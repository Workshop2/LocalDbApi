using System.Collections.Generic;

namespace LocalDbApi
{
    public interface IDbCommunication
    {
        void Execute(string arguments);
        string ExecuteString(string arguments);
        IEnumerable<string> ExecuteList(string arguments);
    }
}