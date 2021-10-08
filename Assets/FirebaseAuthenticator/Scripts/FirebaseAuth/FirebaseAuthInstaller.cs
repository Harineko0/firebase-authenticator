using FirebaseAuth.Config;
using Zenject;

namespace FirebaseAuth
{ 
    public class FirebaseAuthInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IConfigProvider>().To<AddressableConfigProvider>().AsCached();
        }
    }
}