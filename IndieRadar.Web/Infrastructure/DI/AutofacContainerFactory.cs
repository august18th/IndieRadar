using System;
using System.Reflection;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using AutoMapper;
using IndieRadar.Data.Infrastructure.Context;
using IndieRadar.Data.Repositories;
using IndieRadar.Data.Repositories.Identity;
using IndieRadar.Model.Models;
using IndieRadar.Services.Interfaces.Managers;
using IndieRadar.Services.Managers;
using IndieRadar.Services.Services;
using IndieRadar.Web.Infrastructure.Mapper;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace IndieRadar.Web.Infrastructure.DI
{
    public class AutofacContainerFactory
    {
        public static IDependencyResolver SetAutofacContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<IndieRadarDbContext>().As<IDbContext>().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(GameRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(GameService).Assembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces().InstancePerRequest();

            builder.Register(c => AutoMapperConfiguration.Configure())
                .AsSelf().SingleInstance();
            builder.Register(c => c.Resolve<MapperConfiguration>()
                .CreateMapper(c.Resolve)).As<IMapper>().InstancePerRequest();

            builder.RegisterType<UserManager<ApplicationUser, String>>().InstancePerRequest();
            builder.RegisterType<UserManager>().As<IUserManager>().InstancePerRequest();
            builder.RegisterType<UserStore>().As<IUserStore<ApplicationUser, String>>().InstancePerRequest();

            builder.RegisterType<SignInService>()
                .As<ISignInService>().InstancePerRequest();


            builder.Register(c => new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new IndieRadarDbContext())))
              .As<UserManager<ApplicationUser>>().InstancePerRequest();

            IContainer container = builder.Build();
            return new AutofacDependencyResolver(container);
        }
    }
}