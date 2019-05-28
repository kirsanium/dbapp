namespace DatabaseApp.Dtos.FinalType
{
    public class PostPutFinalTypeRequest
    {
        public string Name { get; set; }
        
        public Models.FinalType ToFinalType() =>
            new Models.FinalType
            {
                Name = Name
            };
    }
}