
using Calculate.Api.BusinessLogic.Interfaces;
using Calculate.Api.Dto.Api;
using Calculate.Api.Dto.Interfaces;
using Lamar;

namespace Calculate.Api.BusinessLogic
{
    public class ServiceRegistryLocal : ServiceRegistry
    {
        public ServiceRegistryLocal()
        {
            For<ICalculateService>().Use<CalculateService>();
            For<ITwoIntNumbersDTO>().Use<TwoIntNumbersDTO>();
        }
    }

    public static class ServiceContainerExtentions
    {
        public static ServiceRegistry AddServices(this ServiceRegistry registry)
        {
            registry.IncludeRegistry<ServiceRegistryLocal>();

            return registry;
        }
    }
}
