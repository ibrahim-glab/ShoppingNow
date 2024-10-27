using ShoppingNow.Service.Helper;
using ShoppingNow.Service.Interfaces;
using ShoppingNow.core.Entities;
using Microsoft.AspNetCore.Identity;
using ShoppingNow.core.Contracts;
using ShoppingNow.Service.DTOs;

namespace ShoppingNow.Service.Services
{
    public class UserServices : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IUnitOfWork _unitOfWork;

        public UserServices(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _unitOfWork = unitOfWork;
        }

        public  Task<ServiceResult<string>> Auhenticate(string username, string password)
        {
            throw new NotImplementedException();
        }

        public async Task<IdentityResult> AddUser(UserDto user)
        {
            await _unitOfWork.BeginTransaction();
            var appUser = user.ToApplicationUser();
            try
            {
                var result = await _userManager.CreateAsync(appUser, user.Password);
                if (!result.Succeeded)
                    return result;
                result = await _userManager.AddToRoleAsync(appUser, "Customer");
                if (!result.Succeeded)
                {
                    throw new Exception("Something went wrong when assign the user to role ");
                }

                await _unitOfWork.CommitTransaction();
                return result;
            }
            catch (Exception e)
            {
                await _unitOfWork.RollbackTransaction();
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
