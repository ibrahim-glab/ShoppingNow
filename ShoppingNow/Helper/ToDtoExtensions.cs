using ShoppingNow.Models;
using ShoppingNow.Service.DTOs;

namespace ShoppingNow.Helper;

public static class ToDtoExtensions
{

    public static UserDto ToUserDto(this RegisterViewModel model)
    {
        return new UserDto()
        {
            Email = model.Email,
            FirstName = model.FirstName,
            LastName = model.LastName,
            Password = model.Password
        };
    }
}