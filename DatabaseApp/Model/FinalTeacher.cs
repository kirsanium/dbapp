using Newtonsoft.Json;

namespace DatabaseApp.Models
{
    public class FinalTeacher
    {
        public int Id { get; set; }
        
        [JsonIgnore]
        public DisciplineFinal Final { get; set; }
        public int FinalId { get; set; }
        
        [JsonIgnore]
        public Teacher Teacher { get; set; }
        public int TeacherId { get; set; }
        
        [JsonIgnore]
        public Group Group { get; set; }
        public int GroupId { get; set; }
    }
}