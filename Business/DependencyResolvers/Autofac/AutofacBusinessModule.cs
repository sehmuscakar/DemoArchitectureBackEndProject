using Autofac;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Autofac // bunun için Autofac kütüphanesini yuklemen lazım
{
    public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder) // overide load yaz otomatik doldurulur.
        {
            builder.RegisterType<OperationClaimManager>().As<IOperationClaimService>();//ben Interfaceyi ayzdığımda sen ilgili classı algıla anlamında
            builder.RegisterType<EfOperationClaimDal>().As<IOperationClaimDal>();

            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();

            builder.RegisterType<UserOperationClaimManager>().As<IUserOperationClaimService>();
            builder.RegisterType<EfUserOperationClaimDal>().As<IUserOperationClaimDal>();

            builder.RegisterType<AuthManager>().As<IAuthService>();

        }

    }
}
