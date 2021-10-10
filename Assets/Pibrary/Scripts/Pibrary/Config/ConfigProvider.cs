using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;

namespace Pibrary.Config
{
    public static class ConfigProvider
    {
        private static IConfigLoader configLoader;

        private static IConfigLoader Loader
        {
            get
            {
                if (configLoader != null)
                {
                    return configLoader;
                }
                else
                {
                    Debug.Log("Loading ConfigLoader");
                    var op = Addressables.LoadAssetAsync<GameObject>(Constant.getAssetPath("ConfigLoader"));
                    GameObject gameObject = op.WaitForCompletion();
                    GameObject instance = GameObject.Instantiate(gameObject);
                    configLoader = instance.GetComponent<IConfigLoader>();
                    return Loader;
                }
            }
        }

        public static OAuthConfig OAuthConfig
        {
            get { return Loader.Config.OAuthConfig; }
        }
        
        public static void Initialize()
        {
            IConfigLoader loader = Loader;
        }
    }
}