using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi.OwinHost;
using Owin;
using System.Web.Http;
using System.Reflection;
using Ninject;
using Blogging.Data;

[assembly: OwinStartup(typeof(Blogging.Web.Startup))]

namespace Blogging.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            app.UseNinjectMiddleware(CreateKernel).UseNinjectWebApi(GlobalConfiguration.Configuration);
        }

        private static StandardKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            RegisterMappings(kernel);
            return kernel;
        }

        private static void RegisterMappings(StandardKernel kernel)
        {
            kernel.Bind<IBlogData>().To<BlogData>().WithConstructorArgument("context", c => new BlogDbContext());
        }
    }
}