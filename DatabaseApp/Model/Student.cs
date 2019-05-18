using System;
using System.Collections.Generic;

namespace DatabaseApp.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string MiddleName { get; set; }
        public DateTime BirthDate { get; set; }
        public int ChildrenAmount { get; set; }
        public float Scholarship { get; set; }
        
        public Faculty Faculty { get; set; }
        public int FacultyId { get; set; }

        public Group Group { get; set; }
        public int GroupId { get; set; }
        
        public Gender Gender { get; set; }
        public int GenderId { get; set; }
        
        public List<FinalResult> FinalResults { get; set; }
    }
}