using System;
using System.Collections.Generic;
using DatabaseApp.Models;
using Newtonsoft.Json;

namespace DatabaseApp.Dtos
{
    public class PostPutTeacherRequest
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string MiddleName { get; set; }
        public DateTime BirthDate { get; set; }
        public int ChildrenAmount { get; set; }
        public float Salary { get; set; }
        public bool GraduateStudent { get; set; }
        public int ChairId { get; set; }
        public int GenderId { get; set; }
        public int TeacherCategoryId { get; set; }

        public Teacher ToTeacher()
        {
            return new Teacher
            {
                FirstName = FirstName,
                SecondName = SecondName,
                MiddleName = MiddleName,
                BirthDate = BirthDate,
                ChildrenAmount = ChildrenAmount,
                Salary = Salary,
                GraduateStudent = GraduateStudent,
                ChairId = ChairId,
                GenderId = GenderId,
                TeacherCategoryId = TeacherCategoryId
            };
        }
    }
}