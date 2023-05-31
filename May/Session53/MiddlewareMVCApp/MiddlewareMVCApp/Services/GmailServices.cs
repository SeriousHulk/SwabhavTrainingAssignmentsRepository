namespace MiddlewareMVCApp.Services
{
    public class GmailServices : IEmailServices
    {
        public GmailServices()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Gmail Service Created");
            Console.ResetColor();
        }
        public Task SendEmail(string from, string to, string details)
        {
            return Task.Run(() =>
            {
                Console.WriteLine("Sending Email via Outlook Service");
                Console.WriteLine($"From {from},to {to}, Details {details}");
            });
        }

    }
}
