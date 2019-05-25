using System.Collections.Generic;

namespace DatabaseApp.Dtos.Group
{
    public class GetChairsLessonsRequest
    {
        public int? GroupId { get; set; }
        public int? FacultyId { get; set; }
        public List<int> Years { get; set; }
        public List<int> Semesters { get; set; }
    }
}