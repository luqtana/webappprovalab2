﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebAppProvaLab2.Startup))]
namespace WebAppProvaLab2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
