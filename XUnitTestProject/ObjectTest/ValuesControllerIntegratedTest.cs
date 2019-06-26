using System;
using Xunit;
using QATestingCore.IntegratedTests.ActionsHandler;
using QATestingCore.IntegratedTests.TestUtils;
using QATestingCore.IntegratedTests.Assertions;
using QATestingCore.IntegratedTests.Authentications;
using System.Net;
using XUnitTestProject.Models;

namespace XUnitTestProject.ObjectTest
{
    public class ValuesControllerIntegratedTest : IClassFixture<ScenarioContext>
    {
        readonly ScenarioContext scenerioContext;
        private static UriBuilder uriBuilder;
        private static IHttpGetRequest _httpGetRequest = new HttpGetRequest();
        private static IHttpPostRequest _httpPostRequest = new HttpPostRequest();
        private static IHttpPutRequest _httpPutRequest = new HttpPutRequest();
        private static IHttpDelRequest _httpDelRequest = new HttpDelRequest();
        private static IOAuthentication _oauthAuthentication = new OAuthentication();

        public ValuesControllerIntegratedTest(ScenarioContext scenearioContext)
        {
            this.scenerioContext = scenearioContext;
            uriBuilder = new UriBuilder(scenerioContext.BaseEnvironmentObj["endpoints"]["service_1"].ToString());
        }


        [Theory]
        [InlineData("/30605678839/05?rlz=1C1SQJL_pt-BRBR809BR809&biw=1366&bih=625&tbm=isch", HttpStatusCode.OK)]
        public void TC_01_AssertActionGETApiValuesByID_OK(string resourcePath, HttpStatusCode expectedResult)
        {
            //Arrange
            uriBuilder.Path = resourcePath;

            //Act   
            var response = _httpGetRequest.MakeGetRequest(uriBuilder);

            //Assert
            Assert.Equal(expectedResult, response.StatusCode);
        }

        [Theory]
        [InlineData("TESTE02", "/Api/Value", HttpStatusCode.Created)]
        public void TC_02_AssertActionPOSTApiValuesByID_OK(string tesCaseName, string resourcePath, HttpStatusCode expectedResult)
        {
            //Arrange
            uriBuilder.Path = resourcePath;

            var paramsBody = RetrieveTestData.GetRequestParameters(scenerioContext.BaseEnvironmentObj["testDataPath"]["filePath"].ToString(), tesCaseName);

            //Act
            var response = _httpPostRequest.MakePostRequet(uriBuilder, paramsBody);

            //Assert
            Assert.Equal(expectedResult, response.StatusCode);
        }

        [Theory]
        [InlineData("TESTE03", "/userinformation/101", HttpStatusCode.OK)]
        public void TC_03_AssertActionPUTApiValuesByID_OK(string tesCaseName, string resourcePath, HttpStatusCode expectedResult)
        {
            //Arrange
            uriBuilder.Path = resourcePath;

            var paramsBody = RetrieveTestData.GetRequestParameters(scenerioContext.BaseEnvironmentObj["testDataPath"]["filePath"].ToString(), tesCaseName);

            //Act
            var response = _httpPutRequest.MakePutRequest(uriBuilder, paramsBody);

            //Assert
            var result = StatusCodeAssertions.AssertStatusCode(response.StatusCode, expectedResult);
            Assert.True(result);
        }

        [Theory]
        [InlineData("/userinformation/101", HttpStatusCode.OK)]
        public void TC_04_AssertActionDELApiValuesByID_OK(string resourcePath, HttpStatusCode expectedResult)
        {
            //Arrange
            uriBuilder.Path = resourcePath;

            //Act   
            var response = _httpDelRequest.MakeDeleteRequest(uriBuilder);

            //Assert
            var result = StatusCodeAssertions.AssertStatusCode(response.StatusCode, expectedResult);
            Assert.True(result);
        }

        [Theory]
        [InlineData("/userinformation?userId=101", HttpStatusCode.OK)]
        public void TC_05_AssertActionGETApiValuesByID_OK(string resourcePath, HttpStatusCode expectedResult)
        {
            //Arrange
            uriBuilder.Path = resourcePath;

            //Act   
            var response = _httpGetRequest.MakeGetRequest(uriBuilder);

            //Assert
            var result = StatusCodeAssertions.AssertStatusCode(response.StatusCode, expectedResult);
            Assert.True(result);
        }

        [Theory]
        [InlineData("/userinformation?userId=101", HttpStatusCode.OK)]
        public void TC_06_AssertActionGETApiValuesByID_OK_WithToken(string resourcePath, HttpStatusCode expectedResult)
        {
            //Arrange
            uriBuilder.Path = resourcePath;

            UriBuilder oauthURI = new UriBuilder(scenerioContext.BaseEnvironmentObj["endpoints"]["service_2"].ToString())
            {
                Path = "/token"
            };

            var paramsBody = RetrieveTestData.GetResourceAsJObject(scenerioContext.BaseEnvironmentObj["testDataPath"]["filePath"].ToString());

            var _jwtToken = _oauthAuthentication.BearerAuthentication(oauthURI, paramsBody);

            //Act   
            var response = _httpGetRequest.MakeGetRequest(uriBuilder, HttpMethod.GET, _jwtToken);

            //Assert
            var result = StatusCodeAssertions.AssertStatusCode(response.StatusCode, expectedResult);
            Assert.True(result);
        }

        [Theory]
        [InlineData("TESTE07", "/TestingDictionaryAssert")]
        public void TC_07_AssertReturnedData(string testCaseName, string resourcePath)
        {
            //Arrange
            uriBuilder.Path = resourcePath;

            var expectedObj = RetrieveTestData.GetRequestParameters<ParamsBodyTest>(scenerioContext.BaseEnvironmentObj["testDataPath"]["filePath"].ToString(), 
                                                                                    testCaseName);

            //Act
            var response = _httpGetRequest.MakeGetRequest(uriBuilder, HttpMethod.GET);

            //Assert
            ResponseContentAssertions.AssertResponseDataObject<ParamsBodyTest>(response, expectedObj);
        }
    }
}
