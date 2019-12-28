using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Models.AnimalModel {
    public class AnimalData {
        public List<AnimalModel> GetJsonData(string path) {
            return JsonConvert.DeserializeObject<List<AnimalModel>>(File.ReadAllText(path));
        }
    }

    public class AnimalModel {
        public string name { get; set; }
        public string pathToImage { get; set; }
    }
}