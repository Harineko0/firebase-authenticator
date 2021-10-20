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
        
        private void Start()
        {
            Pibrary.DefaultInstance.Initialize();
            
            IAuthHandler authHandler = Pibrary.DefaultInstance.AuthHandler;
            
            googleButton
                .OnClickAsObservable()
                .Subscribe(_ => authHandler.GoogleSignIn())
                .AddTo(this);

            authHandler.OnStateChanged
                .Subscribe(state =>
                {
                    if (state == LoadingState.Completed)
                    {
                        Debug.Log("Complete");
                    }
                });
        }
    }
}