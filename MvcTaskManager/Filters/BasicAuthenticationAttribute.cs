using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Results;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MvcTaskManager.Filters
{
    public class BasicAuthenticationAttribute : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            //context.Result = new UnauthorizedResult();
            return;
        }
    }
}
