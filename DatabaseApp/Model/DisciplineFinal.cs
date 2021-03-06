using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace DatabaseApp.Models
{
    public class DisciplineFinal
    {
        public int Id { get; set; }
        
        [JsonIgnore]
        public AcademicDiscipline Discipline { get; set; }
        public int DisciplineId { get; set; }
        
        [JsonIgnore]
        public FinalType FinalType { get; set; }
        public int FinalTypeId { get; set; }
        
        public DateTime Date { get; set; }
        
        [JsonIgnore]
        public List<FinalTeacher> FinalTeachers { get; set; }
    }
}