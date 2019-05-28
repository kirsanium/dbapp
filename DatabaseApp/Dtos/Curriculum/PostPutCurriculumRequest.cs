using System;

namespace DatabaseApp.Dtos.Curriculum
{
    public class PostPutCurriculumRequest
    {
        public int HoursAmount { get; set; }
        public int DisciplineFinalId { get; set; }
        public int LessonTypeId { get; set; }
        
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        
        public Models.Curriculum ToCurriculum() =>
            new Models.Curriculum
            {
                HoursAmount = HoursAmount,
                DisciplineFinalId = DisciplineFinalId,
                LessonTypeId = LessonTypeId,
                DateFrom = DateFrom,
                DateTo = DateTo
            };
    }
}