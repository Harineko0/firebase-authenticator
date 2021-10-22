using System;
using System.Threading.Tasks;
using GoogleOAuth;
using Pibrary.Config;
using UniRx;
using UnityEngine;
using UnityEngine.Assertions;

namespace Pibrary.Auth
{
    public class FirebaseAuthHandler : IAuthHandler
    {
        private Subject<LoadingState> stateSubject = new Subject<LoadingState>();
        public IObservable<LoadingState> OnStateChanged
        {
            get { return stateSubject; }
        }

        public async void OAuthSignIn()
        {
            stateSubject.OnNext(LoadingState.Loading);
            string clientID = ConfigProvider.OAuthConfig.cliendID;
            string clientSecret = ConfigProvider.OAuthConfig.clientSecret;
            Assert.IsNotNull(clientID, "CliendID is null.");
            Assert.IsNotNull(clientSecret, "CliendID is null.");
            
            var authResult = await AuthorizeGoogle(clientID);
            // if (authResult == null)
            // {
            //     stateSubject.OnError(new Exception());
            //     return;
            // }
            
            Debug.Log(authResult);

            // var tokenResult = await GetAccessTokenGoogle(clientID, clientSecret, authResult);
            // if (tokenResult == null)
            // {
            //     stateSubject.OnError(new Exception());
            //     return;
            // }
            //
            // stateSubject.OnNext(LoadingState.Completed);
            // Debug.Log(tokenResult.AccessToken);
        }

        private async Task<AuthorizationCodeProvider.Result> AuthorizeGoogle(string clientID)
        {
                
            var provider = new AuthorizationCodeProvider(clientID);
            var handle = await provider.ProvideAsync();
            AuthorizationCodeProvider.Result result = null;
            
            if (!handle.IsFailed)
            {
                result = handle.Result;
            }
            provider.Dispose();

            return result;
        }

        private async Task<AccessTokenProvider.Result> GetAccessTokenGoogle(string clientID, string clientSecret, AuthorizationCodeProvider.Result authResult)
        {
            var provider = new AccessTokenProvider(clientID, clientSecret);
            var handle = await provider.ProvideAsync(authResult.AuthorizationCode, authResult.CodeVerifier, authResult.RedirectUri);
            AccessTokenProvider.Result result = null;
            
            if (!handle.IsFailed)
            {
                result = handle.Result;
            }

            return result;
        }

        public void EmailSignIn(string email, string password)
        {
            stateSubject.OnNext(LoadingState.Loading);
            
        }
    }
}