namespace DatabaseApp.Models
{
    public class AcademicAssignment
    {
        public int Id { get; set; }
        
        public Chair Chair { get; set; }
        public int ChairId { get; set; }

        public AcademicDiscipline Discipline { get; set; }
        public int DisciplineId { get; set; }
        
        public Group Group { get; set; }
        public int GroupId { get; set; }
    }
}