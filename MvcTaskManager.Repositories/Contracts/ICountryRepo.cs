using MvcTaskManager.ViewModels;
using System.Threading.Tasks;

namespace MvcTaskManager.Repositories.Contracts
{
    public interface ICountryRepo
    {
        Task<ResponseViewModel> GeCountries();
    }
}
