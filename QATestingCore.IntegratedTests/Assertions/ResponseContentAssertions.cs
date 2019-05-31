using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace QATestingCore.IntegratedTests.Assertions
{
    public static class ResponseContentAssertions
    {
        /// <summary>
        /// Compare the statuscode received to the statuscode expected
        /// </summary>
        /// <param name="statusCode">Represents the status code got from response being validated</param>
        /// <param name="expectedStatusCode">Represents the expected status code</param>
        /// <returns>Returns a boolean data to be asserted</returns>
        public static bool AssertStatusCode(HttpStatusCode statusCode, HttpStatusCode expectedStatusCode)
        {
            return statusCode == expectedStatusCode;
        }
    }
}
