using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.Runtime.CompilerServices;

namespace WpfApp1
{
    public static class MyAppParamManager
    {
        private static readonly string RegistryKeyPath1 = "SOFTWARE\\FastFood\\AppParameter\\ParamPositionApp";
        private static readonly string RegistryKeyPath2 = "SOFTWARE\\FastFood\\AppParameter\\ParamTailleApp";


        public static int PositionX
        {
            get => GetValueOrDefault1();
            set => SetValue1(value);
        }

        public static int PositionY
        {
            get => GetValueOrDefault1();
            set => SetValue1(value);
        }

        public static int Height
        {
            get => GetValueOrDefault2();
            set => SetValue2(value);
        }

        public static int Width
        {
            get => GetValueOrDefault2();
            set => SetValue2(value);
        }

        private static int GetValueOrDefault1([CallerMemberName] string propertyName = "")
        {
            using (var registryKey = Registry.CurrentUser.OpenSubKey(RegistryKeyPath1))
            {
                if (registryKey != null)
                {
                    var value = registryKey.GetValue(propertyName);
                    if (value != null && int.TryParse(value.ToString(), out int propertyValue))
                    {
                        return propertyValue;
                    }
                }
            }

            return 0; // Valeur par défaut si la clé ou la valeur n'existent pas
        }

        private static void SetValue1(int value, [CallerMemberName] string propertyName = "")
        {
            using (var registryKey = Registry.CurrentUser.CreateSubKey(RegistryKeyPath1))
            {
                if (registryKey != null)
                {
                    registryKey.SetValue(propertyName, value);
                }
            }
        }

        private static int GetValueOrDefault2([CallerMemberName] string propertyName = "")
        {
            using (var registryKey = Registry.CurrentUser.OpenSubKey(RegistryKeyPath2))
            {
                if (registryKey != null)
                {
                    var value = registryKey.GetValue(propertyName);
                    if (value != null && int.TryParse(value.ToString(), out int propertyValue))
                    {
                        return propertyValue;
                    }
                }
            }

            return 0; // Valeur par défaut si la clé ou la valeur n'existent pas
        }
        private static void SetValue2(int value, [CallerMemberName] string propertyName = "")
        {
            using (var registryKey = Registry.CurrentUser.CreateSubKey(RegistryKeyPath2))
            {
                if (registryKey != null)
                {
                    registryKey.SetValue(propertyName, value);
                }
            }
        }
    }

}
