namespace DatabaseApp.Models
{
    public class Lesson
    {
        public int Id { get; set; }
        
        public Group Group { get; set; }
        public int GroupId { get; set; }
        
        public Curriculum Curriculum { get; set; }
        public int CurriculumId { get; set; }
        
        public Teacher Teacher { get; set; }
        public int TeacherId { get; set; }
    }
}