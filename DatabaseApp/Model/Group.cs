using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace DatabaseApp.Models
{
    public class Group
    {
        public int Id { get; set; }
        public string GroupName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        
        [JsonIgnore]
        public Faculty Faculty { get; set; }
        public int FacultyId { get; set; }
        
        [JsonIgnore]
        public List<Student> Students { get; set; }
        public List<Lesson> Lessons { get; set; }
    }
}