using System;
using System.Collections.Generic;

namespace DatabaseApp.Dtos
{
    public sealed class GetStudentsRequest
    {
        public int? FacultyId { get; set; }
        public List<int> Years { get; set; }
        public List<int> GroupIds { get; set; }
        public int? GenderId { get; set; }
        public int? BirthYearFrom{ get; set; }
        public int? BirthYearTo{ get; set; }
        public int? AgeFrom { get; set; }
        public int? AgeTo { get; set; }
        public bool? HasChildren { get; set; }
        public int? ChildrenAmountFrom { get; set; }
        public int? ChildrenAmountTo { get; set; }
        public bool? HasScholarship { get; set; }
        public float? ScholarshipAmountFrom { get; set; }
        public float? ScholarshipAmountTo { get; set; }
    }
}