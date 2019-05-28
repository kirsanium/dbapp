namespace DatabaseApp.Dtos.TeacherCategory
{
    public class PostPutTeacherCategoryRequest
    {
        public string Name { get; set; }
        
        public Models.TeacherCategory ToTeacherCategory() =>
            new Models.TeacherCategory
            {
                Name = Name
            };
    }
}