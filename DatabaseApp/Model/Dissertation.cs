namespace DatabaseApp.Models
{
    public class Dissertation
    {
        public int Id { get; set; }
        
        public Teacher Teacher { get; set; }
        public int TeacherId { get; set; }
        
        public DissertationType DissertationType { get; set; }
        public int DissertationTypeId { get; set; }
    }
}