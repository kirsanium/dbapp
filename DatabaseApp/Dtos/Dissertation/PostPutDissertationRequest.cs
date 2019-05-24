using System;
using DatabaseApp.Models;
using Newtonsoft.Json;

namespace DatabaseApp.Dtos
{
    public class PostPutDissertationRequest
    {
        public string Theme { get; set; }
        public DateTime DatePresented { get; set; }
        public int TeacherId { get; set; }
        public int DissertationTypeId { get; set; }

        public Dissertation ToDissertation()
        {
            return new Dissertation
            {
                Theme = Theme,
                DatePresented = DatePresented,
                TeacherId = TeacherId,
                DissertationTypeId = DissertationTypeId
            };
        }
    }
}