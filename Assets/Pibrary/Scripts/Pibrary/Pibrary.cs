using Pibrary.Config;

namespace Pibrary
{
    public class Pibrary
    {
        #region Singleton
        
        private Pibrary() {}
        private static Pibrary instance = new Pibrary();
        public static Pibrary DefaultInstance { get => instance; }
        
        #endregion
        
        public void Initialize()
        {
            ConfigProvider.Initialize();
        }
    }
}