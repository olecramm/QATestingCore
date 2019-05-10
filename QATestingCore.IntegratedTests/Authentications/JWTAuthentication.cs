using Newtonsoft.Json.Linq;
using QATestingCore.IntegratedTests.ActionsHandler;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QATestingCore.IntegratedTests.Authentications
{
    public class JWTAuthentication : HttpBaseRequest, IJWTAuthentication
    {
        private UriBuilder uriBuilder;

        public JWTAuthentication()
        {
            uriBuilder = new UriBuilder();
        }

        public string GetOauthAuthentication(UriBuilder uriBuilder, JObject paramsObj)
        {
            var baseUrl = AssembleBaseUrl(uriBuilder);

            Arrange(baseUrl,
                    uriBuilder.Uri.LocalPath,
                    Method.GET,
                    DataFormat.Json,
                    paramsObj);

            var response = ActAsync().GetAwaiter().GetResult();

            var accessToken = JObject.Parse(response.Content);

            var token = accessToken.GetValue("access_token").ToString();

            return token;
        }
    }
}
