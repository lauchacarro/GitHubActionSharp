using System;

namespace GitHubActionSharp
{
    [AttributeUsage(AttributeTargets.Field)]
    public class ParameterAttribute : Attribute
    {
        public ParameterAttribute(string key)
        {
            Key = key;
        }

        public string Key { get; set; }
    }
}
