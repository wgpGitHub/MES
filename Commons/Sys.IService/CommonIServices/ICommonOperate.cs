using Sys.BaseInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sys.IService.CommonIServices
{
    /// <summary>
    /// 操作
    /// </summary>
    public interface ICommonOperate: IScopedDependency
    {
        /// <summary>
        /// 公共新增
        /// </summary>
        void InsertEntity();
        /// <summary>
        /// 公共修改
        /// </summary>
        void UpdateEntity();
        /// <summary>
        /// 公共删除
        /// </summary>
        void DeleteEntity();
        /// <summary>
        /// 公共查询
        /// </summary>
        void GetEntity();
    }
}
