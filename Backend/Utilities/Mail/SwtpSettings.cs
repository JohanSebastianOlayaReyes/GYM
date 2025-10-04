namespace Utilities.Mail
{
    public class SwtpSettings
    {
        public string Server { get; set; }
        public int Port { get; set; }
        public string SenderEmail { get; set; }
        public string SenderName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool EnableSsl { get; set; }
        public int TimeOut { get; set; } = 30000; // 30 seconds
    }
}
