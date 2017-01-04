using Blog_Petar_Belberov.Migrations;
using Blog_Petar_Belberov.Models;
using Microsoft.Owin;
using Owin;
using System.Data.Entity;

[assembly: OwinStartupAttribute(typeof(Blog_Petar_Belberov.Startup))]
namespace Blog_Petar_Belberov
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<BlogDBContext, Configuration>());
             
            ConfigureAuth(app);
        }
    }
}
