using System;

namespace DatabaseApp.Dtos.Group
{
    public class PostPutGroupRequest
    {
        public string GroupName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int FacultyId { get; set; }
        
        public Models.Group ToGroup() =>
            new Models.Group
            {
                GroupName = GroupName,
                StartDate = StartDate,
                EndDate = EndDate,
                FacultyId = FacultyId
            };
    }
}