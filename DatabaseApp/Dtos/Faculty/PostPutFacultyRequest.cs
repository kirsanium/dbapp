namespace DatabaseApp.Dtos.Faculty
{
    public class PostPutFacultyRequest
    {
        public string Name { get; set; }
        
        public Models.Faculty ToFaculty() =>
            new Models.Faculty
            {
                Name = Name
            };
    }
}