using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Threading.Tasks;
using WebAPI.Core.Services;

namespace WebApi.Filters
{
    [AttributeUsage(validOn: AttributeTargets.Class | AttributeTargets.Method)]
    public class ApiKeyAuthAttribute : Attribute, IAsyncActionFilter
    {
        private readonly IAppSettingService _appSettingService;
        public ApiKeyAuthAttribute(IAppSettingService appSettingService)
        {
            _appSettingService = appSettingService;
        }
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            Microsoft.Extensions.Primitives.StringValues requestHeaderApiKey;
            var isKeyExists = context.HttpContext.Request.Headers.TryGetValue("Rest-Api-Key", out requestHeaderApiKey);
            if (!isKeyExists || _appSettingService.ApiKey != requestHeaderApiKey)
            {
                context.Result = new UnauthorizedResult();
                return;
            }
            await next();
        }
    }
}
