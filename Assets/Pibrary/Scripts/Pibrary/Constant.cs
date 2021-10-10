using Pibrary.Config;

namespace Pibrary
{
    public static class Constant
    {
        public readonly static string ROOT_PATH = "Pibrary/";
        
        public static string getAssetPath(string name)
        {
            return ROOT_PATH + name;
        }
    }
}