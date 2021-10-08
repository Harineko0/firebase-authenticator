using System;

namespace GoogleOAuth
{
    public class NetworkException : Exception
    {
        public long StatusCode { get; internal set; }
        
        public NetworkException(string message, long statusCode) : base(message)
        {
            StatusCode = statusCode;
        }
    }
}