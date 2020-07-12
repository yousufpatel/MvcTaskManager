using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcTaskManager.ViewModels;
using MvcTaskManager.Repositories.Contracts;
using System.Collections.Generic;
using MvcTaskManager.DomainModels;


namespace MvcTaskManager.Repositories.Mocks
{
    public class ProjectRepoMock : IProjectRepo
    {
        private readonly MvcTaskManagerDbContext _dbContext;
        public ProjectRepoMock(MvcTaskManagerDbContext mvcTaskManagerDbContext)
        {
            _dbContext = mvcTaskManagerDbContext;
        }

        public async Task<IEnumerable<ProjectViewModel>> GetProjects()
        {
          
                System.Threading.Thread.Sleep(1000);

                IEnumerable<ProjectViewModel> ProjectsList = null;

                ProjectsList = await (from item in _dbContext.Projects
                                      select new ProjectViewModel
                                      {
                                          ProjectId = item.ProjectId,
                                          ProjectName = item.ProjectName,
                                          TeamSize = item.TeamSize,
                                          DateOfStart = item.DateOfStart,
                                          Active = item.Active,
                                          ClientLocationID = item.ClientLocationID,
                                          ClientLocation = _dbContext.ClientLocations.Where(x => x.ClientLocationID == item.ClientLocationID).FirstOrDefault(),
                                          Status = item.Status

                                      }).ToListAsync();
                           
                return ProjectsList;            
        }

        public async Task<ResponseViewModel> AddProject(ProjectViewModel project)
        {
            try
            {
                ResponseViewModel ResObj = new ResponseViewModel();
                Project ProjObj = new Project()
                {
                    ProjectName = project.ProjectName,
                    TeamSize = project.TeamSize,
                    DateOfStart = project.DateOfStart,
                    Active = project.Active,
                    ClientLocationID = project.ClientLocationID,
                    Status = project.Status

                };




                _dbContext.Add(ProjObj);
                await _dbContext.SaveChangesAsync();

                ProjectViewModel ProjDispObj = new ProjectViewModel()
                {
                    ProjectId = ProjObj.ProjectId,
                    ProjectName = ProjObj.ProjectName,
                    TeamSize = ProjObj.TeamSize,
                    DateOfStart = ProjObj.DateOfStart,
                    Active = ProjObj.Active,
                    ClientLocationID = ProjObj.ClientLocationID,
                    ClientLocation = _dbContext.ClientLocations.Where(x => x.ClientLocationID == ProjObj.ClientLocationID).FirstOrDefault(),
                    Status = ProjObj.Status

                };

                ResObj.Result = ProjDispObj;
                ResObj.Status = true;
                ResObj.Messege = "Project has been added successfully !";

                return ResObj;

            }
            catch (Exception ex)
            {
                ResponseViewModel ResObj = new ResponseViewModel()
                {
                    Status = false,
                    Messege = "Something Went Wrong !",
                    Result = ex

                };

                return ResObj;

            }
        }

        public async Task<ResponseViewModel> EditProject(int ProjectId, ProjectViewModel project)
        {
            try
            {
                ResponseViewModel ResObj = new ResponseViewModel();
                Project ProjObj = await _dbContext.Projects.FirstOrDefaultAsync(x => x.ProjectId == ProjectId);
                if (ProjObj != null)
                {
                    ProjObj.ProjectName = project.ProjectName;
                    ProjObj.TeamSize = project.TeamSize;
                    ProjObj.DateOfStart = project.DateOfStart;
                    ProjObj.Active = project.Active;
                    ProjObj.ClientLocationID = project.ClientLocationID;
                    ProjObj.Status = project.Status;
                    await _dbContext.SaveChangesAsync();

                    ProjectViewModel ProjDispObj = new ProjectViewModel()
                    {
                        ProjectId = ProjObj.ProjectId,
                        ProjectName = ProjObj.ProjectName,
                        TeamSize = ProjObj.TeamSize,
                        DateOfStart = ProjObj.DateOfStart,
                        Active = ProjObj.Active,
                        ClientLocationID = ProjObj.ClientLocationID,
                        ClientLocation = _dbContext.ClientLocations.Where(x => x.ClientLocationID == ProjObj.ClientLocationID).FirstOrDefault(),
                        Status = ProjObj.Status

                    };

                    ResObj.Result = ProjDispObj;
                    ResObj.Status = true;
                    ResObj.Messege = "Project details updated Successfully !";

                }
                else
                {
                    ResObj.Result = ProjObj;
                    ResObj.Status = false;
                    ResObj.Messege = "Cannot update the details please check";
                }

                return ResObj;
            }
            catch (Exception ex)
            {
                ResponseViewModel ResObj = new ResponseViewModel()
                {
                    Status = false,
                    Messege = "Something Went Wrong !",
                    Result = ex

                };

                return ResObj;
            }


        }

        public async Task<ResponseViewModel> DeleteProject(int ProjectId)
        {
            try
            {
                ResponseViewModel ResObj = new ResponseViewModel();
                Project ProjObj = await _dbContext.Projects.FirstOrDefaultAsync(x => x.ProjectId == ProjectId);
                if (ProjObj != null)
                {
                    _dbContext.Projects.Remove(ProjObj);
                    await _dbContext.SaveChangesAsync();

                    ResObj.Result = ProjObj;
                    ResObj.Status = true;
                    ResObj.Messege = "Project deleted Successfully !";

                }
                else
                {
                    ResObj.Result = ProjObj;
                    ResObj.Status = false;
                    ResObj.Messege = "cannot delete project please check";
                }

                return ResObj;
            }
            catch (Exception ex)
            {
                ResponseViewModel ResObj = new ResponseViewModel()
                {
                    Status = false,
                    Messege = "Something Went Wrong !",
                    Result = ex

                };

                return ResObj;
            }
        }

        public async Task<ResponseViewModel> SearchProject(string SearchBy, string SearchText)
        {
            try
            {
                ResponseViewModel ResObj = new ResponseViewModel();
                List<ProjectViewModel> ProjectList = null;

                switch (SearchBy)
                {
                    case "ProjectId":
                        ProjectList = await (from item in _dbContext.Projects
                                             where item.ProjectId.ToString().Contains(SearchText)
                                             select new ProjectViewModel
                                             {
                                                 ProjectId = item.ProjectId,
                                                 ProjectName = item.ProjectName,
                                                 TeamSize = item.TeamSize,
                                                 DateOfStart = item.DateOfStart,
                                                 Active = item.Active,
                                                 ClientLocationID = item.ClientLocationID,
                                                 ClientLocation = _dbContext.ClientLocations.Where(x => x.ClientLocationID == item.ClientLocationID).FirstOrDefault(),
                                                 Status = item.Status

                                             }).ToListAsync();
                        break;

                    case "ProjectName":
                        ProjectList = await (from item in _dbContext.Projects

                                             where item.ProjectName.Contains(SearchText)

                                             select new ProjectViewModel
                                             {
                                                 ProjectId = item.ProjectId,
                                                 ProjectName = item.ProjectName,
                                                 TeamSize = item.TeamSize,
                                                 DateOfStart = item.DateOfStart,
                                                 Active = item.Active,
                                                 ClientLocationID = item.ClientLocationID,
                                                 ClientLocation = _dbContext.ClientLocations.Where(x => x.ClientLocationID == item.ClientLocationID).FirstOrDefault(),
                                                 Status = item.Status

                                             }).ToListAsync();
                        break;

                    case "DateOfStart":
                        ProjectList = await (from item in _dbContext.Projects
                                             where item.DateOfStart.ToString().Contains(SearchText)
                                             select new ProjectViewModel
                                             {
                                                 ProjectId = item.ProjectId,
                                                 ProjectName = item.ProjectName,
                                                 TeamSize = item.TeamSize,
                                                 DateOfStart = item.DateOfStart,
                                                 Active = item.Active,
                                                 ClientLocationID = item.ClientLocationID,
                                                 ClientLocation = _dbContext.ClientLocations.Where(x => x.ClientLocationID == item.ClientLocationID).FirstOrDefault(),
                                                 Status = item.Status

                                             }).ToListAsync();
                        break;

                    case "TeamSize":
                        ProjectList = await (from item in _dbContext.Projects
                                             where item.TeamSize.ToString().Contains(SearchText)
                                             select new ProjectViewModel
                                             {
                                                 ProjectId = item.ProjectId,
                                                 ProjectName = item.ProjectName,
                                                 TeamSize = item.TeamSize,
                                                 DateOfStart = item.DateOfStart,
                                                 Active = item.Active,
                                                 ClientLocationID = item.ClientLocationID,
                                                 ClientLocation = _dbContext.ClientLocations.Where(x => x.ClientLocationID == item.ClientLocationID).FirstOrDefault(),
                                                 Status = item.Status

                                             }).ToListAsync();
                        break;
                }

                ResObj.Result = ProjectList;
                ResObj.Status = true;
                ResObj.Messege = "Project List";

                return ResObj;


            }
            catch (Exception ex)
            {
                ResponseViewModel ResObj = new ResponseViewModel()
                {
                    Status = false,
                    Messege = "Something Went Wrong !",
                    Result = ex

                };

                return ResObj;
            }
        }


        public async Task<ResponseViewModel> GetProjectByProjectName(string ProjectName)
        {
            try
            {
                ResponseViewModel ResObj = new ResponseViewModel();
                Project Project = await _dbContext.Projects.Where(x => x.ProjectName == ProjectName).FirstOrDefaultAsync();
                ResObj.Status = true;
                ResObj.Result = Project;
                ResObj.Messege = "Project Exist !";
                return ResObj;
            }
            catch (Exception ex)
            {
                ResponseViewModel ResObj = new ResponseViewModel()
                {
                    Status = false,
                    Messege = "Something went wrong !",
                    Result = ex

                };

                return ResObj;

            }
        }
    }
}
