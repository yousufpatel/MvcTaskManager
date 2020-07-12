using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using MvcTaskManager.Repositories.Contracts;
using MvcTaskManager.Controllers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace XUnitTestProject
{
    public class ProjetModuleUnitTest
    {
        [Fact]
        public async Task ValidateGetProjectsAsync()
        {
            var mock = new Mock<IProjectRepo>();
            ProjectController test = new ProjectController(mock.Object);
            var data = await test.GetProjects();
            Assert.IsType<OkObjectResult>(data);
        }
    }
}
