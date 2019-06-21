using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
