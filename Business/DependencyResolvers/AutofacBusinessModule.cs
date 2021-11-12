using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<StudentManager>().As<IStudentService>();
            builder.RegisterType<EfStudentDal>().As<IStudentDal>();
            
            builder.RegisterType<SchoolManager>().As<ISchoolService>();
            builder.RegisterType<EfSchoolDal>().As<ISchoolDal>();
            
            builder.RegisterType<SysAdminManager>().As<ISysAdminService>();
            builder.RegisterType<EfSysAdminDal>().As<ISysAdminDal>();
            
            builder.RegisterType<SchAdminManager>().As<ISchAdminService>();
            builder.RegisterType<EfSchAdminDal>().As<ISchAdminDal>();
            
            builder.RegisterType<PostManager>().As<IPostService>();
            builder.RegisterType<EfPostDal>().As<IPostDal>();
            
            builder.RegisterType<SatisfactionManager>().As<ISatisfactionService>();
            builder.RegisterType<EfSatisfactionDal>().As<ISatisfactionDal>();

            //builder.RegisterType<AuthManager>().As<IAuthService>();
            //builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
