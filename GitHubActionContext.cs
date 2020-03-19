using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace GitHubActionSharp
{
    public class GitHubActionContext
    {
        private readonly List<string> _args;
        public Dictionary<string, string> Parameters { get; }

        public GitHubActionContext(params string[] args)
        {
            _args = args.ToList();
            Parameters = new Dictionary<string, string>();
        }

        public void LoadParameters()
        {
            foreach (string arg in _args)
            {
                if (arg.StartsWith("-"))
                {
                    int index = _args.IndexOf(arg);

                    string argAux = arg.Substring(1);

                    if (_args[index] == _args.Last())
                    {
                        Parameters.Add(argAux, null);
                    }
                    else if (_args[index + 1].StartsWith("-"))
                    {
                        throw new GitHubActionSharpException($"Parameter value shouldn't start with '-'.");
                    }
                    else
                    {
                        Parameters.Add(argAux, _args[index + 1]);
                    }
                }
            }
        }

        public string GetParameter(Enum @enum)
        {
            FieldInfo fi = @enum.GetType().GetField(@enum.ToString());

            ParameterAttribute attribute =
                (ParameterAttribute)fi.GetCustomAttributes(
                typeof(ParameterAttribute),
                false).FirstOrDefault();

            if (attribute != null)
            {
                return Parameters[attribute.Key];
            }
            else
                throw new GitHubActionSharpException($"The Field Enum '{fi.Name}' should have ParameterAttribute.");

        }
    }
}
