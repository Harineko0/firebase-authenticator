using System;
using System.Collections;
using System.Collections.Generic;
using FirebaseAuth.Config;
using UnityEngine;

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
            var cliendID = ConfigProvider.OAuthConfig.clientSecret;
            Debug.Log(cliendID);
        }
    }
}
