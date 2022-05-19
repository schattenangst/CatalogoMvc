
namespace CatalogoMvc.Entities
{
    using Newtonsoft.Json;

    /// <summary>
    /// 
    /// </summary>
    public class GroupEntity
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("totalStudents")]
        public int TotalStudents { get; set; }
    }
}
