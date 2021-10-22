using System;
using Pibrary.Config;
using UniRx;

namespace Pibrary.Auth
{
    public class FirebaseAuthHandler : IAuthHandler
    {
        private Subject<LoadingState> stateSubject = new Subject<LoadingState>();
        public IObservable<LoadingState> OnStateChanged
        {
            get { return stateSubject; }
        }
        
        private IGoogleAuthHandler googleAuth;


        public FirebaseAuthHandler()
        {
            googleAuth = new MobileGoogleAuthHandler();
        }
        
        public async void CallGoogleSignIn()
        {
            stateSubject.OnNext(LoadingState.Loading);
            
            string idToken = await googleAuth.getIdToken();
            

        }

        public void CallEmailSignIn(string email, string password)
        {
            stateSubject.OnNext(LoadingState.Loading);
            
        }
    }
}