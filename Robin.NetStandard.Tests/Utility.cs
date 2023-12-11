using System.Collections.Specialized;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Web;

namespace Slack.NetStandard.Tests
{
    public static class Utility
    {
        private const string ExamplesPath = "Examples";
        public static bool CompareJson(object actual, string expectedFile, params string[] exclude)
        {
            var actualJsonObject = JsonSerializer.SerializeToNode(actual).AsObject();
            var expected = File.ReadAllText(Path.Combine(ExamplesPath, expectedFile));
            var expectedJsonObject = JsonNode.Parse(expected).AsObject();

            foreach (var item in exclude)
            {
                RemoveFrom(actualJsonObject, item);
                RemoveFrom(expectedJsonObject, item);
            }

            var result = JsonNode.DeepEquals(expectedJsonObject, actualJsonObject);

            if (!result)
            {
                (expectedJsonObject,actualJsonObject) = OutputTrimEqual(expectedJsonObject, actualJsonObject);
                throw new InvalidOperationException("Actual object remnants: \n" + actualJsonObject + "\n\nExpected object remnants:\n" + expectedJsonObject);
            }

            return result;
        }

        private static (JsonObject? Expected,JsonObject? Actual) OutputTrimEqual(JsonObject? expectedJsonObject, JsonObject? actualJsonObject, bool output = true)
        {
            if (expectedJsonObject == null || actualJsonObject == null)
            {
                return (expectedJsonObject,actualJsonObject);
            }

            foreach (var prop in actualJsonObject)
            {
                if (JsonNode.DeepEquals(prop.Value, expectedJsonObject[prop.Key]))
                {
                    actualJsonObject.Remove(prop.Key);
                    expectedJsonObject.Remove(prop.Key);
                    continue;
                }

                if (actualJsonObject[prop.Key] is JsonArray && expectedJsonObject[prop.Key] is JsonArray)
                {
                    var result =
                        ((JsonArray) actualJsonObject[prop.Key]).Zip(((JsonArray) expectedJsonObject[prop.Key]),
                            (a, e) => (a, e)).ToArray();
                        foreach(var (a, e) in result)
                    {
                        if(JsonNode.DeepEquals(a, e))
                        {
                            ((JsonArray) actualJsonObject[prop.Key]).Remove(a);
                            ((JsonArray) expectedJsonObject[prop.Key]).Remove(e);
                            continue;
                        }

                        if (a is JsonObject joa && e is JsonObject joe)
                        {
                            OutputTrimEqual(joa, joe);
                        }
                    }
                }

                if (actualJsonObject[prop.Key] is JsonObject && expectedJsonObject[prop.Key] is JsonObject)
                {
                    (actualJsonObject,expectedJsonObject) = OutputTrimEqual(actualJsonObject[prop.Key] as JsonObject, expectedJsonObject[prop.Key] as JsonObject, false);
                }

            }

            if (output)
            {
                Console.WriteLine(expectedJsonObject.ToString());
                Console.WriteLine(actualJsonObject.ToString());
            }

            return (expectedJsonObject,actualJsonObject);
        }

        private static void RemoveFrom(JsonObject exclude, string item)
        {
            if (exclude.ContainsKey(item))
            {
                exclude.Remove(item);
            }

            foreach (var prop in exclude.Where(p => p.Value is JsonObject).Select(p => p.Value)
                .Cast<JsonObject>())
            {
                RemoveFrom(prop, item);
            }

            foreach (var prop in exclude.Where(p => p.Value is JsonArray).Select(p => p.Value).Cast<JsonArray>().SelectMany(a => a)
                .Where(c => c.GetValueKind() == JsonValueKind.Object).Cast<JsonObject>())
            {
                RemoveFrom(prop, item);
            }
        }
        public static T? ExampleFileContent<T>(string expectedFile)
        {
            var value = ExampleFileContent(expectedFile);
                return JsonSerializer.Deserialize<T>(value);
        }

        public static string ExampleFileContent(string expectedFile)
        {
            return File.ReadAllText(Path.Combine(ExamplesPath, expectedFile));
        }
    }
}