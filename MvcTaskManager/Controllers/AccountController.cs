using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MvcTaskManager.ViewModels;
using MvcTaskManager.Repositories.Contracts;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MvcTaskManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        public readonly IUserRepo _userRepo;
        public AccountController(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }


        [HttpPost, Route("Authenticate")]
        public async Task<IActionResult> Authenticate(UserViewModel userViewModel)
        {
            ResponseViewModel ResObj = new ResponseViewModel();
            UserViewModel MyUser = await _userRepo.GetUserByUsernamePasswod(userViewModel);

            try
            {
                if (userViewModel.UserName == null || userViewModel.Password == null)
                {
                    ResObj.Status = false;
                    ResObj.Result = new { Token = "", User = "" };
                    ResObj.Messege = "User And Password Fields Cannot Be Left Blank";
                }

                else if (MyUser == null)
                {
                    ResObj.Status = false;
                    ResObj.Result = new { Token = "", User = "" };
                    ResObj.Messege = "Invalid Credentials!";
                }
                else
                {
                    var claims = new[] {
                     new Claim(ClaimTypes.NameIdentifier, MyUser.Id.ToString()),
                    };


                    var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("KeyForSignInSecret@1234"));
                    var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                    var tokeOptions = new JwtSecurityToken(
                    issuer: "http://localhost:60487",
                    audience: "http://localhost:60487",
                    claims: claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: signinCredentials
                );

                    var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                    var LoginObject = new { Token = tokenString, User = MyUser };

                    ResObj.Status = true;
                    ResObj.Result = LoginObject;
                    ResObj.Messege = "Successfully logged in !";

                }

                return Ok(ResObj);
            }


            catch (Exception ex)
            {
                ResObj.Status = false;
                ResObj.Result = ex;
                ResObj.Messege = "Something Went Wrong !";
                return BadRequest(ResObj);
            }
        }

        [HttpPost, Route("Register")]
        public async Task<IActionResult> Register(UserViewModel userViewModel)
        {
            try
            {
                UserViewModel UserObj = await _userRepo.Register(userViewModel);
                var claims = new[] {
                     new Claim(ClaimTypes.NameIdentifier, UserObj.Id.ToString()),
                    };


                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("KeyForSignInSecret@1234"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var tokeOptions = new JwtSecurityToken(
                issuer: "http://localhost:60487",
                audience: "http://localhost:60487",
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: signinCredentials
                );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                var LoginObject = new { Token = tokenString, User = UserObj };

                ResponseViewModel ResObj = new ResponseViewModel()
                {
                    Status = true,
                    Messege = "User Registered Successfully !",
                    Result = LoginObject
                };

                return Ok(ResObj);
            }
            catch (Exception ex)
            {
                ResponseViewModel ResObj = new ResponseViewModel()
                {
                    Status = false,
                    Messege = "Something Went Wrong !",
                    Result = ex
                };

                return BadRequest(ResObj);
            }
        }

        [HttpGet,Route("GetUserByEmail/{Email}")]
        public async Task<IActionResult> GetUserByEmail(string Email)
        {
            try
            {
                ResponseViewModel ResObj = await _userRepo.GetUserByEmail(Email);
                if (ResObj.Status == false && ResObj.Messege == "Something Went Wrong !")
                {
                    
                    return BadRequest(ResObj);
                }
                else
                {
                    return Ok(ResObj);
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}