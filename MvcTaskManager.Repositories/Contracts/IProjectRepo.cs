using MvcTaskManager.ViewModels;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace MvcTaskManager.Repositories.Contracts
{
    public interface IProjectRepo
    {
        Task<IEnumerable<ProjectViewModel>> GetProjects();
        Task<ResponseViewModel> AddProject(ProjectViewModel project);

        Task<ResponseViewModel> EditProject(int ProjectId,ProjectViewModel project);

        Task<ResponseViewModel> DeleteProject(int ProjectId);

        Task<ResponseViewModel> SearchProject(string SearchBy,string SearchText);

        Task<ResponseViewModel> GetProjectByProjectName(string ProjectName);
    }
}
