namespace DatabaseApp.Dtos.Thesis
{
    public class PostPutThesisRequest
    {
        public string Title { get; set; }
        public int StudentId { get; set; }
        public int TeacherId { get; set; }
        
        public Models.Thesis ToThesis() =>
            new Models.Thesis
            {
                TeacherId = TeacherId,
                Title = Title,
                StudentId = StudentId
            };
    }
}