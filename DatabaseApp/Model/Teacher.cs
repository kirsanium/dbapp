using System;
using System.Collections.Generic;

namespace DatabaseApp.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string MiddleName { get; set; }
        public DateTime BirthDate { get; set; }
        public int ChildrenAmount { get; set; }
        public float Salary { get; set; }
        
        public List<Dissertation> Dissertations { get; set; }

        public Chair Chair { get; set; }
        public int ChairId { get; set; }
        
        public Gender Gender { get; set; }
        public int GenderId { get; set; }
        
        public TeacherCategory TeacherCategory { get; set; }
        public int TeacherCategoryId { get; set; }
    }
}