using Newtonsoft.Json.Linq;
using QATestingCore.IntegratedTests.ActionsHandler;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QATestingCore.IntegratedTests.Authentications
{
    /// <summary>
    /// Contains methods to beget token authentication as JWT security
    /// </summary>
    public class JWTAuthentication : HttpBaseRequest, IJWTAuthentication
    {
        private UriBuilder uriBuilder;

        /// <summary>
        /// Create the UriBuilder object in memory
        /// </summary>
        public JWTAuthentication()
        {
            uriBuilder = new UriBuilder();
        }

        /// <summary>
        /// Generate oauth token through an authentication server asynchronously
        /// </summary>
        /// <param name="uriBuilder">Represents an object that contains client and request informations</param>
        /// <param name="paramsObj">Represents an objects with the parameters to be sent wrapped into the request</param>
        /// <returns>Returns a token sent for the oauth authentication server</returns>
        public string GetOauthAuthentication(UriBuilder uriBuilder, JObject paramsObj)
        {
            var baseUrl = AssembleBaseUrl(uriBuilder);

            Arrange(baseUrl,
                    uriBuilder.Uri.LocalPath,
                    HttpMethod.GET,
                    DataFormat.Json,
                    paramsObj);

            var response = ActAsync().GetAwaiter().GetResult();

            var accessToken = JObject.Parse(response.Content);

            var token = accessToken.GetValue("access_token").ToString();

            return token;
        }
    }
}
