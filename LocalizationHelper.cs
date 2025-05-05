using System;
using System.Globalization;
using System.Resources;
using System.Threading;

namespace Restaurant_Management_System
{
    public static class LocalizationHelper
    {
        public static void SetLanguage(string cultureCode)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(cultureCode);
        }

        public static string GetString(string key)
        {
            ResourceManager rm = new ResourceManager("Restaurant_Management_System.Strings", typeof(LocalizationHelper).Assembly);
            return rm.GetString(key);
        }
    }
}
