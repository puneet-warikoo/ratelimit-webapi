using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using WebApi.RateLimits.Exceptions;
using WebApi.RateLimits.Interfaces;


namespace WebApi.RateLimits.Defaults
{
    class RequestHeaderIdentifier : IRateLimitRequestIdentifier
    {
        private List<string> _headers;
        private bool _ignore_unvailable;
        /// <summary>
        /// Constructor to define the Identifier Class based on list of headers
        /// </summary>
        /// <param name="headers"> List of header Names to use for creating the identifier</param>
        /// <param name="ignoreUnavailables">Ignores the header names that are not available in the request to create idenifier. If false, this generates exception if header is not found</param>
        /// <exception cref="HeaderNotFoundException"></exception>
        public RequestHeaderIdentifier(List<string> headers, bool ignoreUnavailables)
        {
            _headers = headers;
            _ignore_unvailable = ignoreUnavailables;
        }
        /// <summary>
        /// Create the request identfier based on list of headers in request
        /// </summary>
        /// <param name="requestMessage" cref="HttpRequestMessage"></param>
        /// <returns>Request Identifier</returns>
        public string GetIdentifier(HttpRequestMessage requestMessage)
        {
            StringBuilder builder = new StringBuilder();
            foreach (var header in _headers)
            {
                if (requestMessage.Headers.Contains(header))
                {
                    builder.Append(header).Append("->").Append(string.Join("$", requestMessage.Headers.GetValues(header));
                    builder.Append("<->");
                }
                else
                {
                    if (!_ignore_unvailable)
                        throw new HeaderNotFoundException(header);
                }


            }
            return builder.ToString();
        }
    }
}
