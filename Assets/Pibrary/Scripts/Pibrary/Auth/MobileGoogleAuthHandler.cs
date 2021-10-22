using System.Threading.Tasks;
using Google;
using Pibrary.Config;
using UnityEngine;

namespace Pibrary.Auth
{
    public class MobileGoogleAuthHandler : IGoogleAuthHandler
    {
        private bool initialized;
        
        public async Task<string> getIdToken()
        {
            if (!initialized)
            {
                string clientID = ConfigProvider.OAuthConfig.cliendID;
                Debug.Log(clientID);
                GoogleSignIn.Configuration = new GoogleSignInConfiguration {
                    RequestIdToken = true,
                    // Copy this value from the google-service.json file.
                    // oauth_client with type == 3
                    WebClientId = clientID
                };
                initialized = true;
            }
            
            Task<GoogleSignInUser> signInTask = GoogleSignIn.DefaultInstance.SignIn();
            await signInTask;
            
            if (signInTask.IsCanceled)
            {
                Debug.LogError("GoogleSignIn was canceled.");
                return "";
            }
            if (signInTask.IsFaulted) {
                Debug.LogError("GoogleSignIn was error.");
                return "";
            }

            return signInTask.Result.IdToken;
        }
    }
}