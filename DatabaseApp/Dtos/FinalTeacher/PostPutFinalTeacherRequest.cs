namespace DatabaseApp.Dtos.FinalTeacher
{
    public class PostPutFinalTeacherRequest
    {
        public int FinalId { get; set; }
        public int TeacherId { get; set; }
        public int GroupId { get; set; }
        
        public Models.FinalTeacher ToFinalTeacher() =>   
            new Models.FinalTeacher
            {
                FinalId = FinalId,
                TeacherId = TeacherId,
                GroupId = GroupId
            };
    }
}