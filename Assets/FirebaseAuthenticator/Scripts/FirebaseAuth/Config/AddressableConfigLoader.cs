using System;
using UniRx;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace FirebaseAuth.Config
{
    public class AddressableConfigLoader : SingletonMonoBehaviour<AddressableConfigLoader>, IConfigLoader
    {
        [SerializeField] private ConfigEnvironment Environment = ConfigEnvironment.Development;
        private FirebaseAuthConfig config;
        private Subject<LoadingState> stateSubject = new Subject<LoadingState>();
        public IObservable<LoadingState> OnStateChanged
        {
            get { return stateSubject; }
        }

        private void Awake()
        {
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
                if (config == null)
                {
                    Debug.Log("FirebaseAuthConfig is not loaded yet.");
                    LoadConfig();
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
            stateSubject.OnNext(LoadingState.Loading);
            AsyncOperationHandle<FirebaseAuthConfig> op;
            // 愚直にswitchで
            // 他にもっといい方法あるかも
            switch (Environment)
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

            FirebaseAuthConfig result = await op.Task;
            this.config = result;
            Addressables.Release(op);
            stateSubject.OnNext(LoadingState.Completed);
        }
    }
}