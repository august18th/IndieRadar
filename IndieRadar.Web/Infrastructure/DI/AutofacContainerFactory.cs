using System.Reflection;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using AutoMapper;
using IndieRadar.Data.Infrastructure.Context;
using IndieRadar.Data.Repositories;
using IndieRadar.Services.Services;
using IndieRadar.Web.Infrastructure.Mapper;

namespace IndieRadar.Web.Infrastructure.DI
{
    public class AutofacContainerFactory
    {
        public static void Run()
        {
            SetAutofacContainer();
        }

        private static void SetAutofacContainer()
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


            //builder.Register(c => new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new SocialGoalEntities())))
            //  .As<UserManager<ApplicationUser>>().InstancePerHttpRequest();

            builder.RegisterFilterProvider();
            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}