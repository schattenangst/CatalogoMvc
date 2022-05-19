using System;
using Newtonsoft.Json;

namespace CatalogoMvc.Entities
{
    public class StudentEntity
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("idGroup")]
        public int IdGroup { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("surname")]
        public string Surname { get; set; }

        [JsonProperty("age")]
        public int Age { get; set; }

        [JsonProperty("birthday")]
        public DateTime Birthday { get; set; }

        [JsonProperty("tutor")]
        public string Tutor { get; set; }
    }
}
