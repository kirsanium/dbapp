using DatabaseApp.Models;

namespace DatabaseApp.Dtos.Group
{
    public sealed class PostPutChairRequest
    {
        public string Name { get; set; }
        public int FacultyId { get; set; }

        public Chair ToChair()
        {
            return new Chair
            {
                Name = Name,
                FacultyId = FacultyId
            };
        }
    }
}