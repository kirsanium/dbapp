using System;
using Newtonsoft.Json;

namespace DatabaseApp.Models
{
    public class Dissertation
    {
        public int Id { get; set; }
        
        public string Theme { get; set; }
        public DateTime DatePresented { get; set; }
        
        [JsonIgnore]
        public Teacher Teacher { get; set; }
        public int TeacherId { get; set; }
        
        [JsonIgnore]
        public DissertationType DissertationType { get; set; }
        public int DissertationTypeId { get; set; }
    }
}