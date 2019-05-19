using Newtonsoft.Json;

namespace DatabaseApp.Models
{
    public class Lesson
    {
        public int Id { get; set; }
        
        [JsonIgnore]
        public Group Group { get; set; }
        public int GroupId { get; set; }
        
        [JsonIgnore]
        public Curriculum Curriculum { get; set; }
        public int CurriculumId { get; set; }
        
        [JsonIgnore]
        public Teacher Teacher { get; set; }
        public int TeacherId { get; set; }
    }
}