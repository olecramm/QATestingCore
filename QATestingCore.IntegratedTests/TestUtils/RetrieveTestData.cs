using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace QATestingCore.IntegratedTests.TestUtils
{
    public static class RetrieveTestData
    {

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

