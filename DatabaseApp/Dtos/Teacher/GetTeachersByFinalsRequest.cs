using System.Collections.Generic;

namespace DatabaseApp.Dtos
{
    public class GetTeachersByFinalsRequest
    {
        public List<int> GroupIds { get; set; }
        public List<int> DisciplineIds { get; set; }
        public List<int> Semesters { get; set; }
    }
}