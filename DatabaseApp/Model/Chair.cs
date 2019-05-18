using System.Collections.Generic;

namespace DatabaseApp.Models
{
    public class Chair
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public Faculty Faculty { get; set; }
        public int FacultyId { get; set; }
        public List<Teacher> Teachers { get; set; }
    }
}