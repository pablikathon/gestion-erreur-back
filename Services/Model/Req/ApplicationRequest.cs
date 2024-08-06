    namespace Services.Models.Req
    {
        public class ApplicationRequest{
            public string? Id { get; set; }
            public string? Title { get; set; }  
            public DateTime? CreatedAt;
            public ApplicationRequest(){
                
            }
        }
    }