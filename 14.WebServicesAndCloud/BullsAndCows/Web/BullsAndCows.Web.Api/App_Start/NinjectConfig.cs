namespace BullsAndCows.Web.Api
{
    using Common.Constants;
    using Common.Providers;
    using Data;
    using Data.Repositories;
    using Ninject;
    using Ninject.Extensions.Conventions;

    using Ninject.Web.Common;
    using Services.Data.Contracts;
    using System;
    using System.Web;

    public static class NinjectConfig
    {
        public static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IBullsAndCowsDbContext>().To<BullsAndCowsDbContext>().InRequestScope();
            kernel.Bind(typeof(IRepository<>)).To(typeof(EfGenericRepository<>));
            //kernel.Bind<IGamesServices>().To<GamesServices>();
            kernel.Bind<IRandomProvider>().To<RandomProvider>();

            kernel.Bind(k => k
                .From(
                    Assemblies.ServicesData)
                .SelectAllClasses()
                .InheritedFrom<IService>()
                .BindDefaultInterface());
        }
    }
}
