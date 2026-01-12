using Microsoft.Win32;

namespace SimpleXorCipher
{
    static class Preferences
    {
        private static readonly RegistryKey _appRK = Registry.CurrentUser.CreateSubKey($@"SOFTWARE\{Common.AssemblyName}");

        public static int IntKey
        {
            get
            {
                object obj = _appRK.GetValue("IntKey");
                if(obj is int val) return val;
                return 0;
            }
            set => _appRK.SetValue("IntKey", value, RegistryValueKind.DWord);
        }

        public static string StringKey
        {
            get
            {
                object obj = _appRK.GetValue("StringKey");
                if (obj is string val) return val;
                return null;
            }
            set => _appRK.SetValue("StringKey", value, RegistryValueKind.String);
        }
    }
}
