using System;

namespace DatabaseApp.Dtos.DisciplineFinal
{
    public class PostPutDisciplineFinalRequest
    {
        public int DisciplineId { get; set; }
        public int FinalTypeId { get; set; }
        
        public DateTime Date { get; set; }
        
        public Models.DisciplineFinal ToDisciplineFinal() =>
            new Models.DisciplineFinal
            {
                DisciplineId = DisciplineId,
                FinalTypeId = FinalTypeId,
                Date = Date
            };
    }
}