using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MvcTaskManager.Repositories.Contracts;
using MvcTaskManager.Repositories.Mocks;
using MvcTaskManager.ViewModels;
using MvcTaskManager.DomainModels;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MvcTaskManager.Repositories.Mocks
{
    public class UserRepoMock : IUserRepo
    {
        private readonly MvcTaskManagerDbContext _dbContext;
        public UserRepoMock(MvcTaskManagerDbContext mvcTaskManagerDbContext)
        {
            _dbContext = mvcTaskManagerDbContext;
        }

        public async Task<ResponseViewModel> GetUserByEmail(string Email)
        {
            try
            {
                ResponseViewModel ResObj = new ResponseViewModel();
                UserViewModel UserObj = await (from item in _dbContext.Users
                                               where item.Email == Email
                                               select new UserViewModel
                                               {
                                                   Id = item.Id,
                                                   Email = item.Email
                                               }).FirstOrDefaultAsync();

                if (UserObj != null)
                {
                    ResObj.Status = true;
                    ResObj.Result = UserObj;
                    ResObj.Messege = "User Exist";
                }
                else
                {
                    ResObj.Status = false;
                    ResObj.Result = UserObj;
                    ResObj.Messege = "User Does Not Exist";
                }

                return ResObj;



            }
            catch (Exception ex)
            {
                ResponseViewModel ResObj = new ResponseViewModel()
                {
                    Status = false,
                    Result = ex,
                    Messege = "Something Went Wrong !"
                };

                return ResObj;
            }

        }

        public async Task<UserViewModel> GetUserByUsernamePasswod(UserViewModel userViewModel)
        {
            try
            {

                UserViewModel UserObj = await (from item in _dbContext.Users
                                               where item.UserName == userViewModel.UserName
                                               && item.Password == userViewModel.Password
                                               select new UserViewModel
                                               {
                                                   Id = item.Id,
                                                   PersonName = new PersonName { FirstName = item.FirstName, LastName = item.LastName },
                                                   Email = item.Email,
                                                   UserName = item.UserName,
                                                   RoleId = item.RoleId
                                               }).FirstOrDefaultAsync();

                return UserObj;
            }


            catch (Exception ex)
            {

                return null;
            }


        }

        public async Task<UserViewModel> Register(UserViewModel userViewModel)
        {
            try
            {
                User UserObj = new User()
                {
                    FirstName = userViewModel.PersonName.FirstName,
                    LastName = userViewModel.PersonName.LastName,
                    UserName = userViewModel.Email,
                    Password = userViewModel.Password,
                    Email = userViewModel.Email,
                    Mobile = userViewModel.Mobile,
                    DateOfBirth = userViewModel.DateOfBirth,
                    Gender = userViewModel.Gender,
                    CountryID = userViewModel.CountryID,
                    ReceiveNewsLetters = userViewModel.ReceiveNewsLetters,
                    RoleId = 2
                };

                _dbContext.Add(UserObj);



                await _dbContext.SaveChangesAsync();

                foreach (var item in userViewModel.Skills)
                {
                    Skill SkillObj = new Skill()
                    {
                        SkillName = item.SkillName,
                        SkillLevel = item.SkillName,
                        Id = UserObj.Id
                    };

                    _dbContext.Skills.Add(SkillObj);
                    await _dbContext.SaveChangesAsync();
                }

                UserViewModel Obj = new UserViewModel()
                {
                    Id = UserObj.Id,
                    PersonName = new PersonName { FirstName = UserObj.FirstName, LastName = UserObj.LastName },
                    Email = UserObj.Email,
                    UserName = UserObj.UserName,
                    RoleId = UserObj.RoleId
                };

                return Obj;



            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
