using System;
using Application.Users.DTOs;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class AccountController(SignInManager<User> signInManager) : BaseApiController
{

    [AllowAnonymous]
    [HttpPost("register")]
    public async Task<ActionResult> RegisterUser(RegisterUserDto registerUserDto)
    {
        var user = new User
        {
            DisplayName = registerUserDto.DisplayName,
            Email = registerUserDto.Email,
            UserName = registerUserDto.Email,
        };

        var result = await signInManager.UserManager.CreateAsync(user, registerUserDto.Password);

        if (result.Succeeded)
        {
            return Ok();
        }

        foreach (var error in result.Errors)
        {
            ModelState.AddModelError(error.Code, error.Description);
        }

        return ValidationProblem();
    }

    [AllowAnonymous]
    [HttpGet("user")]
    public async Task<ActionResult> GetUser()
    {
        var user = await signInManager.UserManager.GetUserAsync(User);

        if (user == null) return NoContent();

        UserDto userDto = new UserDto();
        userDto.Id = user.Id;
        userDto.DisplayName = user.DisplayName!;
        userDto.Email = user.Email!;
        userDto.ImageUrl = user.ImageUrl;
        userDto.Bio = user.Bio;
        userDto.PhoneNumber = user.PhoneNumber;
        userDto.EmailConfirmed = user.EmailConfirmed;
        userDto.PhoneNumberConfirmed = user.PhoneNumberConfirmed;

        return Ok(userDto);
    }

    [HttpPost("logout")]
    public async Task<ActionResult> Logout()
    {
        await signInManager.SignOutAsync();

        return NoContent();
    }
}
