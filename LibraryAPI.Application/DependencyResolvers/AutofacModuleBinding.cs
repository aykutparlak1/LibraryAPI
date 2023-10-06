using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using LibraryAPI.Core.Utilities.Interceptors;

namespace LibraryAPI.Application.DependencyResolvers
{
    public class AutofacModuleBinding : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
