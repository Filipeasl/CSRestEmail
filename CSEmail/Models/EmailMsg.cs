namespace TodoApi.Models
{
    public class EmailMsg
    {
        public long Id { get; set; }
        public string eSmtpHost { get; set; }
         public string eName { get; set; }
        public string eLogin { get; set; }
        public string ePassword { get; set; }
        public string eTo { get; set; }
        public string eSubject { get; set; }
        public string eBody { get; set; }
        
    }
}