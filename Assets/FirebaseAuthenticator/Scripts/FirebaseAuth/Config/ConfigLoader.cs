using System;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace FirebaseAuth.Config
{
    public enum ConfigEnvironment
    {
        Development,
        Production,
    }
    
    public class ConfigLoader : SingletonMonoBehaviour<ConfigLoader>
    {
        [SerializeField]
        private ConfigEnvironment targetEnv = ConfigEnvironment.Development;
        private FirebaseAuthConfigs config;

        void Awake()
        {
            //シーンをまたいでも消さない
            DontDestroyOnLoad(gameObject);
            LoadConfig();
        }

        /// <summary>
        /// Conf値
        /// </summary>
        public FirebaseAuthConfigs Config
        {
            //configがnullならロードしてキャッシュする
            get
            {
                if (config == null)
                {
                    Debug.Log("FirebaseAuthConfig is not loaded yet.");
                }
                return config;
            }
        }

        /// <summary>
        /// 環境別設定値読み込み
        /// </summary>
        /// <returns></returns>
        private async void LoadConfig()
        {
            AsyncOperationHandle<FirebaseAuthConfigs> op;
            // 愚直にswitchで
            // 他にもっといい方法あるかも
            switch (targetEnv)
            {
                case ConfigEnvironment.Development:
                    op = Addressables.LoadAssetAsync<FirebaseAuthConfigs>(Constant.getAssetPath("DevelopmentConfig"));
                    break;
                case ConfigEnvironment.Production:
                    op = Addressables.LoadAssetAsync<FirebaseAuthConfigs>(Constant.getAssetPath("ProductionConfig"));
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            FirebaseAuthConfigs configs = await op.Task;
            this.config = configs;
            Addressables.Release(op);
        }
    }
}