namespace DatabaseApp.Models
{
    public class FinalTeacher
    {
        public int Id { get; set; }
        
        public DisciplineFinal Final { get; set; }
        public int FinalId { get; set; }
        
        public Teacher Teacher { get; set; }
        public int TeacherId { get; set; }
    }
}