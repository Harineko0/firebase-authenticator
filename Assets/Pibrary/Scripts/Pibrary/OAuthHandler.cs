using Pibrary.Config;
using UniRx;
using UnityEngine;
using Zenject;

namespace Pibrary
{
    public class OAuthHandler : MonoBehaviour
    {
        private void Start()
        {
            Pibrary.Instance.Initialize();
        }

        // Start is called before the first frame update
        public void OnClick()
        {
            var cliendID = ConfigProvider.OAuthConfig.cliendID;
            Debug.Log(cliendID);
        }
    }
}
