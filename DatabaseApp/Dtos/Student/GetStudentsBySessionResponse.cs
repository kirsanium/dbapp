using System.Collections.Generic;
using DatabaseApp.Models;

namespace DatabaseApp.Dtos
{
    public sealed class GetStudentsBySessionResponse
    {
        public IEnumerable<Student> Students { get; set; }
        public int TotalElements { get; set; }
    }
}