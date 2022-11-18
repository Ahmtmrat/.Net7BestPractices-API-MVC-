using Autofac;
using CinemaProject.Core.Repositories;
using CinemaProject.Core.Services;
using CinemaProject.Core.UnitOfWorks;
using CinemaProject.Repository;
using CinemaProject.Repository.Repositories;
using CinemaProject.Repository.UnitOfWork;
using CinemaProject.Service.Mapping;
using CinemaProject.Service.Services;
using System.Reflection;

namespace CinemaProject.Web.Modules
{
    public class RepoServiceModule: Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>)).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(GenericService<>)).As(typeof(IGenericService<>)).InstancePerLifetimeScope();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
            builder.RegisterType<CinemaServiceWithDto>().As<ICinemaServiceWithDto>().InstancePerLifetimeScope();

            var apiAssembly = Assembly.GetExecutingAssembly();
            var repoAssembly= Assembly.GetAssembly(typeof(AppDbContext));
            var serviceAssembly = Assembly.GetAssembly(typeof(MapProfile));

            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly).Where(x => x.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerLifetimeScope(); 
            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly).Where(x => x.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerLifetimeScope();
            

            base.Load(builder);
        }
    }
}
