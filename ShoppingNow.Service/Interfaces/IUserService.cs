using Microsoft.AspNetCore.Identity;
using ShoppingNow.Service.Helper;

using ShoppingNow.Service.DTOs;

namespace ShoppingNow.Service.Interfaces
{
    public interface IUserService
    {
        public Task<ServiceResult<string>> Auhenticate (string username, string password);

        public Task<IdentityResult> AddUser(UserDto user);
    }
}
