using System;
using UnityEngine;

namespace FirebaseAuth.Config
{
    [CreateAssetMenu(fileName = "Data", menuName = "FirebaseAuthenticator/Scriptable/Create FirebaseAuthConfig")]
    [Serializable]
    public class FirebaseAuthConfig : ScriptableObject
    {
        [SerializeField]
        public OAuthConfig OAuthConfig = new OAuthConfig();
    }
    
    [Serializable]
    public class OAuthConfig
    {
        public string cliendID = "";
        public string clientSecret = "";
    }
}