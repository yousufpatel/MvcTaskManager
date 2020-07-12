using System.Threading.Tasks;
using MvcTaskManager.ViewModels;

namespace MvcTaskManager.Repositories.Contracts
{
    public interface IUserRepo
    {
        Task<UserViewModel> GetUserByUsernamePasswod(UserViewModel userViewModel);

        Task<UserViewModel> Register(UserViewModel userViewModel);

        Task<ResponseViewModel> GetUserByEmail(string Email);
    }
}
