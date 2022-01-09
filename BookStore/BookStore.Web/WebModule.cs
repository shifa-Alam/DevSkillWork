using Autofac;
using BookStore.Web.Models;

namespace BookStore.Web
{
    public class WebModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Test2>().As<ITest>()
                .InstancePerLifetimeScope();

            builder.RegisterType<IndexModel>().AsSelf();

            base.Load(builder);
        }
    }
}
