namespace DatabaseApp.Dtos.DissertationType
{
    public class PostPutDissertationTypeRequest
    {
        public string Name { get; set; }
        
        public Models.DissertationType ToDissertationType() =>
            new Models.DissertationType
            {
                Name = Name
            };
    }
}