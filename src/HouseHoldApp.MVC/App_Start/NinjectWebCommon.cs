using System.Security.Principal;
using HouseHoldApp.Domain.DomainServices;
using HouseHoldApp.Domain.Entities;
using HouseHoldApp.Domain.Repository;
using HouseHoldApp.Domain.UnitOfWork;
using HouseHoldApp.MVC.Infrastructure;
using HouseHoldApp.RepositoryEF;
using HouseHoldApp.RepositoryEF.Repositories;
using HouseHoldApp.RepositoryEF.UnitOfWork;
using Microsoft.AspNet.Identity;

[assembly: WebActivator.PreApplicationStartMethod(typeof(HouseHoldApp.MVC.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivator.ApplicationShutdownMethodAttribute(typeof(HouseHoldApp.MVC.App_Start.NinjectWebCommon), "Stop")]

namespace HouseHoldApp.MVC.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
            kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
            
            RegisterServices(kernel);
            return kernel;
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<HhContext>().ToSelf().InRequestScope();
            kernel.Bind<IUserRepository>().To<UserRepositoryEF>()
                .WithConstructorArgument("dbSet",
                             context => context.Kernel.Get<HhContext>().Set<User>());
            kernel.Bind<IHouseHoldRepository>().To<HouseHoldRepositoryEF>()
            .WithConstructorArgument("dbSet",
                             context => context.Kernel.Get<HhContext>().Set<HouseHold>());
            kernel.Bind<IHouseHoldMemberRepository>().To<HouseHoldMemberRepositoryEF>()
                .WithConstructorArgument("dbSet",
                             context => context.Kernel.Get<HhContext>().Set<HouseHoldMember>());
            kernel.Bind<IPasswordHasher>().To<PasswordHasher>();
            kernel.Bind<IHouseHoldService>().To<HouseHoldService>();
            kernel.Bind<IHouseHoldMemberService>().To<HouseHoldMemberService>();
            kernel.Bind<IUserService>().To<UserService>();
            kernel.Bind<IUnitOfWork>().To<UnitOfWorkEF>();
            kernel.Bind<IAuthenticationService>().To<FormsAuthenticationService>();
            kernel.Bind<IIdentity>().ToMethod(c => HttpContext.Current.User.Identity);
        }        
    }
}
