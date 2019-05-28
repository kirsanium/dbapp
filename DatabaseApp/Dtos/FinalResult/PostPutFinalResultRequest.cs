namespace DatabaseApp.Dtos.FinalResult
{
    public class PostPutFinalResultRequest
    {
        public int StudentId { get; set; }
        public int DisciplineFinalId { get; set; }
        public string Grade { get; set; }
        
        public Models.FinalResult ToFinalResult() =>
            new Models.FinalResult
            {
                StudentId = StudentId,
                DisciplineFinalId = DisciplineFinalId,
                Grade = Grade
            };
    }
}