using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace QATestingCore.IntegratedTests.Assertions
{
    public static class ResponseContentAssertions
    {
        public static bool AssertStatusCode(HttpStatusCode statusCode, HttpStatusCode expectedStatusCode)
        {
            return statusCode == expectedStatusCode;
        }
    }
}
