using FreeSql.DataAnnotations;
using Sys.BaseEntitys;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sys.Rbacs.Entity.Users
{
    /// <summary>
    /// 用户
    /// </summary>
    [Table(Name ="BS_USER")]
    [Index("uk_Code", "Code", true)]
    public class User: DataEntity
    {

        #region 是否启用 IsEnable
        /// <summary>
        /// 是否启用
        /// </summary>
        public string IsEnable { get; set; }
        #endregion

        #region 账号 Account
        /// <summary>
        /// 账号
        /// </summary>
        public string Account { get; set; }
        #endregion

        #region 密码 Password
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
        #endregion

        #region 编号 Code
        /// <summary>
        /// 编号
        /// </summary>
        public string Code { get; set; }
        #endregion

        #region 名称 Name
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        #endregion

        #region 电话号码 PhoneNumber
        /// <summary>
        /// 电话号码
        /// </summary>
        public string PhoneNumber { get; set; }
        #endregion

        #region 邮箱 Mail
        /// <summary>
        /// 邮箱
        /// </summary>
        public string Mail { get; set; }
        #endregion

    }
}
