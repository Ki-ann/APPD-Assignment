using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;

namespace Assignment_WPF
{
    class Json
    {

        private static string exeFolder = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);

        public static void SerializeItems(object input, string fileName)
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.NullValueHandling = NullValueHandling.Ignore;
            using (StreamWriter sw = new StreamWriter(exeFolder + fileName))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, input);
            }
        }
        public static dynamic DeserializeItems(object output, string fileName)
        {
            using (StreamReader sw = new StreamReader(exeFolder + fileName))
            {
                string json =sw.ReadToEnd();
                output = JsonConvert.DeserializeObject(json);
            }
            return output;
        }

       
        public static void ClearItems()
        {
            var blank = new List<Item>();
            JsonSerializer serializer = new JsonSerializer();
            using (StreamWriter sw = new StreamWriter(exeFolder + @"\json.json"))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, blank);                //outputs [] blank
            }
        }
    }
}
