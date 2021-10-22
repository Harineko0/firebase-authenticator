using System;
using GoogleOAuth;
using Pibrary.Config;
using UniRx;
using UnityEngine;

namespace Pibrary.Auth
{
    public class TestAuthHandler : IAuthHandler
    {
        private Subject<LoadingState> stateSubject = new Subject<LoadingState>();
        public IObservable<LoadingState> OnStateChanged
        {
            get { return stateSubject; }
        }

        public async void GoogleSignIn()
        {
            // Assert.That(_clientId, Is.Not.Null.Or.Empty);

            string _clientId = "852955764328-pvpflecs80i6nhf04daqbk6tjvahaknb.apps.googleusercontent.com";
            var provider = new AuthorizationCodeProvider(_clientId);
            var handle = await provider.ProvideAsync();
            if (!handle.IsFailed)
            {
                var result = handle.Result;
                Debug.Log(result);
            }
            provider.Dispose();
        }

        public void EmailSignIn(string email, string password)
        {
            stateSubject.OnNext(LoadingState.Loading);
            
        }
    }
}