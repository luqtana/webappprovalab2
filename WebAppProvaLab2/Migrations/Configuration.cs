namespace WebAppProvaLab2.Migrations
{
    using Contexto;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<WebAppProvaLab2.Contexto.ContextoEF>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;


        }


        
    }
}
