using System.Collections.Generic;
using Newtonsoft.Json;

namespace DatabaseApp.Dtos
{
    public class TeacherHours
    {
        public int TeacherId { get; set; }
        public string TeacherName { get; set; }
        public List<DisciplineHours> DisciplineHours { get; set; }
        public int Hours { get; set; }
    }

    public class DisciplineHours
    {
        public int DisciplineId { get; set; }
        public string DisciplineName { get; set; }
        public List<LessonTypeHours> LessonTypeHours { get; set; }
        public int Hours { get; set; }
    }

    public class LessonTypeHours
    {
        public int LessonTypeId { get; set; }
        public string LessonTypeName { get; set; }
        public int Hours { get; set; }
    }
}