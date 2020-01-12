using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Models.AnimalModel {
    public class AnimalData {
        public List<AnimalModel> GetJsonData(string path) {
            return JsonConvert.DeserializeObject<List<AnimalModel>>(File.ReadAllText(path));
        }
    }

    public struct AnimalModel {
        public int ID { get; set; }
        public string name { get; set; }
        public string latinName { get; set; }
        public string family { get; set; }
        public string conservationStatus { get; set; }
        public string conservationStatusShorthand { get; set; }
        public string caughtBy { get; set; }
        public string date { get; set; }
        public string place { get; set; }
        public string pathToImage { get; set; }
    }
}