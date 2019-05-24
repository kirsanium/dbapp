using System.Collections.Generic;

namespace DatabaseApp.Dtos
{
    public class GetDissertationThemesResult
    {
        public List<string> Themes { get; set; }
        public int TotalElements { get; set; }
    }
}