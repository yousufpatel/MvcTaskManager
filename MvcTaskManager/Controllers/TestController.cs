using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MvcTaskManager.Controllers
{
    public class TestController : Controller
    {
        public IEnumerable<string> Index()
        {
            return new[] { "v","v1"};
        }
    }
}