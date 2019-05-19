using Newtonsoft.Json;

namespace DatabaseApp.Models
{
    public class AcademicDiscipline
    {
        public int Id { get; set; }
        public int Semester { get; set; }
        public string Name { get; set; }
        
        [JsonIgnore]
        public Faculty Faculty { get; set; }
        public int FacultyId { get; set; }
    }
}