using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcTaskManager.Repositories.Contracts;
using MvcTaskManager.ViewModels;
using MvcTaskManager.DomainModels;
using System.Linq;


namespace MvcTaskManager.Repositories.Mocks
{
    public class ClientLocationRepoMock : IClientLocationRepo
    {
        private readonly MvcTaskManagerDbContext _dbContext;
        public ClientLocationRepoMock(MvcTaskManagerDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        async public Task<ResponseViewModel> GetClientLocations()
        {
            try
            {
                ResponseViewModel ResObj = new ResponseViewModel();
                IEnumerable<ClientLocationViewModel> list = null;


                list = await (from item in _dbContext.ClientLocations
                              select new ClientLocationViewModel()
                              {
                                  ClientLocationID = item.ClientLocationID,
                                  ClientLocationName = item.ClientLocationName

                              }).ToListAsync();

                ResObj.Status = true;
                ResObj.Result = list;
                ResObj.Messege = "Client Locatins List";

                return ResObj;

            }
            catch (Exception ex)
            {
                ResponseViewModel ResObj = new ResponseViewModel()
                {
                    Status = false,
                    Result = ex,
                    Messege = "Something went wrong !"
                };
                return ResObj;

            }
        }
    }
}
