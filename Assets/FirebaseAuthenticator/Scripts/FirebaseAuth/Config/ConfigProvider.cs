// https://qiita.com/toRisouP/items/7765cf891a93bdcf65bc

using UnityEngine;
using UnityEngine.AddressableAssets;

namespace FirebaseAuth.Config
{
    public static class ConfigProvider
    {
        private static ConfigLoader _configLoader;

        private static ConfigLoader Loader
        {
            get
            {
                //ConfigComponentが存在しないなら新しく生成する
                if (_configLoader != null)
                {
                    return _configLoader;
                }
                else
                {
                    Debug.Log("Loading ConfigLoader");
                    var op = Addressables.LoadAssetAsync<GameObject>(Constant.getAssetPath("ConfigLoader"));
                    GameObject gameObject = op.WaitForCompletion();
                    GameObject instance = GameObject.Instantiate(gameObject);
                    _configLoader = instance.GetComponent<ConfigLoader>();
                    return _configLoader;
                }
            }
        }
        
        public static OAuthConfig OAuthConfig
        {
            get { return Loader.Config.OAuthConfig; }
        }

        public static void Initialize()
        {
            ConfigLoader loader = Loader;
        }
    }
}
