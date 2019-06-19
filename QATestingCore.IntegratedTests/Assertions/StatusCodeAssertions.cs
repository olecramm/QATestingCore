using System.Net;

namespace QATestingCore.IntegratedTests.Assertions
{
    /// <summary>
    /// Contains methods to assert statuscode of call's responses
    /// </summary>
    public static class StatusCodeAssertions
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
