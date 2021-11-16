using FreeSql;
using FreeSql.Aop;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Sys;
using Sys.BaseEntitys;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace WebServer
{
    public class Startup
    {

        #region ���캯�� Startup      
        /// <summary>
        /// ���캯��
        /// </summary>
        public Startup(IConfiguration configuration)
        {
            //����ע��
            Configuration = configuration;
        }
        #endregion
        
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        // �ķ�����д��������
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddSwaggerGen(options =>
                options.SwaggerDoc("Sys", new OpenApiInfo() { Title = "1111", Version = "all" }));//���ñ���
            FreeSqlConfig(services);
            //SwaggerConfig(services, "̨Ժ:MESϵͳ");
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        // �ķ�����д�м��
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();//ʹ��Swagger
            app.UseSwaggerUI(a =>
            {
                a.SwaggerEndpoint("/swagger/Sys/swagger.json", "ȫ��");
                a.RoutePrefix = "api/help";
            });//��������UI
            app.UseRouting();//��������URL
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        #region FreeSql���� FreeSqlConfig      
        /// <summary>
        /// FreeSql����
        /// </summary>
        public void FreeSqlConfig(IServiceCollection services)
        {
            var dbType = Configuration.GetValue<string>("DbType");//��ȡ���ݿ�����
            var connectionString = Configuration.GetConnectionString("Master");//��ȡMaster�������ַ���
            var fsql = new FreeSqlBuilder()//��ʼ��FreeSql
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
            //���
            fsql.Aop.AuditValue += (o, e) =>
            {
                //������Ϊ�������޸�ʱ
                if (e.AuditValueType == AuditValueType.Insert || e.AuditValueType == AuditValueType.InsertOrUpdate)
                {
                    //�ж�e.Property.DeclaringType�Ƿ���ת����DataEtity
                    if (typeof(DataEntity).IsAssignableFrom(e.Property.DeclaringType))
                    {
                        switch (e.Property.Name)
                        {
                            case nameof(DataEntity.CreatedBy):e.Value = RT.CurUserId;break;//������Id
                            case nameof(DataEntity.CreatedByName): e.Value = RT.CurUserName; break;//����������
                            case nameof(DataEntity.CreatedTime): e.Value = DateTime.Now; break;//��ǰʱ��
                        }
                    }
                }
                //�޸ļ�¼
                if (typeof(DataEntity).IsAssignableFrom(e.Property.DeclaringType))
                {
                    switch (e.Property.Name)
                    {
                        case nameof(DataEntity.CreatedBy): e.Value = RT.CurUserId; break;//������Id
                        case nameof(DataEntity.CreatedByName): e.Value = RT.CurUserName; break;//����������
                        case nameof(DataEntity.CreatedTime): e.Value = DateTime.Now; break;//��ǰʱ��
                    }
                }
            };

#if DEBUG
            fsql.Aop.CommandBefore += (o, e) =>
            {
                Trace.WriteLine(e.Command.CommandText);
            };
#endif
            services.AddSingleton<IFreeSql>(fsql);//����ע��
        }
        #endregion

        #region Swagger���� SwaggerConfig      
        /// <summary>
        /// Swagger����
        /// </summary>
        public void SwaggerConfig(IServiceCollection services, string title)
        {
            services.AddSwaggerGen(options =>
                options.SwaggerDoc("Sys", new OpenApiInfo() { Title = title, Version = "all" }));//���ñ���
        }
        #endregion


    }
}
