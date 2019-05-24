using System.Collections.Generic;

namespace DatabaseApp.Dtos
{
    public class GetDissertationThemesRequest
    {
        public List<int> DissertationTypeIds { get; set; }
        public int? ChairId { get; set; }
        public int? FacultyId { get; set; }
    }
}