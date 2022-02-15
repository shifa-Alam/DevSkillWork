using Autofac;

namespace TicketingSystem.Web
{
    public class WebModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            //builder.RegisterType<CourseModel>().AsSelf();
            //builder.RegisterType<CourseCreateModel>().AsSelf();
            //builder.RegisterType<CourseListModel>().AsSelf();
            //builder.RegisterType<CourseEditModel>().AsSelf();
            //builder.RegisterType<StudentCreateModel>().AsSelf();
            //builder.RegisterType<StudentListModel>().AsSelf();
            //builder.RegisterType<StudentEditModel>().AsSelf();
            //builder.RegisterType<EnrollmentCreateModel>().AsSelf();

            base.Load(builder);
        }
    }


}
