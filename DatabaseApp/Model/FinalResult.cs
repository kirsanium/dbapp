namespace DatabaseApp.Models
{
    public class FinalResult
    {
        public int Id { get; set; }
        
        public Student Student { get; set; }
        public int StudentId { get; set; }
        
        public DisciplineFinal Final { get; set; }
        public int DisciplineFinalId { get; set; }
        
        public string Grade { get; set; }
    }
}