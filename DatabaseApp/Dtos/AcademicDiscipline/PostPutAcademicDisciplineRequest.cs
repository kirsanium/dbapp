namespace DatabaseApp.Dtos.AcademicDiscipline
{
    public class PostPutAcademicDisciplineRequest
    {
        public int Semester { get; set; }
        public string Name { get; set; }
        public int FacultyId { get; set; }
        
        public Models.AcademicDiscipline ToAcademicDiscipline() =>
            new Models.AcademicDiscipline
            {
                Semester = Semester,
                Name = Name,
                FacultyId = FacultyId
            };
    }
}