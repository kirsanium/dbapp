using System.Collections.Generic;
using Newtonsoft.Json;

namespace DatabaseApp.Models
{
    public class Faculty
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        [JsonIgnore]
        public List<Group> Groups { get; set; }
        [JsonIgnore]
        public List<Chair> Chairs { get; set; }
        [JsonIgnore]
        public List<AcademicDiscipline> AcademicDisciplines { get; set; }
    }
}