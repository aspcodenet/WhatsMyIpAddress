using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace WhatsMyIpAddress.Services
{
    public interface IGetIPService
    {
        string GetIpAddress();
    }

    class GetIpService : IGetIPService
    {
        private readonly IActionContextAccessor _accessor;

        public GetIpService(IActionContextAccessor accessor)
        {
            _accessor = accessor;
        }
        public string GetIpAddress()
        {
            var context = _accessor.ActionContext.HttpContext;
           
            return context.Connection.RemoteIpAddress.ToString();
        }
    }
}