using System.Web.Http;

//Evita agregar codigo a Global.asax para llamar a NinjectWebCommon
[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(NinjectSample.Clases.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(NinjectSample.Clases.NinjectWebCommon), "Stop")]

namespace NinjectSample.Clases.IoC_1
{
    using System;
    using System.Web;
    using System.Web.Http;
    using System.Web.Http.Dependencies;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Web.Common;
    using NinjectSample.Clases.Svc;


 
    /// <summary>
    /// Al integrar Ninject.MVC3, se agrega automáticamente una clase llamada NinjectWebCommon en el directorio App_Start. 
    ///  GlobalConfiguration.Configuration.DependencyResolver = new NinjectDependencyResolver(kernel);
    ///
    /// De esa manera, Ninject se integrará como DependencyResolver en todo el proyecto (ya que está a nivel de Configuración Global).
    /// </summary>
    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            //TODO: Ver DynamicModuleUtility
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
        /// registrar cuantos módulos y/o servicios existan en el proyecto,
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
            kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

            RegisterServices(kernel);

            // Install our Ninject-based IDependencyResolver into the Web API config
            GlobalConfiguration.Configuration.DependencyResolver = new NinjectDependencyResolver(kernel);

            return kernel;
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            //var kernelConfigurator = new NinjectConfigurator();
            //kernelConfigurator.Configure(kernel);
            // Add all bindings/dependencies
            kernel.Bind<IUserService>().To<UserService>().InSingletonScope();
            //kernel.Bind<IDatabaseValueParser>().To<DatabaseValueParser>();

            //kernel.Bind<IHttpCategoryFetcher>().To<HttpCategoryFetcher>();
            //kernel.Bind<IHttpPriorityFetcher>().To<HttpPriorityFetcher>();
            //kernel.Bind<IHttpStatusFetcher>().To<HttpStatusFetcher>();
            //kernel.Bind<IHttpUserFetcher>().To<HttpUserFetcher>();
            //kernel.Bind<IHttpTaskFetcher>().To<HttpTaskFetcher>();
            //kernel.Bind<IActionLogHelper>().To<ActionLogHelper>();
            //kernel.Bind<IExceptionMessageFormatter>().To<ExceptionMessageFormatter>();
            //kernel.Bind<IActionExceptionHandler>().To<ActionExceptionHandler>();
            //kernel.Bind<IActionTransactionHelper>().To<ActionTransactionHelper>();

            //kernel.Bind<IUserManager>().To<UserManager>();
            //kernel.Bind<IMembershipInfoProvider>().To<MembershipAdapter>();
            //kernel.Bind<ICategoryMapper>().To<CategoryMapper>();
            //kernel.Bind<IPriorityMapper>().To<PriorityMapper>();
            //kernel.Bind<IStatusMapper>().To<StatusMapper>();
            //kernel.Bind<IUserMapper>().To<UserMapper>();
            //kernel.Bind<ITaskMapper>().To<TaskMapper>();

            //kernel.Bind<ISqlCommandFactory>().To<SqlCommandFactory>();
            //kernel.Bind<IUserRepository>().To<UserRepository>();

            //kernel.Bind<IUserSession>().ToMethod(CreateUserSession).InRequestScope();
         
           
        }


      
        #region WebContainerManager
        public static T Get_Service<T>()
        {
            object service = GetContainer().GetService(typeof(T));

            if (service == null)
                throw new NullReferenceException(string.Format("Requested service of type {0}, but null was found.", typeof(T).FullName));

            return (T)service;
        }

        /// <summary>
        /// Retrive Resolver
        /// </summary>
        /// <returns></returns>
        public static IDependencyResolver GetContainer()
        {
            var dependencyResolver = GlobalConfiguration.Configuration.DependencyResolver;
            if (dependencyResolver != null)
            {
                return dependencyResolver;
            }

            throw new InvalidOperationException("NinjectDependencyResolver not being used as the MVC dependency resolver");
        }
        #endregion
    }
}
