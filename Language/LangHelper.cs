using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Resources;
using System.Globalization;
using System.Reflection;
using Azure.Core;
namespace Pomocnik_Rozgrywek.Language
{
    public static class LangHelper
    {
        private static ResourceManager _rm;
        static LangHelper()
        {
            _rm = new ResourceManager("Pomocnik_Rozgrywek.Language.Strings",Assembly.GetExecutingAssembly());
        }

        public static string? GetString(string name)
        { return _rm.GetString(name); }
        public static void ChangeLanguage(string language)
        {
            var cultureInfo = new CultureInfo(language);
            CultureInfo.CurrentCulture = cultureInfo;
            CultureInfo.CurrentUICulture = cultureInfo;
        }
    }
}
