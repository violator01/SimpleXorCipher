using System.Reflection;

namespace SimpleXorCipher
{
    static class Common
    {
        public const string AppName = "Simple XOR Cipher";
        public const string AppVersion = "1.0.0.0";
        public const string AppShortVersion = "1.0";

        public static string AssemblyName => Assembly.GetExecutingAssembly().GetName().Name;
    }
}
