using Autofac;
using Sitetree.Core.DataAccess.Repositories;
using Sitetree.Core.DataAccess.Repositories.Interfaces;
using Sitetree.Core.DataAccess.Services;
using Sitetree.Core.DataAccess.Services.Interfaces;

namespace Sitetree.Core
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(b => new SiteRepository()).As<ISiteRepository>();
            builder.Register(b => new DatabaseMigrationService()).As<IDatabaseMigrationService>();
        }
    }
}