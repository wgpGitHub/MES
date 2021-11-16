using FreeSql.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sys.BaseEntitys
{
    /// <summary>
    /// 实体基础数据
    /// </summary>
    public abstract class DataEntity
    {

        #region Id Id
        /// <summary>
        /// Id
        /// </summary>
        [Column(IsPrimary = true,IsIdentity = true)]
        public int Id { get; set; }
        #endregion

        #region 创建人 CreatedBy
        /// <summary>
        /// 创建人
        /// </summary>
        public string CreatedBy { get; set; }
        #endregion

        #region 创建人名称 CreatedByName
        /// <summary>
        /// 创建人名称
        /// </summary>
        public string CreatedByName { get; set; }
        #endregion

        #region 创建时间 CreatedTime
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedTime { get; set; }
        #endregion

        #region 修改人 UpdatedBy
        /// <summary>
        /// 修改人
        /// </summary>
        public string UpdatedBy { get; set; }
        #endregion

        #region 修改人名称 UpdatedByName
        /// <summary>
        /// 修改人名称
        /// </summary>
        public string UpdatedByName { get; set; }
        #endregion

        #region 修改时间 UpdatedTime
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime UpdatedTime { get; set; }
        #endregion

    }
}
