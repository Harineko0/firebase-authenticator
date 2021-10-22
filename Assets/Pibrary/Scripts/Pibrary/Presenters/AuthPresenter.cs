using Pibrary.Auth;
using Pibrary.Config;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Pibrary.Presenters
{
    public class AuthPresenter : MonoBehaviour
    {
        [SerializeField] private Button googleButton;
        [SerializeField] private Text log;
        
        private void Start()
        {
            Pibrary.DefaultInstance.Initialize();
            
            IAuthHandler authHandler = Pibrary.DefaultInstance.AuthHandler;
            
            googleButton
                .OnClickAsObservable()
                .Subscribe(_ => authHandler.CallGoogleSignIn())
                .AddTo(this);

            authHandler.OnStateChanged
                .Subscribe(state =>
                {
                    if (state == LoadingState.Loading)
                    {
                        Debug.Log("Loading ");
                        log.text = "Loading";
                    }
                    if (state == LoadingState.Completed)
                    {
                        Debug.Log("Complete");
                        log.text = "Complete";
                    }
                });
        }
    }
}