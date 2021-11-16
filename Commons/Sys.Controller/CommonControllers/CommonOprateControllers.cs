using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Sys.BaseControllers;
using Sys.Controller.CommonControllers.Dtos;
using Sys.IService.CommonIServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sys.Controller.CommonControllers
{
    /// <summary>
    /// 公共接口
    /// </summary>
    public class CommonOprateControllers
    {

        //#region 公共增删改 CUDEntityOprate      
        ///// <summary>
        ///// 公共增删改
        ///// </summary>
        //[HttpPost]
        //public void CUDEntityOprate(CUDEntityDto dto)
        //{
        //    //switch (dto.CUDOprate)
        //    //{
        //    //    case Enums.CUDOprate.Insert:
        //    //        var type = Type.GetType(dto.Type, false);
        //    //        if (type == null) throw new Exception($"实体类型[{dto.Type}]不存在");
        //    //        var entitys = JsonConvert.DeserializeObject(JsonConvert.SerializeObject(dto.Entitys), typeof(List<>).MakeGenericType(type));
        //    //        var method = Service.GetType().GetMethod(nameof(ICommonOperate.InsertEntity));
        //    //        method = method.MakeGenericMethod(type);
        //    //        method.Invoke(Service, new object[] { entitys });
        //    //        break;
        //    //    case Enums.CUDOprate.Update:
        //    //        break;
        //    //    case Enums.CUDOprate.Delete:
        //    //        break;
        //    //    default:throw new Exception($"不存在该操作");
        //    //}
        //}

        ////#region 新增 InsertEntity      
        /////// <summary>
        /////// 新增
        /////// </summary>
        ////public void InsertEntity(CUDEntityDto dto)
        ////{
        ////    var type = Type.GetType(dto.Type, false);
        ////    if (type == null)throw new Exception($"实体类型[{dto.Type}]不存在");
        ////    var entitys = JsonConvert.DeserializeObject(JsonConvert.SerializeObject(dto.Entitys), typeof(List<>).MakeGenericType(type));
        ////    var method = Service.GetType().GetMethod(nameof(ICommonOperate.InsertEntity));
        ////    method = method.MakeGenericMethod(type);
        ////    method.Invoke(Service, new object[] { entitys });
        ////}
        ////#endregion

        //#endregion

        //#region 公共查询 GetEntityOprate      
        ///// <summary>
        ///// 公共查询
        ///// </summary>
        //[HttpPost]
        //public void GetEntityOprate()
        //{
        //    Service.GetEntity();
        //}
        //#endregion

    }
}
