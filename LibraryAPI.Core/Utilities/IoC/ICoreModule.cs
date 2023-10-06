using Microsoft.Extensions.DependencyInjection;

namespace LibraryAPI.Core.Utilities.IoC
{
    public interface ICoreModule
    {
        void Load(IServiceCollection serviceCollection);
    }
}
