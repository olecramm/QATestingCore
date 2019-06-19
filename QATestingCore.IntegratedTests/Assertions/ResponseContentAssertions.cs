using FluentAssertions;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace QATestingCore.IntegratedTests.Assertions
{
    public static class ResponseContentAssertions 
    {
        /// <summary>
        /// Assert the content from the response to the content expected
        /// </summary>
        /// <typeparam name="T">Represents a JObject of type T</typeparam>
        /// <param name="response">Represents a IRestResponse object with the content to be asserted</param>
        /// <param name="expectedResult">Represents a JObject of type T containing the expected parameters</param>
        /// <returns></returns>
        public static bool AssertResponseDataObject<T>(IRestResponse response, T expectedResult)
        {
            var result = JObject.Parse(response.Content).ToObject<T>();

            try
            {
                result.Should().BeEquivalentTo<T>(expectedResult);
            }
            catch (System.Exception e)
            {
                throw new System.Exception(e.Message);
            }
            return true;
        }
    }
}
