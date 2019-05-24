using System;
using System.Collections.Generic;
using DatabaseApp.Dtos;
using Newtonsoft.Json;

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
        
        [JsonIgnore]
        public Faculty Faculty { get; set; }
        public int FacultyId { get; set; }

        [JsonIgnore]
        public Group Group { get; set; }
        public int GroupId { get; set; }
        
        [JsonIgnore]
        public Gender Gender { get; set; }
        public int GenderId { get; set; }
        
        [JsonIgnore]
        public List<FinalResult> FinalResults { get; set; }
    }
}