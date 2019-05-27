using System;
using System.Collections.Generic;

namespace DatabaseApp.Dtos.Group
{
    public sealed class GetChairsLessonsRequest
    {
        public int? GroupId { get; set; }
        public int? FacultyId { get; set; }
        public List<int> Years { get; set; }
        public List<int> Semesters { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
    }
}