using System;
using UniRx;
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

    public enum LoadingState
    {
        WaitingToLoad,
        Loading,
        Completed
    }
    
    public class ConfigLoader : SingletonMonoBehaviour<ConfigLoader>
    {
        [SerializeField]
        private ConfigEnvironment targetEnv = ConfigEnvironment.Development;
        private FirebaseAuthConfig _config;
        private Subject<LoadingState> stateSubject = new Subject<LoadingState>();
        public IObservable<LoadingState> OnStateChanged
        {
            get { return stateSubject; }
        }

        void Awake()
        {
            //シーンをまたいでも消さない
            DontDestroyOnLoad(gameObject);
            LoadConfig();
            stateSubject.OnNext(LoadingState.WaitingToLoad);
        }

        /// <summary>
        /// Conf値
        /// </summary>
        public FirebaseAuthConfig Config
        {
            //configがnullならロードしてキャッシュする
            get
            {
                if (_config == null)
                {
                    Debug.Log("FirebaseAuthConfig is not loaded yet.");
                }
                return _config;
            }
        }

        /// <summary>
        /// 環境別設定値読み込み
        /// </summary>
        /// <returns></returns>
        private async void LoadConfig()
        {
            stateSubject.OnNext(LoadingState.Loading);
            AsyncOperationHandle<FirebaseAuthConfig> op;
            // 愚直にswitchで
            // 他にもっといい方法あるかも
            switch (targetEnv)
            {
                case ConfigEnvironment.Development:
                    op = Addressables.LoadAssetAsync<FirebaseAuthConfig>(Constant.getAssetPath("DevelopmentConfig"));
                    break;
                case ConfigEnvironment.Production:
                    op = Addressables.LoadAssetAsync<FirebaseAuthConfig>(Constant.getAssetPath("ProductionConfig"));
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            FirebaseAuthConfig config = await op.Task;
            this._config = config;
            Addressables.Release(op);
            stateSubject.OnNext(LoadingState.Completed);
        }
    }
}