using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using RestSharp;

namespace QATestingCore.IntegratedTests.Assertions
{
    public static class SchemaAssertions
    {
        /// <summary>
        /// Assert the json schema from the response to the json schema expected
        /// </summary>
        /// <param name="schemaString">Represents a string variable with the expected schema</param>
        /// <param name="response">Represents a IRestResponse object with the content to be asserted</param>
        /// <returns>Returns a boolean value to be asserted</returns>
        public static bool ValidateJsonSchema(string schemaString, IRestResponse response)
        {
            JsonSchema schema = JsonSchema.Parse(schemaString);

            JObject jsonObject = JObject.Parse(response.Content);

            return jsonObject.IsValid(schema);
        }
    }
}
