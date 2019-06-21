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
    public class ValuesControllerIntegratedTest
    {
        private UriBuilder testURI;
        private static IHttpGetRequest _httpGetRequest;
        private static IHttpPostRequest _httpPostRequest;
        private static IHttpPutRequest _httpPutRequest;
        private static IHttpDelRequest _httpDelRequest;
        private static IOAuthentication _oauthAuthentication;
        private string TestDataPath;

        public ValuesControllerIntegratedTest()
        {
            testURI = new UriBuilder("http://localhost:3000");

            _httpGetRequest = new HttpGetRequest();
            _httpPostRequest = new HttpPostRequest();
            _httpPutRequest = new HttpPutRequest();
            _httpDelRequest = new HttpDelRequest();
            _oauthAuthentication = new OAuthentication();

            TestDataPath = @"\TestsData\ValuesControllerTestsData.json";
        }

        [Theory(Skip = "specific reason")]
        [InlineData("/30605678839/05?rlz=1C1SQJL_pt-BRBR809BR809&biw=1366&bih=625&tbm=isch", HttpStatusCode.OK)]
        public void TC_01_AssertActionGETApiValuesByID_OK(string resourcePath, HttpStatusCode expectedResult)
        {
            //Arrange
            testURI.Path = resourcePath;

            //Act   
            var response = _httpGetRequest.MakeGetRequest(testURI);

            //Assert
            Assert.Equal(expectedResult, response.StatusCode);
        }

        [Theory(Skip = "specific reason")]
        [InlineData( "/Api/Value", HttpStatusCode.OK)]
        public void TC_02_AssertActionPOSTApiValuesByID_OK(string resourcePath, HttpStatusCode expectedResult)
        {
            //Arrange
            testURI.Path = resourcePath;
            
            var paramsBody = RetrieveTestData.GetResourceAsJObject(TestDataPath);

            //Act
            var response = _httpPostRequest.MakePostRequet(testURI, paramsBody);

            //Assert
            Assert.Equal(expectedResult, response.StatusCode);
        }

        [Theory]
        [InlineData("/userinformation/101", HttpStatusCode.OK)]
        public void TC_03_AssertActionPUTApiValuesByID_OK(string resourcePath, HttpStatusCode expectedResult)
        {
            //Arrange
            testURI.Path = resourcePath;

            var paramsBody = RetrieveTestData.GetResourceAsJObject(TestDataPath);

            //Act
            var response = _httpPutRequest.MakePutRequest(testURI, paramsBody);

            //Assert
            var result = StatusCodeAssertions.AssertStatusCode(response.StatusCode, expectedResult);
            Assert.True(result);
        }

        [Theory]
        [InlineData( "/userinformation/101", HttpStatusCode.OK)]
        public void TC_04_AssertActionDELApiValuesByID_OK(string resourcePath, HttpStatusCode expectedResult)
        {
            //Arrange
            testURI.Path = resourcePath;

            //Act   
            var response = _httpDelRequest.MakeDeleteRequest(testURI);

            //Assert
            var result = StatusCodeAssertions.AssertStatusCode(response.StatusCode, expectedResult);
            Assert.True(result);
        }

        [Theory]
        [InlineData("/userinformation?userId=101", HttpStatusCode.OK)]
        public void TC_05_AssertActionGETApiValuesByID_OK(string resourcePath, HttpStatusCode expectedResult)
        {
            //Arrange
            testURI.Path = resourcePath;

            //Act   
            var response = _httpGetRequest.MakeGetRequest(testURI);

            //Assert
            var result = StatusCodeAssertions.AssertStatusCode(response.StatusCode, expectedResult);
            Assert.True(result);
        }

        [Theory]
        [InlineData("/userinformation?userId=101", HttpStatusCode.OK)]
        public void TC_06_AssertActionGETApiValuesByID_OK_WithToken(string resourcePath, HttpStatusCode expectedResult)
        {
            //Arrange
            testURI.Path = resourcePath;

            UriBuilder oauthURI = new UriBuilder("http://localhost:3000") {
                Path = "/token"
            };

            var paramsBody = RetrieveTestData.GetResourceAsJObject(TestDataPath);

            var _jwtToken = _oauthAuthentication.BearerAuthentication(oauthURI, paramsBody);

            //Act   
            var response = _httpGetRequest.MakeGetRequest(testURI, HttpMethod.GET, _jwtToken);

            //Assert
            var result = StatusCodeAssertions.AssertStatusCode(response.StatusCode, expectedResult);
            Assert.True(result);
        }

        [Theory]
        [InlineData("/TestingDictionaryAssert", @"\TestsData\ExpectedTestParameters.json")]
        public void TC_07_AssertReturnedData(string resourcePath, string expectBodyParams)
        {
            //Arrange
            testURI.Path = resourcePath;

            var expectedObj = RetrieveTestData.GetResourceAsGeneric<ParamsBodyTest>(expectBodyParams);

            //Act
            var response = _httpGetRequest.MakeGetRequest(testURI, HttpMethod.GET);

            //Assert
            ResponseContentAssertions.AssertResponseDataObject<ParamsBodyTest>(response, expectedObj);
        }
    }
}
