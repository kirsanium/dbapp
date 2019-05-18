namespace DatabaseApp.Models
{
    public class Thesis
    {
        public int Id { get; set; }
        public string Title { get; set; }
        
        public Student Student { get; set; }
        public int StudentId { get; set; }
        
        public Teacher Teacher { get; set; }
        public int TeacherId { get; set; }
    }
}