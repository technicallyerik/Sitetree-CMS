using Autofac;
using Sitetree.Core.DataAccess.Repositories;
using Sitetree.Core.DataAccess.Repositories.Interfaces;

namespace Sitetree.Core
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new SiteRepository()).As<ISiteRepository>();
        }
    }
}