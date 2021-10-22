using System;
using System.Threading.Tasks;
using Pibrary.Config;
using UniRx;
using UnityEngine;

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
            
            Firebase.Auth.FirebaseAuth auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
            Firebase.Auth.Credential credential = Firebase.Auth.GoogleAuthProvider.GetCredential(idToken, null);
            Task<Firebase.Auth.FirebaseUser> signInTask = auth.SignInWithCredentialAsync(credential);
            
            await signInTask;
            
            if (signInTask.IsCanceled)
            {
                Debug.LogError("SignInWithCredentialAsync was canceled.");
                return;
            }
            if (signInTask.IsFaulted) {
                Debug.LogError("SignInWithCredentialAsync encountered an error: " + signInTask.Exception);
                return;
            }
            
            Firebase.Auth.FirebaseUser newUser = signInTask.Result;
            Debug.LogFormat("User signed in successfully: {0} ({1})",
                newUser.DisplayName, newUser.UserId);
            
            stateSubject.OnNext(LoadingState.Completed);
        }

        public void CallEmailSignIn(string email, string password)
        {
            stateSubject.OnNext(LoadingState.Loading);
            
        }
    }
}