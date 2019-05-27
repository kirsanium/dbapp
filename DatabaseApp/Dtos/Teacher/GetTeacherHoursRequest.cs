namespace DatabaseApp.Dtos
{
    public class GetTeacherHoursRequest
    {
        public int? TeacherId { get; set; }
        public int? ChairId { get; set; }
        public int? Semester { get; set; }
    }
}