using System.Collections.Generic;
using DatabaseApp.Models;

namespace DatabaseApp.Dtos
{
    public class GetTeachersConductingLessonsResponse
    {
        public IEnumerable<Teacher> Teachers { get; set; }
        public int TotalElements { get; set; }
    }
}