namespace DatabaseApp.Models
{
    public class DisciplineFinal
    {
        public int Id { get; set; }
        
        public AcademicDiscipline Discipline { get; set; }
        public int DisciplineId { get; set; }
        
        public FinalType FinalType { get; set; }
        public int FinalTypeId { get; set; }
    }
}