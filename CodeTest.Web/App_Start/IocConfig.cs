using System.Web.Http;
using CodeTest.Data;
using CodeTest.Data.Contracts;
using Ninject;

namespace CodeTest.Web
{
    public class IocConfig
    {
        public static void RegisterIoc(HttpConfiguration config)
        {
            var kernel = new StandardKernel();

            kernel.Bind<RepositoryFactories>().To<RepositoryFactories>().InSingletonScope();

            kernel.Bind<IRepositoryProvider>().To<RepositoryProvider>();
            kernel.Bind<ICodeTestUow>().To<CodeTestUow>();

            // Tell WebApi how to use our Ninject IoC
            config.DependencyResolver = new NinjectDependencyResolver(kernel);      
        }
    }
}