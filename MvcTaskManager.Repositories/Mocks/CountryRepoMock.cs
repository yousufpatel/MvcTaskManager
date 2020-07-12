using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using MvcTaskManager.ViewModels;
using MvcTaskManager.Repositories.Contracts;


using MvcTaskManager.DomainModels;

namespace MvcTaskManager.Repositories.Mocks
{
    public class CountryRepoMock : ICountryRepo
    {
        private readonly MvcTaskManagerDbContext _dbContext;
        public CountryRepoMock(MvcTaskManagerDbContext mvcTaskManagerDbContext)
        {
            _dbContext = mvcTaskManagerDbContext;
        }
        public async Task<ResponseViewModel> GeCountries()
        {
            try
            {
                ResponseViewModel ResObj = new ResponseViewModel();
                ResObj.Result = await (from item in _dbContext.Countries
                                 select new CountryViewModel
                                 {
                                     CountryID = item.CountryID,
                                     CountryName = item.CountryName

                                 }).ToListAsync();

                ResObj.Status = true;
                ResObj.Messege = "Country list";

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
    }
}
