using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Foundation.Services
{
    public class UrlService : IUrlService
    {
        private readonly IHttpContextAccessor _accessor;
        private readonly LinkGenerator _generator;

        public UrlService(IHttpContextAccessor accessor, LinkGenerator generator)
        {
            _accessor = accessor;
            _generator = generator;
        }
        //public string GenerateAbsulateUrl(string controller, string action, object parameters)
        //{
        //    var test = _accessor.HttpContext;
        //    return _generator.GetUriByAction(_accessor.HttpContext, action, controller, parameters);
        //}

        public string GenerateAbsoluteUrl(string controller, string action, object parameters)
        {
            var test = _accessor.HttpContext;
            return _generator.GetUriByAction(_accessor.HttpContext, action, controller, parameters);
        }
    }
}
