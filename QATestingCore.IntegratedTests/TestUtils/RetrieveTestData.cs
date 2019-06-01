using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;

namespace QATestingCore.IntegratedTests.TestUtils
{
    public static class RetrieveTestData
    {
        /// <summary>
        /// Read data from file json and returns data as string
        /// </summary>
        /// <param name="filePath">Represents the value from the parameter <see cref="filePath"/> where it is stowed</param>
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
        /// <param name="filePath">Represents the value from the parameter <see cref="filePath"/> where it is stowed</param>
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
        /// <param name="filePath">Represents the value from the parameter <see cref="filePath"/> where it is stowed</param>
        /// <returns></returns>
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
        /// <typeparam name="T">Represents the Model Class as type <ModelClassName></T></typeparam>
        /// <param name="filePath">Represents the value from the parameter <see cref="filePath"/> where it is stowed</param>
        /// <param name="jsonTokenName">Represents the name of the Json property</param>
        /// <returns></returns>
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
    }
}

