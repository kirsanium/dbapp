using System;
using System.Collections.Generic;

namespace DatabaseApp.Dtos
{
    public sealed class FacultyGetStudentsRequest
    {
        public int? Year { get; set; }
        public List<int> GroupIds { get; set; }
        public int? GenderId { get; set; }
        public int? BirthYear{ get; set; }
        public int? Age { get; set; }
        public bool? HasChildren { get; set; }
        public int? ChildrenAmount { get; set; }
        public bool? HasScholarship { get; set; }
        public float? ScholarshipAmount { get; set; }
    }
}