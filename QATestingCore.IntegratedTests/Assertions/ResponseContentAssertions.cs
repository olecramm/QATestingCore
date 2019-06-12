using Newtonsoft.Json.Linq;
using RestSharp;
using System.Collections.Generic;

namespace QATestingCore.IntegratedTests.Assertions
{
    public static class ResponseContentAssertions
    {
        public static bool AssertResponseData(IRestResponse response, IDictionary<string, string> expectedResult, out string resultTestMessage)
        {
            resultTestMessage = string.Empty;

            var responseContent = JObject.Parse(response.Content);            

            foreach (KeyValuePair<string,string> item in expectedResult)
            {
                var Key = responseContent.GetValue(item.Key);

                if (responseContent.GetValue(item.Key) == null)
                {
                    resultTestMessage = $"Parameter {item.Key} is not present";

                    return false;
                }
                else if (responseContent.GetValue(item.Key).Equals(item.Value))
                {
                    resultTestMessage = $"Parameter {item.Key} value is not equal as expected";

                    return false;
                }                
            };
            return true;
        }
    }
}
