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
    public class ValuesControllerIntegratedTest : IClassFixture<DatabaseFixture>
    {
        readonly DatabaseFixture fixture;
        private UriBuilder testURI;
        private static IHttpGetRequest _httpGetRequest = new HttpGetRequest();
        private static IHttpPostRequest _httpPostRequest = new HttpPostRequest();
        private static IHttpPutRequest _httpPutRequest = new HttpPutRequest();
        private static IHttpDelRequest _httpDelRequest = new HttpDelRequest();
        private static IOAuthentication _oauthAuthentication = new OAuthentication();
        private string TestDataPath;

        public ValuesControllerIntegratedTest(DatabaseFixture fixture)
        {
            this.fixture = fixture;
            testURI = new UriBuilder("http://localhost:3000");
            TestDataPath = @"\TestsData\ValuesControllerTestsData.json";
        }

        [Theory]
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

        [Theory]
        [InlineData("TESTE01", "/Api/Value", HttpStatusCode.OK)]
        public void TC_02_AssertActionPOSTApiValuesByID_OK(string tesCaseName, string resourcePath, HttpStatusCode expectedResult)
        {
            //Arrange
            testURI.Path = resourcePath;

            var paramsBody = RetrieveTestData.GetRequestParameters(TestDataPath, tesCaseName);

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
        [InlineData("/userinformation/101", HttpStatusCode.OK)]
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
        [InlineData("/userinformation?userId=101", HttpStatusCode.Created)]
        public void TC_06_AssertActionGETApiValuesByID_OK_WithToken(string resourcePath, HttpStatusCode expectedResult)
        {
            //Arrange
            testURI.Path = resourcePath;

            var endpoint = fixture.BaseEnvironmentObj["endpoints"]["service_1"].ToString();

            UriBuilder oauthURI = new UriBuilder(endpoint)
            {
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
