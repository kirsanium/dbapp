using System.Collections.Generic;

namespace DatabaseApp.Dtos
{
    public class GetThesisTeachersRequest
    {
        public int? ChairId { get; set; }
        public int? FacultyId { get; set; }
        public List<int> TeacherCategoryIds { get; set; }
    }
}