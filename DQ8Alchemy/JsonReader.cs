using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DQ8Alchemy
{
    public static class JsonReader
    {
        const string AlchemyJson = "https://pastebin.com/raw/0wj85eCG";
        const string MonsterJson = "https://pastebin.com/raw/yKQCs5Mg";

        public static List<Category> readAlchemyFile(string fileName)
        {
            using (WebClient wc = new WebClient())
            {
                var json = wc.DownloadString(AlchemyJson);
#pragma warning disable CS8603 // Possible null reference return.
                return JsonConvert.DeserializeObject<List<Category>>(json);
#pragma warning restore CS8603 // Possible null reference return.
            }

        }

        public static List<Monster> readMonsterFile(string fileName)
        {
            using (WebClient wc = new WebClient())
            {
                var json = wc.DownloadString(MonsterJson);
#pragma warning disable CS8603 // Possible null reference return.
                return JsonConvert.DeserializeObject<List<Monster>>(json);
#pragma warning restore CS8603 // Possible null reference return.
            }
        }
    }
}
