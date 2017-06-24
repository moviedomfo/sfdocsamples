//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Web.Http;
//using Ninject;

//namespace NinjectSample.Clases
//{
//    /// <summary>
//    /// Class used to set up the Ninject DI container.
//    /// </summary>
//    public class NinjectConfigurator
//    {
//        /// <summary>
//        /// Entry method used by caller to configure the given 
//        /// container with all of this application's 
//        /// dependencies. Also configures the container as this
//        /// application's dependency resolver.
//        /// </summary>
//        public void Configure(IKernel kernel_container)
//        {
//            // Add all bindings/dependencies
//            AddBindings(kernel_container);

//            // Use the container and our NinjectDependencyResolver as
//            // application's resolver
//            var resolver = new NinjectDependencyResolver(kernel_container);
//            GlobalConfiguration.Configuration.DependencyResolver = resolver;
//        }

//        /// <summary>
//        /// Add all bindings/dependencies to the container
//        /// </summary>
//        private void AddBindings(IKernel container)
//        {
   
//            //container.Bind<IDateTime>().To<DateTimeAdapter>();
//            //container.Bind<IDatabaseValueParser>().To<DatabaseValueParser>();

//            //container.Bind<IHttpCategoryFetcher>().To<HttpCategoryFetcher>();
//            //container.Bind<IHttpPriorityFetcher>().To<HttpPriorityFetcher>();
//            //container.Bind<IHttpStatusFetcher>().To<HttpStatusFetcher>();
//            //container.Bind<IHttpUserFetcher>().To<HttpUserFetcher>();
//            //container.Bind<IHttpTaskFetcher>().To<HttpTaskFetcher>();
//            //container.Bind<IActionLogHelper>().To<ActionLogHelper>();
//            //container.Bind<IExceptionMessageFormatter>().To<ExceptionMessageFormatter>();
//            //container.Bind<IActionExceptionHandler>().To<ActionExceptionHandler>();
//            //container.Bind<IActionTransactionHelper>().To<ActionTransactionHelper>();

//            //container.Bind<IUserManager>().To<UserManager>();
//            //container.Bind<IMembershipInfoProvider>().To<MembershipAdapter>();
//            //container.Bind<ICategoryMapper>().To<CategoryMapper>();
//            //container.Bind<IPriorityMapper>().To<PriorityMapper>();
//            //container.Bind<IStatusMapper>().To<StatusMapper>();
//            //container.Bind<IUserMapper>().To<UserMapper>();
//            //container.Bind<ITaskMapper>().To<TaskMapper>();

//            //container.Bind<ISqlCommandFactory>().To<SqlCommandFactory>();
//            //container.Bind<IUserRepository>().To<UserRepository>();

//            //container.Bind<IUserSession>().ToMethod(CreateUserSession).InRequestScope();
//        }

       
 
//    }
//}
