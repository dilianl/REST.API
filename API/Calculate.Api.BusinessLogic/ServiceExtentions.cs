using Lamar;

namespace Calculate.Api.BusinessLogic
{
    public static class ServiceExtentions
    {
        public static void AddMyServices(this ServiceRegistry registry)
        {
            registry.IncludeRegistry<ServiceRegistryLocal>();
        }
    }
}
