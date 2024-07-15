using Autofac;
using Todo.Data.TodoList;

namespace Todo.Data.Infrastructure
{
    public class InfrastructureAutofac : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(Todo_Repository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}
