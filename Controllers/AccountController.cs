using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SaplingStore.DTOs.Account;
using SaplingStore.Interfaces;
using SaplingStore.Models;

namespace SaplingStore.Controllers;
[Route("sapling-store/Account")]
[ApiController]
public class AccountController(
    UserManager<AppUser> userManager,
    ITokenService tokenService,
    SignInManager<AppUser> signInManager)
    : ControllerBase
{
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto loginDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var user = await userManager.Users.FirstOrDefaultAsync(x=>x.UserName == loginDto.Username);
        if(user == null) return Unauthorized("Invalid username");
        var result = await signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);
        if(!result.Succeeded)return Unauthorized("username or password is incorrect");
        var roles=await userManager.GetRolesAsync(user);
        var role=roles.FirstOrDefault();
        return Ok(new NewUserDto{UserName = user.UserName!,Email = user.Email!,Role =role! ,Token = tokenService.GenerateToken(user)});
        
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
    {
        try
        {
            if(!ModelState.IsValid)return BadRequest(ModelState);
            var appUser = new AppUser { Email = registerDto.Email, UserName = registerDto.UserName, };
            var createUser = await userManager.CreateAsync(appUser, registerDto.Password);
            if (createUser.Succeeded)
            {
                var role = !string.IsNullOrWhiteSpace(registerDto.Role) ? registerDto.Role : "User";
                var roleResult = await userManager.AddToRoleAsync(appUser, role);
                if(roleResult.Succeeded)
                {
                    return Ok(new NewUserDto(){Email = registerDto.Email, UserName = registerDto.UserName,Role = role,Token = tokenService.GenerateToken(appUser)});
                }
                else
                {
                    return StatusCode(500,roleResult.Errors);
                }
            }
            else
            {
                return StatusCode(500,createUser.Errors);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}