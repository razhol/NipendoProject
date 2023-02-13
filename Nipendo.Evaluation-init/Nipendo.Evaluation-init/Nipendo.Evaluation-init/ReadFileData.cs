using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System.IO;
namespace Nipendo.Evaluation
{
    class ReadFileData
    {
        public Policy readfileData(string path)
        {
            string policyJson = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<Policy>(policyJson,
                new StringEnumConverter());
        }
    }
}
