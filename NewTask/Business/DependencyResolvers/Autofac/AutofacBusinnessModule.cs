using Autofac;
using Business.Abstract;
using Business.Concrete;
using Core.Utilities.Security.Jwt;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinnessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<EfClinicsDal>().As<IClinicsDal>();
            builder.RegisterType<ClinicsManager>().As<IClinicsService>();

            builder.RegisterType<EfEquipmentDal>().As<IEquipmentDal>();
            builder.RegisterType<EquipmentManager>().As<IEquipmentService>();

            builder.RegisterType<EfSysLogDal>().As<ISysLogDal>();
            builder.RegisterType<SysLogManager>().As<ISysLog>();

            builder.RegisterType<EfUserDal>().As<IUserDal>();
            builder.RegisterType<UserManager>().As<IUserService>();


            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();
        }
    }
}
