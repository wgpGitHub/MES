using Sys.Controller.CommonControllers.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sys.Controller.CommonControllers.Dtos
{
    /// <summary>
    /// 增删改实体操作Dto
    /// </summary>
    public class CUDEntityDto
    {

        /// <summary>
        /// 实体类型
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// CRUD操作类型
        /// </summary>
        public CUDOprate CUDOprate { get; set; }

        /// <summary>
        /// 实体对象KeyValue
        /// </summary>
        public List<Dictionary<string, object>> Entitys { get; set; }

        /// <summary>
        /// 子数据列表
        /// </summary>
        public List<CUDEntityDto> Children { get; set; }

    }
}
