using System;
using Xunit;
using QATestingCore.IntegratedTests.ActionsHandler;
using QATestingCore.IntegratedTests.TestUtils;
using QATestingCore.IntegratedTests.Assertions;
using System.Net;
using QATestingCore.IntegratedTests.Authentications;

namespace XUnitTestProject.ObjectTest
{
    public class ValuesControllerIntegratedTest
    {
        private UriBuilder testURI;
        private static IHttpGetRequest _httpGetRequest;
        private static IHttpPostRequest _httpPostRequest;
        private static IHttpPutRequest _httpPutRequest;
        private static IHttpDelRequest _httpDelRequest;
        private static IJWTAuthentication _oauthAuthentication;
        private string TestDataPath;

        public ValuesControllerIntegratedTest()
        {            
            _httpGetRequest = new HttpGetRequest();
            _httpPostRequest = new HttpPostRequest();
            _httpPutRequest = new HttpPutRequest();
            _httpDelRequest = new HttpDelRequest();
            _oauthAuthentication = new JWTAuthentication();

            TestDataPath = @"\TestsData\ValuesControllerTestsData.json";
        }

        [Theory(Skip = "specific reason")]
        [InlineData("https://support.hypernode.com", "/30605678839/05?rlz=1C1SQJL_pt-BRBR809BR809&biw=1366&bih=625&tbm=isch", HttpStatusCode.OK)]
        public void TC_01_AssertActionGETApiValuesByID_OK(string baseUrl, string resourcePath, HttpStatusCode expectedResult)
        {
            //Arrange
            testURI = new UriBuilder(baseUrl) {
                Path = resourcePath
            };

            //Act   
            var response = _httpGetRequest.MakeGetRequest(testURI);

            //Assert
            Assert.Equal(expectedResult, response.StatusCode);
        }

        [Theory(Skip = "specific reason")]
        [InlineData("https://support.hypernode.com", "Api/Value", HttpStatusCode.OK)]
        public void TC_02_AssertActionPOSTApiValuesByID_OK(string baseUrl, string resourcePath, HttpStatusCode expectedResult)
        {
            //Arrange
            testURI = new UriBuilder(baseUrl)
            {
                Path = resourcePath
            };
            
            var paramsBody = RetrieveTestData.GetResourceAsJObject(TestDataPath);

            //Act
            var response = _httpPostRequest.MakePostRequet(testURI, paramsBody);

            //Assert
            Assert.Equal(expectedResult, response.StatusCode);
        }

        [Theory]
        [InlineData("http://localhost:3000", "/userinformation/101", HttpStatusCode.OK)]
        public void TC_03_AssertActionPUTApiValuesByID_OK(string baseUrl, string resourcePath, HttpStatusCode expectedResult)
        {
            //Arrange
            testURI = new UriBuilder(baseUrl)
            {
                Path = resourcePath
            };

            var paramsBody = RetrieveTestData.GetResourceAsJObject(TestDataPath);

            //Act
            var response = _httpPutRequest.MakePutRequest(testURI, paramsBody);

            //Assert
            var result = ResponseContentAssertions.AssertStatusCode(response.StatusCode, expectedResult);
            Assert.True(result);
        }

        [Theory]
        [InlineData("http://localhost:3000", "/userinformation/101", HttpStatusCode.OK)]
        public void TC_04_AssertActionDELApiValuesByID_OK(string baseUrl, string resourcePath, HttpStatusCode expectedResult)
        {
            //Arrange
            testURI = new UriBuilder(baseUrl)
            {
                Path = resourcePath

            };

            //Act   
            var response = _httpDelRequest.MakeDeleteRequest(testURI);

            //Assert
            var result = ResponseContentAssertions.AssertStatusCode(response.StatusCode, expectedResult);
            Assert.True(result);
        }

        [Theory]
        [InlineData("http://localhost:3000", "/userinformation?userId=101", HttpStatusCode.OK)]
        public void TC_05_AssertActionGETApiValuesByID_OK(string baseUrl, string resourcePath, HttpStatusCode expectedResult)
        {
            //Arrange
            testURI = new UriBuilder(baseUrl)
            {
                Path = resourcePath
            };

            //Act   
            var response = _httpGetRequest.MakeGetRequest(testURI);

            //Assert
            var result = ResponseContentAssertions.AssertStatusCode(response.StatusCode, expectedResult);
            Assert.True(result);
        }

        [Theory]
        [InlineData("http://localhost:3000", "/userinformation?userId=101", HttpStatusCode.OK)]
        public void TC_06_AssertActionGETApiValuesByID_OK_WithToken(string baseUrl, string resourcePath, HttpStatusCode expectedResult)
        {
            //Arrange
            testURI = new UriBuilder(baseUrl)
            {
                Path = resourcePath
            };

            UriBuilder oauthURI = new UriBuilder("http://localhost:3000") {
                Path = "/token"
            };

            var paramsBody = RetrieveTestData.GetResourceAsJObject(TestDataPath);

            var _jwtToken = _oauthAuthentication.GetOauthAuthentication(oauthURI, paramsBody);

            //Act   
            var response = _httpGetRequest.MakeGetRequest(testURI, RestSharp.Method.GET,_jwtToken);

            //Assert
            var result = ResponseContentAssertions.AssertStatusCode(response.StatusCode, expectedResult);
            Assert.True(result);
        }
    }
}
