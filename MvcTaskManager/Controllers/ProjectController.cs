using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MvcTaskManager.Repositories.Contracts;
using MvcTaskManager.ViewModels;
using System.Collections.Generic;


namespace MvcTaskManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectRepo _projectRepo;
        public ProjectController(IProjectRepo project)
        {
            _projectRepo = project;
        }

        [HttpGet, Route("GetProjects")]
        public async Task<ActionResult> GetProjects()
        {
            try
            {
                ResponseViewModel ResObj = new ResponseViewModel();
                IEnumerable<ProjectViewModel> Projects = await _projectRepo.GetProjects();
                if (Projects != null)
                {
                    ResObj.Status = true;
                    ResObj.Result = Projects;
                    ResObj.Messege = "Projects List";

                }
                else
                {
                    ResObj.Status = false;
                    ResObj.Result = Projects;
                    ResObj.Messege = "No Projects Found";
                }

                return Ok(ResObj);
            }
            catch (Exception ex)
            {

                ResponseViewModel ResObj = new ResponseViewModel()
                {
                    Status = false,
                    Result = ex,
                    Messege = "Something Went Wrong !"
                };

                return BadRequest(ResObj);
            }

        }

        [HttpPost, Route("AddProject")]
        public async Task<IActionResult> AddProject(ProjectViewModel project)
        {
            ResponseViewModel ResObj = await _projectRepo.AddProject(project);
            if (ResObj.Status == false && ResObj.Messege == "Something Went Wrong !")
            {
                return BadRequest(ResObj);
            }
            else
            {
                return Ok(ResObj);
            }
        }

        [HttpPut, Route("EditProject/{ProjectId}")]
        public async Task<IActionResult> EditProject(int ProjectId, ProjectViewModel project)
        {
            try
            {
                ResponseViewModel ResObj = await _projectRepo.EditProject(ProjectId, project);
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

        [HttpDelete, Route("DeleteProject/{ProjectId}")]
        public async Task<IActionResult> DeleteProject(int ProjectId)
        {
            try
            {
                ResponseViewModel ResObj = await _projectRepo.DeleteProject(ProjectId);
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

        [HttpGet, Route("SearchProject/{SearchBy}/{SearchText}")]
        public async Task<IActionResult> SearchProject(string SearchBy, string SearchText)
        {
            try
            {
                ResponseViewModel ResObj = await _projectRepo.SearchProject(SearchBy, SearchText);
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

        [HttpGet, Route("GetProjectByProjectName/{ProjectName}")]
        public async Task<IActionResult> GetProjectByProjectName(string ProjectName)
        {
            try
            {
                ResponseViewModel ResObj = await _projectRepo.GetProjectByProjectName(ProjectName);
                if (ResObj.Status == false && ResObj.Messege == "Something went wrong !")
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