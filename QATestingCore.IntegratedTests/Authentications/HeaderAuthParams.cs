using System.Collections.Generic;

namespace QATestingCore.IntegratedTests.Authentications
{
    /// <summary>
    /// Contain the properties for the token authentication
    /// </summary>
    public class HeaderAuthParams
    {
        /// <summary>
        /// Represents the header name to be added into the request
        /// </summary>
        public string HeaderName { get; set; }
        /// <summary>
        /// Represents the header value to be added into the request
        /// </summary>
        public string HearderValue { get; set; }

        /// <summary>
        /// Represents the method to add a set of header into the request call
        /// </summary>
        /// <param name="headerName">Represents the header name to be added into the request</param>
        /// <param name="headerValue">Represents the header value to be added into the request</param>
        public HeaderAuthParams(string headerName, string headerValue)
        {
            if (headerName is null || headerValue is null)
            {
                throw new System.ArgumentException("Argument can not be null! ");
            }

            HeaderName = headerName;
            HearderValue = headerValue;

        }
    }
}
