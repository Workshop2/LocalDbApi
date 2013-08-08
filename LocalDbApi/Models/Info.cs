using System;
using System.Collections.Generic;

namespace LocalDbApi.Models
{
    public class Info
    {
        public Info()
        {
        }

        public Info(List<string> instanceInfo)
        {
            throw new NotImplementedException();
        }

        public string Name { get; set; }
        public Version Version { get; set; }
        public string SharedName { get; set; }
        public string Owner { get; set; }
        public bool AutoCreate { get; set; }
        public State State { get; set; }
        public DateTime LastStartTime { get; set; }
        public string InstancePipeName { get; set; }
    }
}