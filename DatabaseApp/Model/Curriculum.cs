namespace DatabaseApp.Models
{
    public class Curriculum
    {
        public int Id { get; set; }
        public int HoursAmount { get; set; }
        
        public DisciplineFinal DisciplineFinal { get; set; }
        public int DisciplineFinalId { get; set; }
        
        public LessonType LessonType { get; set; }
        public int LessonTypeId { get; set; }
    }
}