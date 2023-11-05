using Common.DTOs;

namespace Business.Authorization
{
    public interface IAuthorizationHelper
    {
        void AddNewUser(string username, string password);
        Login Login(string username, string password);
    }
}
