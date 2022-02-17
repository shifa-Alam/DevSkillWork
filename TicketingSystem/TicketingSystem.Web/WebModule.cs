using Autofac;
using TicketingSystem.Web.Models;

namespace TicketingSystem.Web
{
    public class WebModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TicketPurchaseListModel>().AsSelf();
            builder.RegisterType<TicketPurchaseModel>().AsSelf();
            builder.RegisterType<PuchaseTicketEditModel>().AsSelf();

            base.Load(builder);
        }
    }


}
