
namespace CatalogoMvc.Entities
{
    using Newtonsoft.Json;

    /// <summary>
    /// 
    /// </summary>
    public class TeacherEntity
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("idGroup")]
        public int IdGroup { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("active")]
        public bool Active { get; set; }
    }
}
