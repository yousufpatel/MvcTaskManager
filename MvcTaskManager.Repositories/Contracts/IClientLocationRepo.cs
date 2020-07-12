using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MvcTaskManager.ViewModels;

namespace MvcTaskManager.Repositories.Contracts
{
    public interface IClientLocationRepo
    {
        Task<ResponseViewModel> GetClientLocations();
    }

}
