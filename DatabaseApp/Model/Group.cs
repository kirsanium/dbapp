using System.Collections.Generic;
using Newtonsoft.Json;

namespace DatabaseApp.Models
{
    public class Group
    {
        public int Id { get; set; }
        public string GroupName { get; set; }
        public int StartYear { get; set; }
        public int EndYear { get; set; }
        
        [JsonIgnore]
        public Faculty Faculty { get; set; }
        public int FacultyId { get; set; }
        
        [JsonIgnore]
        public List<Student> Students { get; set; }
        public List<Lesson> Lessons { get; set; }
    }
}