using Newtonsoft.Json;

namespace DatabaseApp.Models
{
    public class Thesis
    {
        public int Id { get; set; }
        public string Title { get; set; }
        
        [JsonIgnore]
        public Student Student { get; set; }
        public int StudentId { get; set; }
        
        [JsonIgnore]
        public Teacher Teacher { get; set; }
        public int TeacherId { get; set; }
    }
}