using System;
using Newtonsoft.Json;

namespace DatabaseApp.Models
{
    public class AcademicAssignment
    {
        public int Id { get; set; }
        
        [JsonIgnore]
        public Chair Chair { get; set; }
        public int ChairId { get; set; }

        [JsonIgnore]
        public AcademicDiscipline Discipline { get; set; }
        public int DisciplineId { get; set; }
        
        [JsonIgnore]
        public Group Group { get; set; }

        public int GroupId { get; set; }
    }
}