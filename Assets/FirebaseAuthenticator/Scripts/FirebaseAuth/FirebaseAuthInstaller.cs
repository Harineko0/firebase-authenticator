using FirebaseAuth.Config;
using Zenject;

namespace FirebaseAuth
{ 
    public class FirebaseAuthInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            // Container.Bind<IConfigLoader>().To<AddressableConfigLoader>().AsCached();
        }
    }
}