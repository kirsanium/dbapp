using System.Collections.Generic;

namespace DatabaseApp.Dtos
{
    public class GetTeachersConductingLessonsRequest
    {
        public int? DisciplineId { get; set; }
        public int? FacultyId { get; set; }
        public int? GroupId { get; set; }
        public int? Year { get; set; }
        public List<int> LessonTypeIds { get; set; }
        public List<int> Semesters { get; set; }
    }
}