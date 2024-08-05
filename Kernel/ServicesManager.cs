using Kernel.Interfaces;

namespace Kernel
{
    public static class ServicesManager
    {
        private static IServiceProvider serviceProvider;
        public static IDAL DataBase => serviceProvider.GetService(typeof(IDAL)) as IDAL;

        public static void Initialize(IServiceProvider provider)
        {
            serviceProvider = provider;
        }
    }
}
