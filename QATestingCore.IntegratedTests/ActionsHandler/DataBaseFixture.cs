using System;
using Newtonsoft.Json.Linq;
using QATestingCore.IntegratedTests.TestUtils;

namespace QATestingCore.IntegratedTests.ActionsHandler
{
    /// <summary>
    /// Contains method to load the testdata only once and make it available along all test's suit
    /// </summary>
    public class DatabaseFixture : IDisposable
    {
        /// <summary>
        /// Test data Object 
        /// </summary>
        public JObject BaseEnvironmentObj { get; private set; }

        /// <summary>
        /// Constructor that loads the "BaseEnvironment.json" parameters
        /// </summary>
        public DatabaseFixture()
        {
            try
            {
                BaseEnvironmentObj = RetrieveTestData.GetResourceAsJObject("BaseEnvironment.json");
            }
            catch (System.Exception e)
            {
                throw new System.Exception(e.Message);
            }
        }

        /// <summary>
        /// Dispose memory after all tests execution
        /// </summary>
        public void Dispose()
        {
            Console.WriteLine("SomeFixture: Disposing SomeFixture");
        }
    }
}
