using System;

namespace GitHubActionSharp
{
    [System.Serializable]
    public class GitHubActionSharpException : Exception
    {
        public GitHubActionSharpException() { }
        public GitHubActionSharpException(string message) : base(message) { }
        public GitHubActionSharpException(string message, Exception inner) : base(message, inner) { }
        protected GitHubActionSharpException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }

}

