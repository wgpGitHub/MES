using System;
using System.Collections.Generic;
using System.Text;

namespace WebServer.Commons
{
    //当前运行RunTime
    public static class RT
    {

        #region 当前用户 CurUser
        /// <summary>
        /// 当前用户Id
        /// </summary>
        public static string CurUserId { get; set; }

        /// <summary>
        /// 当前用户账号
        /// </summary>
        public static string CurUserAccount { get; set; }

        /// <summary>
        /// 当前用户编码
        /// </summary>
        public static string CurUserCode { get; set; }

        /// <summary>
        /// 当前用户名称
        /// </summary>
        public static string CurUserName { get; set; }
        #endregion

    }
}
