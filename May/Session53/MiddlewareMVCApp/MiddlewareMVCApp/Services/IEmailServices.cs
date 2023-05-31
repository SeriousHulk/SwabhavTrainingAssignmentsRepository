namespace MiddlewareMVCApp.Services
{
    public interface IEmailServices
    {
        public Task SendEmail(string from,string to,string details);
    }
}
