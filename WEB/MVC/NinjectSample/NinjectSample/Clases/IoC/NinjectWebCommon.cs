using System.Web.Http;

//Evita agregar codigo a Global.asax para llamar a NinjectWebCommon
[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(NinjectSample.Clases.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(NinjectSample.Clases.NinjectWebCommon), "Stop")]

namespace NinjectSample.Clases
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
    /// GlobalConfiguration.Configuration.DependencyResolver = new NinjectDependencyResolver(kernel);
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
            return kernel;
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            //var containerConfigurator = new NinjectConfigurator();
            //containerConfigurator.Configure(kernel);
            // Add all bindings/dependencies
            AddBindings(kernel);
            // Use the container and our NinjectDependencyResolver as
            // application's resolver
            var resolver = new NinjectDependencyResolver(kernel);
           
            GlobalConfiguration.Configuration.DependencyResolver = resolver;
            //TODO: VEr BasicAuthenticationMessageHandler
            //GlobalConfiguration.Configuration.MessageHandlers.Add(kernel.Get<BasicAuthenticationMessageHandler>());
        }


        /// <summary>
        /// Add all bindings/dependencies to the container
        /// </summary>
        private static void AddBindings(IKernel container)
        {

            container.Bind<IUserService>().To<UserService>().InSingletonScope();
            //container.Bind<IDatabaseValueParser>().To<DatabaseValueParser>();

            //container.Bind<IHttpCategoryFetcher>().To<HttpCategoryFetcher>();
            //container.Bind<IHttpPriorityFetcher>().To<HttpPriorityFetcher>();
            //container.Bind<IHttpStatusFetcher>().To<HttpStatusFetcher>();
            //container.Bind<IHttpUserFetcher>().To<HttpUserFetcher>();
            //container.Bind<IHttpTaskFetcher>().To<HttpTaskFetcher>();
            //container.Bind<IActionLogHelper>().To<ActionLogHelper>();
            //container.Bind<IExceptionMessageFormatter>().To<ExceptionMessageFormatter>();
            //container.Bind<IActionExceptionHandler>().To<ActionExceptionHandler>();
            //container.Bind<IActionTransactionHelper>().To<ActionTransactionHelper>();

            //container.Bind<IUserManager>().To<UserManager>();
            //container.Bind<IMembershipInfoProvider>().To<MembershipAdapter>();
            //container.Bind<ICategoryMapper>().To<CategoryMapper>();
            //container.Bind<IPriorityMapper>().To<PriorityMapper>();
            //container.Bind<IStatusMapper>().To<StatusMapper>();
            //container.Bind<IUserMapper>().To<UserMapper>();
            //container.Bind<ITaskMapper>().To<TaskMapper>();

            //container.Bind<ISqlCommandFactory>().To<SqlCommandFactory>();
            //container.Bind<IUserRepository>().To<UserRepository>();

            //container.Bind<IUserSession>().ToMethod(CreateUserSession).InRequestScope();


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
