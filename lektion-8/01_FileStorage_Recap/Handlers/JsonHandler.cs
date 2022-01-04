using _01_FileStorage_Recap.Abstracts;
using _01_FileStorage_Recap.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_FileStorage_Recap.Handlers
{
    public class JsonHandler : FileHandler
    {
        public JsonHandler(string filePath)
        {
            _filePath = filePath;
        }

        public override void ReadFromFile()
        {
            using var sr = new StreamReader(_filePath);
            _customers = JsonConvert.DeserializeObject<List<Customer>>(sr.ReadToEnd());
        }

        public override void WriteToFile()
        {
            using var sw = new StreamWriter(_filePath);
            sw.WriteLine(JsonConvert.SerializeObject(_customers));
        }
    }
}
