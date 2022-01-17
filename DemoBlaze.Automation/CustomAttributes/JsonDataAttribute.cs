using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Xunit.Sdk;

namespace DemoBlaze.Automation.CustomAttributes
{
    public class JsonDataAttribute :DataAttribute
    {
            private readonly string filePath;
            private readonly string propertyName;

            // filePath - absolute or relative path to the JSON file to load
            public JsonDataAttribute(string filePath) : this(filePath, null)
            { }

            // filePath - absolute or relative path to the JSON file to load
            // propertyName - name of the property on the JSON file that contains the data for the test
            public JsonDataAttribute(string filePath, string propertyName = null)
            {
                this.filePath = filePath;
                this.propertyName = propertyName;
            }

            public override IEnumerable<object[]> GetData(MethodInfo testMethod)
            {
                if (testMethod == null)
                {
                    throw new ArgumentNullException(nameof(testMethod));
                }

                // Get the absolute path to the JSON file
                var path = Path.IsPathRooted(filePath)
                    ? filePath
                    : Path.GetRelativePath(Directory.GetCurrentDirectory(), filePath);

                if (!File.Exists(path))
                {
                    throw new ArgumentException($"Could not find file at path: {path}");
                }

                // Load the file
                var fileData = File.ReadAllText(filePath, System.Text.Encoding.UTF8);

                if (string.IsNullOrEmpty(propertyName))
                {
                    //whole file is the data
                    return JsonConvert.DeserializeObject<List<object[]>>(fileData);
                }

                // Only use the specified property as the data
                var allData = JObject.Parse(fileData);
                var data = allData[propertyName];
                return data.ToObject<List<object[]>>();
            }
        }
    }

