namespace DatabaseApp.Dtos.LessonType
{
    public class PostPutLessonTypeRequest
    {
        public string Name { get; set; }
        
        public Models.LessonType ToLessonType() =>
            new Models.LessonType
            {
                Name = Name
            };
    }
}