using System;
using Xunit;
using MvcTaskManager.Repositories.Mocks;
using MvcTaskManager.Controllers;
using MvcTaskManager.Repositories.Contracts;
using Moq;
using Microsoft.AspNetCore.Mvc;

namespace XUnitTestProject
{
    public class CalculatorUnitTest
    {
        [Fact]
        public void ValidateAdd()
        {
            CalculatorRepoMock Obj = new CalculatorRepoMock();
            int result = Obj.add(4,4);

            Assert.Equal(8,result);
        }

        [Fact]
        public void InvalidateAdd()
        {
            CalculatorRepoMock Obj = new CalculatorRepoMock();
            Assert.Throws<ArithmeticException>(() => Obj.add(5, 7));
        }

        [Fact]
        public async System.Threading.Tasks.Task TestMethodAsync()
        {
            var mock = new Mock<IProjectRepo>();
            ProjectController test = new ProjectController(mock.Object);
            var data = await test.GetProjects();

            var status = 

            Assert.IsType<OkObjectResult>(data);

        }

        
    }
}
