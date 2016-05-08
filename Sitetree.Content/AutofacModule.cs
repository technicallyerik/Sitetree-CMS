using Autofac;
using Autofac.Integration.Mvc;
using Sitetree.Content.DataAccess.Repositories;
using Sitetree.Content.DataAccess.Repositories.Interfaces;

namespace Sitetree.Content
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterControllers(typeof(AutofacModule).Assembly);
            builder.Register(c => new PageRepository()).As<IPageRepository>();
        }
    }
}