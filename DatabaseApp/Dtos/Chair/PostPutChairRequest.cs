namespace DatabaseApp.Dtos.Chair
{
    public sealed class PostPutChairRequest
    {
        public string Name { get; set; }
        public int FacultyId { get; set; }

        public Models.Chair ToChair()
        {
            return new Models.Chair
            {
                Name = Name,
                FacultyId = FacultyId
            };
        }
    }
}