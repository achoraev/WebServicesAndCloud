using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.Owin;
using Owin;
using MusicStore.Services;

[assembly: OwinStartup(typeof(Startup))]

namespace MusicStore.Services
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}