using System.Collections.Generic;

namespace DatabaseApp.Models
{
    public class Faculty
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public List<Group> Groups { get; set; }
        public List<Chair> Chairs { get; set; }
        public List<AcademicDiscipline> AcademicDisciplines { get; set; }
    }
}