using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using TextProcessorLibrary.Concordance;
using TextProcessorLibrary.TextModel;

namespace TextProcessorLibrary.TextSerializer
{
    public static class JsonTextSerializer
    {
        public static string Serialize(IText model) 
        {
            var sb = new StringBuilder();
            return JsonConvert.SerializeObject(model, Formatting.Indented);
        }

        public static string Serialize(IConcordance model) 
        {
            return JsonConvert.SerializeObject(model);
        }

        public static T Deserialize<T>(string json) //where T : IConcordance, IText
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
