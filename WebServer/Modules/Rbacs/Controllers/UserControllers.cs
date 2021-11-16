using Microsoft.AspNetCore.Mvc;
using WebServer.Commons.BaseControllers;
using WebServer.Modules.Rbacs.IService;

namespace WebServer.Modules.Rbacs.Controllers
{
    /// <summary>
    /// 用户控制器
    /// </summary>
    [Area("User")]
    public class UserControllers: BaseControllser<IUserService>
    {

        #region 添加用户测试 AddUserTest      
        /// <summary>
        /// 添加用户测试
        /// </summary>
        [HttpPost]
        public void AddUserTest()
        {
            Service.AddUser();
        }
        #endregion

    }
}
