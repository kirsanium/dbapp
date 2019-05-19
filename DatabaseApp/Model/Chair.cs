using System.Collections.Generic;
using Newtonsoft.Json;

namespace DatabaseApp.Models
{
    public class Chair
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        [JsonIgnore]
        public Faculty Faculty { get; set; }
        public int FacultyId { get; set; }
        
        [JsonIgnore]
        public List<Teacher> Teachers { get; set; }
    }
}