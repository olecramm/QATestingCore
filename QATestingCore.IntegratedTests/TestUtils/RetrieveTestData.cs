using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;

namespace QATestingCore.IntegratedTests.TestUtils
{
    /// <summary>
    /// Contains methods to retrive test data from json files as different format responses
    /// </summary>
    public static class RetrieveTestData
    {
        /// <summary>
        /// Read data from file json and returns data as string
        /// </summary>
        /// <param name="filePath">Represents the value from the parameter where it is stowed Ex.: @"\folder\filename.json"</param>
        /// <returns>Returns a string object containing the data read from json file</returns>
        public static string GetResourceAsString(string filePath)
        {
            var baseDirectory = AppDomain.CurrentDomain.BaseDirectory + filePath;

            string dataString = string.Empty;

            using (StreamReader file = File.OpenText(baseDirectory))
            {
                dataString = file.ReadToEnd();
            }

            return dataString;
        }

        /// <summary>
        /// Read data from file json and returns data as Json Object
        /// </summary>
        /// <param name="filePath">Represents the value from the parameter where it is stowed Ex.: @"\folder\filename.json"</param>
        /// <returns>Returns a string object containing the data read from json file</returns>
        public static JObject GetResourceAsJObject(string filePath)
        {
            var baseDirectory = AppDomain.CurrentDomain.BaseDirectory + filePath;

            string dataString = string.Empty;

            using (StreamReader file = File.OpenText(baseDirectory))
            {
                dataString = file.ReadToEnd();
            }

            return JObject.Parse(dataString);
        }

        /// <summary>
        /// Read data from file json and returns data object as Model Class
        /// </summary>
        /// <typeparam name="T">Represents the Model Class as type T</typeparam>
        /// <param name="filePath">Represents the value from the parameter where it is stowed Ex.: @"\folder\filename.json"</param>
        /// <returns>Returns an object containing all data read from json file as Generics</returns>
        public static T GetResourceAsGeneric<T>(string filePath)
        {
            T jsonObjectData = default(T);

            var baseDirectory = AppDomain.CurrentDomain.BaseDirectory + filePath;

            using (StreamReader file = File.OpenText(baseDirectory))
            {
                JsonSerializer serializer = new JsonSerializer();
                jsonObjectData = (T)serializer.Deserialize(file, typeof(T));
            }
            return jsonObjectData;
        }

        /// <summary>
        /// Read Json file and extract information through a JToken informed and that represents a Model Class
        /// </summary>
        /// <param name="filePath">Represents the value from the parameter where it is stowed Ex.: Ex.: @"\folder\filename.json"</param>
        /// <param name="jsonTokenName">Represents the name of the Json property ex.: "T01234"</param>
        /// <returns>Returns an object containing only the  data read from json file</returns>
        public static object GetRequestParameters<T>(string filePath, string jsonTokenName)
        {
            var baseDirectory = AppDomain.CurrentDomain.BaseDirectory + filePath;
            var jsonFile = string.Empty;

            using (var file = File.OpenText(baseDirectory))
            {
                jsonFile = file.ReadToEnd();
            }

            var paramsJsonObj = JObject.Parse(jsonFile)
                                    .SelectToken(jsonTokenName)
                                    .ToObject<T>();
            return paramsJsonObj;
        }

        /// <summary>
        /// Read Json file and extract information through a JToken informed and that represents a JObject
        /// </summary>
        /// <param name="filePath">Represents the value from the parameter where it is stowed Ex.: Ex.: @"\folder\filename.json"</param>
        /// <param name="jsonTokenName">Represents the name of the Json property ex.: "T01234"</param>
        /// <returns>Returns an object containing only the  data read from json file</returns>
        public static JObject GetRequestParameters(string filePath, string jsonTokenName)
        {
            var baseDirectory = AppDomain.CurrentDomain.BaseDirectory + filePath;
            var jsonFile = string.Empty;

            using (var file = File.OpenText(baseDirectory))
            {
                jsonFile = file.ReadToEnd();
            }

            var paramsJsonObj = (JObject)JObject.Parse(jsonFile)
                                    .SelectToken(jsonTokenName);
            return paramsJsonObj;
        }
    }
}

