namespace FreeCourse.Web.Services.Interfaces
{
    public interface IClientCridentialTokenService
    {
        Task<String> GetToken();
    }
}
