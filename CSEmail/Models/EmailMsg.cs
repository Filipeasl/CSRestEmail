namespace TodoApi.Models
{
    public class EmailMsg
    {
        public long Id { get; set; }
        public string eSmtpHost { get; set; }
        public string eFrom { get; set; }
        public string eTo { get; set; }
        public string eSubject { get; set; }
        public string eBody { get; set; }
        
    }
}