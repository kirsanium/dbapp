using System;
using System.Collections.Generic;
using DatabaseApp.Models;
using Newtonsoft.Json;

namespace DatabaseApp.Dtos
{
    public class PostPutStudentRequest
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string MiddleName { get; set; }
        public DateTime BirthDate { get; set; }
        public int ChildrenAmount { get; set; }
        public float Scholarship { get; set; }
        public int FacultyId { get; set; }
        public int GroupId { get; set; }
        public int GenderId { get; set; }

        public Student ToStudent()
        {
            return new Student
            {
                FirstName = FirstName,
                SecondName = SecondName,
                MiddleName = MiddleName,
                BirthDate = BirthDate,
                ChildrenAmount = ChildrenAmount,
                Scholarship = Scholarship,
                FacultyId = FacultyId,
                GroupId = GroupId,
                GenderId = GenderId
            };
        }
    }
}