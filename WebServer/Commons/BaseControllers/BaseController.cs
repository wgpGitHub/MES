using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebServer.Commons.BaseInterfaces;

namespace WebServer.Commons.BaseControllers
{
    /// <summary>
    /// api控制器基类
    /// </summary>
    [Route("api/[area]/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public abstract class BaseControllser<TService> : ControllerBase, IScopedDependency
    {
        public TService Service { get; set; }
    }
}
