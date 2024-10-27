using ShoppingNow.core.Entities;
using ShoppingNow.Service.DTOs;

namespace ShoppingNow.Service.Helper;

public static class  ToDtoExtension
{
    public static ApplicationUser ToApplicationUser(this UserDto user)
    {
        return new ApplicationUser
        {
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName,
        };
    }
}