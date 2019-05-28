using System;
using DatabaseApp.Models;
using Newtonsoft.Json;

namespace DatabaseApp.Dtos.AcademicAssignment
{
    public class PostPutAcademicAssignmentRequest
    {
        public int ChairId { get; set; }
        public int DisciplineId { get; set; }
        public int GroupId { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }

        public Models.AcademicAssignment ToAcademicAssignment() =>
            new Models.AcademicAssignment
            {
                ChairId = ChairId,
                DisciplineId = DisciplineId,
                GroupId = GroupId,
                DateFrom = DateFrom,
                DateTo = DateTo
            };
    }
}