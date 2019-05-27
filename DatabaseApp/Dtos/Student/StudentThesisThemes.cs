using System.Collections.Generic;
using DatabaseApp.Models;

namespace DatabaseApp.Dtos
{
    public class StudentThesisThemes
    {
        public Student Student { get; set; }
        public List<string> Themes { get; set; }
    }
}