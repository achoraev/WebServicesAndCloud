using System;
using System.Collections.Generic;
using System.Linq;
using Owin;
using Microsoft.Owin;
using Blogging.Web;
using Ninject;
using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi.OwinHost;
using System.Web.Http;
using System.Reflection;
using Blogging.Data;

[assembly: OwinStartup(typeof(Startup))]

namespace Blogging.Web
{    
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            // this.app.UseNinjectMiddleware(CreateKernel).UseNinjectWebApi(GlobalConfiguration.Configuration);
        }

        //private static StandardKernel CreateKernel()
        //{ 
        //    var kernel = new StandardKernel();
        //    kernel.Load(Assembly.GetExecutingAssembly());
        //    RegisterMappings(kernel);
        //    return kernel;
        //}

        //private static void RegisterMappings(StandardKernel kernel)
        //{
        //    kernel.Bind<IStudentData>().To<StudentData>().WithConstructorArgument("context", c => new TemplateDbContext());
        //}
    }
}