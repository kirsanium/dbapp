using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace DatabaseApp.Models
{
    public class Curriculum
    {
        public int Id { get; set; }
        public int HoursAmount { get; set; }
        
        [JsonIgnore]
        public DisciplineFinal DisciplineFinal { get; set; }
        public int DisciplineFinalId { get; set; }
        
        [JsonIgnore]
        public LessonType LessonType { get; set; }
        public int LessonTypeId { get; set; }

        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        
        [JsonIgnore]
        public List<Lesson> Lessons { get; set; }
    }
}