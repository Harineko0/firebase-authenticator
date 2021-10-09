using FirebaseAuth.Config;
using UniRx;
using UnityEngine;
using Zenject;

namespace FirebaseAuth
{
    public class OAuthHandler : MonoBehaviour
    {
        [Inject] 
        private IConfigProvider configProvider;
        
        private void Start()
        {
            FirebaseAuth.Initialize();
        }

        // Start is called before the first frame update
        public void OnClick()
        {
            var cliendID = configProvider.Config.OAuthConfig.clientSecret;
            Debug.Log(cliendID);
        }
    }
}
