namespace DatabaseApp.Dtos.Lesson
{
    public class PostPutLessonRequest
    {
        public int GroupId { get; set; }
        public int CurriculumId { get; set; }
        public int TeacherId { get; set; }
        
        public Models.Lesson ToLesson() =>
            new Models.Lesson
            {
                GroupId = GroupId,
                CurriculumId = CurriculumId,
                TeacherId = TeacherId
            };
    }
}