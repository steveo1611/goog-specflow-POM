using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Configuration;
using System.IO;

namespace goog_specflow_POM.utils
{
    class ReadJSONFile
    {
        /// <summary>
        /// Get the JSON object by reading a JSON file
        /// </summary>
        public JObject GetJSONObject(string FilePath)
        {
            StreamReader file = null;
            file = File.OpenText(@FilePath);
            var reader = new JsonTextReader(file);
            JObject jsonobject = (JObject)JToken.ReadFrom(reader);
            return jsonobject;
        }

        /// <summary>
        /// Opens the json file.
        /// </summary>
        /// <param name="fileKey">The file key.</param>
        /// <returns></returns>
        public JObject OpenJsonFile(string fileKey)
        {
            try
            {
                //string baseDirectoryPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
                string filePath = ConfigurationManager.AppSettings.GetValues(fileKey)[0];
                StreamReader file = File.OpenText(filePath);
                var reader = new JsonTextReader(file);
                JObject jsonobject = (JObject)JToken.ReadFrom(reader);
                return jsonobject;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Not able to open Json file");
                return null;
            }
        }

        /// <summary>
        /// Reads the Json file.
        /// </summary>
        /// <param name="property">The property.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="fileKey">The file key.</param>
        /// <returns></returns>
        public string ReadJsonFile(string fileKey, string property, string propertyName)
        {
            try
            {
                JObject fileReader = OpenJsonFile(fileKey);
                return fileReader[property][propertyName].ToString();
            }
            catch (Exception e)
            {
                Console.WriteLine("Not able to read Json file" + e.Message);
                return string.Empty;
            }
        }

        /// <summary>
        /// Updates the json file.
        /// </summary>
        /// <param name="fileKey">The file key.</param>
        /// <param name="property">The property.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="value">The value.</param>
        public void UpdateJsonFile(string fileKey, string property, string propertyName, string value)
        {
            try
            {
                GC.Collect();
                string filepath = ConfigurationManager.AppSettings.GetValues(fileKey)[0];
                string jsonFile = File.ReadAllText(filepath);
                dynamic jsonObj = JsonConvert.DeserializeObject(jsonFile);
                jsonObj[property][propertyName] = value;
                string output = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
                File.WriteAllText(filepath, output);
            }
            catch (Exception e)
            {
                Console.WriteLine("Not able to update Json File " + e.Message);
            }
        }
    }
}
