using System;
using System.Runtime.Serialization;

namespace WebApi.RateLimits.Exceptions
{
    [Serializable]
    internal class HeaderNotFoundException : Exception
    {
        private string _Message;
        public override string Message
        {
            get { return _Message; }
        }
        public HeaderNotFoundException(string header)
        {
            this._Message = "Header not found. Name = " + header;

        }

        public HeaderNotFoundException(string header, Exception innerException) : base(header, innerException)
        {
            this._Message = "Header not found. Name = " + header;
        }

    }
}