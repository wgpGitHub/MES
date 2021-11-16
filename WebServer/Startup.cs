using FreeSql;
using FreeSql.Aop;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using WebServer.Commons;
using WebServer.Commons.BaseEntitys;

namespace WebServer
{
    public class Startup
    {

        #region 构造函数 Startup      
        /// <summary>
        /// 构造函数
        /// </summary>
        public Startup(IConfiguration configuration)
        {
            //依赖注入
            Configuration = configuration;
        }
        #endregion
        
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        // 该方法填写服务配置
        public void ConfigureServices(IServiceCollection services)
        {
            FreeSqlConfig(services);
            SwaggerConfig(services, "台州学院:MES轻量化系统开发Api");
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        // 该方法填写中间件
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();//使用Swagger
            app.UseSwaggerUI(a =>
            {
                a.SwaggerEndpoint("/swagger/Sys/swagger.json", "全部");
                a.RoutePrefix = "api/help";
            });//配置它的UI
            app.UseRouting();//配置它的URL
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        #region FreeSql配置 FreeSqlConfig      
        /// <summary>
        /// FreeSql配置
        /// </summary>
        public void FreeSqlConfig(IServiceCollection services)
        {
            var dbType = Configuration.GetValue<string>("DbType");//获取数据库类型
            var connectionString = Configuration.GetConnectionString("Master");//获取Master的配置字符串
            var fsql = new FreeSqlBuilder()//初始化FreeSql
                .UseConnectionString((DataType)Enum.Parse(typeof(DataType), dbType), connectionString)
                .UseAutoSyncStructure(true)
                .Build();
            fsql.Aop.ConfigEntityProperty += (o, e) =>
            {
                if (typeof(DataEntity).IsAssignableFrom(e.EntityType) && (e.Property.Name == nameof(DataEntity.CreatedBy) || e.Property.Name == nameof(DataEntity.CreatedByName) || e.Property.Name == nameof(DataEntity.CreatedTime)))
                {
                    e.ModifyResult.CanUpdate = false;
                }
            };
            //审计
            fsql.Aop.AuditValue += (o, e) =>
            {
                //当操作为新增或修改时
                if (e.AuditValueType == AuditValueType.Insert || e.AuditValueType == AuditValueType.InsertOrUpdate)
                {
                    //判断e.Property.DeclaringType是否能转化成DataEtity
                    if (typeof(DataEntity).IsAssignableFrom(e.Property.DeclaringType))
                    {
                        switch (e.Property.Name)
                        {
                            case nameof(DataEntity.CreatedBy): e.Value = RT.CurUserId; break;//创建人Id
                            case nameof(DataEntity.CreatedByName): e.Value = RT.CurUserName; break;//创建人名称
                            case nameof(DataEntity.CreatedTime): e.Value = DateTime.Now; break;//当前时间
                        }
                    }
                }
                //修改记录
                if (typeof(DataEntity).IsAssignableFrom(e.Property.DeclaringType))
                {
                    switch (e.Property.Name)
                    {
                        case nameof(DataEntity.CreatedBy): e.Value = RT.CurUserId; break;//创建人Id
                        case nameof(DataEntity.CreatedByName): e.Value = RT.CurUserName; break;//创建人名称
                        case nameof(DataEntity.CreatedTime): e.Value = DateTime.Now; break;//当前时间
                    }
                }
            };

#if DEBUG
            fsql.Aop.CommandBefore += (o, e) =>
            {
                Trace.WriteLine(e.Command.CommandText);
            };
#endif
            services.AddSingleton<IFreeSql>(fsql);//单例注入
        }
        #endregion

        #region Swagger配置 SwaggerConfig      
        /// <summary>
        /// Swagger配置
        /// </summary>
        public void SwaggerConfig(IServiceCollection services, string title)
        {
            services.AddMvc();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("Sys", new OpenApiInfo { Title = title, Version = "all" });
            });
        }
        #endregion


    }
}
