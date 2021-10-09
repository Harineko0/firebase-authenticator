using FirebaseAuth.Config;

namespace FirebaseAuth
{
    public static class Constant
    {
        public readonly static string ROOT_PATH = "FirebaseAuthenticator/";
        
        public static string getAssetPath(string name)
        {
            return ROOT_PATH + name;
        }
    }
}