using System;
using System.Collections.Generic;

namespace DatabaseApp.Dtos
{
    public sealed class GetTeachersRequest
    {
        public List<int> ChairIds { get; set; }
        public int? GenderId { get; set; }
        public int? BirthYearFrom{ get; set; }
        public int? BirthYearTo{ get; set; }
        public int? AgeFrom { get; set; }
        public int? AgeTo { get; set; }
        public bool? HasChildren { get; set; }
        public int? ChildrenAmountFrom { get; set; }
        public int? ChildrenAmountTo { get; set; }
        public float? SalaryAmountFrom { get; set; }
        public float? SalaryAmountTo { get; set; }
        
        public bool? isGraduateStudent { get; set; }
        
        public List<int> DissertationTypeIds { get; set; }
        
        public List<int> TeacherCategoryIds { get; set; }
        
        public DateTime? DateDissertationPresentedFrom { get; set; }
        
        public DateTime? DateDissertationPresentedTo { get; set; }
    }
}