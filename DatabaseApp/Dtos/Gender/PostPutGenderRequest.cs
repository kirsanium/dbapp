namespace DatabaseApp.Dtos.Gender
{
    public class PostPutGenderRequest
    {
        public string Name { get; set; }
        
        public Models.Gender ToGender() =>
            new Models.Gender
            {
                Name = Name
            };
    }
}