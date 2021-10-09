using FirebaseAuth.Config;
using UniRx;
using UnityEngine;
using Zenject;

namespace FirebaseAuth
{
    public class OAuthHandler : MonoBehaviour
    {
        private void Start()
        {
            FirebaseAuth.Initialize();
        }

        // Start is called before the first frame update
        public void OnClick()
        {
            var cliendID = ConfigProvider.OAuthConfig.cliendID;
            Debug.Log(cliendID);
        }
    }
}
