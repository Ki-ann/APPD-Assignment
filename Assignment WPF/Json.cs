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

        private static string exeFolder = System.IO.Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory);
        public static void serialize(object input)
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.NullValueHandling = NullValueHandling.Ignore;
            using (StreamWriter sw = new StreamWriter(exeFolder + "\\json.json"))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, input);
            }
        }
        public static List<Item> LoadJson()
        {
            
            using (StreamReader sw = new StreamReader(exeFolder + "\\json.json"))
            {
                string json =sw.ReadToEnd();
                Data.items = JsonConvert.DeserializeObject<List<Item>>(json);
            }
            return Data.items;

        }
       
        public static void clearJson()
        {
            var blank = new List<Item>();
            JsonSerializer serializer = new JsonSerializer();
            using (StreamWriter sw = new StreamWriter(exeFolder + "\\json.json"))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, blank);                //outputs [] blank
            }
        }
    }
}
