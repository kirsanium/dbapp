using System.Collections.Generic;
using Newtonsoft.Json;

namespace DatabaseApp.Models
{
    public class FinalResult
    {
        public int Id { get; set; }
        
        [JsonIgnore]
        public Student Student { get; set; }
        public int StudentId { get; set; }
        
        [JsonIgnore]
        public DisciplineFinal Final { get; set; }
        public int DisciplineFinalId { get; set; }
        
        public string Grade { get; set; }
    }
}