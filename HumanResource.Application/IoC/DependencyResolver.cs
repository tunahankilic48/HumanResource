using Autofac;
using AutoMapper;
using HumanResource.Application.Services.AccountServices;
using HumanResource.Application.Services.AddressService;
using HumanResource.Application.Services.AdvanceService;
using HumanResource.Application.Services.LeaveServices;
using HumanResource.Application.Services.PersonelService;
using HumanResource.Domain.Repositries;
using HumanResource.Infrastructure.Repositories;

namespace HumanResource.Application.IoC
{
    public class DependencyResolver : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Mapper>().As<IMapper>().InstancePerLifetimeScope();
            builder.RegisterType<AddressRepository>().As<IAddressRepository>().InstancePerLifetimeScope();
            builder.RegisterType<AdvanceRepository>().As<IAdvanceRepository>().InstancePerLifetimeScope();
            builder.RegisterType<AppUserRepository>().As<IAppUserRepository>().InstancePerLifetimeScope();
            builder.RegisterType<BloodTypeRepository>().As<IBloodTypeRepository>().InstancePerLifetimeScope();
            builder.RegisterType<CityRepository>().As<ICityRepository>().InstancePerLifetimeScope();
            builder.RegisterType<DepartmentRepository>().As<IDepartmentRepository>().InstancePerLifetimeScope();
            builder.RegisterType<DistrictRepository>().As<IDistrictRepository>().InstancePerLifetimeScope();
            builder.RegisterType<LeaveRepository>().As<ILeaveRepository>().InstancePerLifetimeScope();
            builder.RegisterType<LeaveTypeRepository>().As<ILeaveTypeRepository>().InstancePerLifetimeScope();

            builder.RegisterType<AccountServices>().As<IAccountServices>().InstancePerLifetimeScope();
            builder.RegisterType<PersonelService>().As<IPersonelService>().InstancePerLifetimeScope();
            builder.RegisterType<LeaveService>().As<ILeaveService>().InstancePerLifetimeScope();
            builder.RegisterType<AdvanceService>().As<IAdvanceService>().InstancePerLifetimeScope();
            builder.RegisterType<AddressService>().As<IAddressService>().InstancePerLifetimeScope();

            #region AutoMapper
            builder.Register(context => new MapperConfiguration(cfg =>
            {
                //Register Mapper Profile
                cfg.AddProfile<HumanResource.Application.Mapping.Mapping>(); /// AutoMapper klasörünün altına eklediğimiz Mapping classını bağlıyoruz.
            }
            )).AsSelf().SingleInstance();



            builder.Register(c =>
            {
                //This resolves a new context that can be used later.
                var context = c.Resolve<IComponentContext>();
                var config = context.Resolve<MapperConfiguration>();
                return config.CreateMapper(context.Resolve);
            })
            .As<IMapper>()
            .InstancePerLifetimeScope();
            #endregion

            base.Load(builder);
        }
    }
}
