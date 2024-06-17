using System.Globalization;
using System.Collections.Generic;
using CountClickKey.Resources;

namespace CountClickKey.Localization
{
    public class ResxLocalizationProvider : ILocalizationProvider
    {
        private IEnumerable<CultureInfo> _cultures;

        public object Localize(string key)
        {
            return lang.ResourceManager.GetObject(key);
        }

        public IEnumerable<CultureInfo> Cultures => _cultures ?? (_cultures = new List<CultureInfo>
        {
            new CultureInfo("en-US"),
            new CultureInfo("ru-RU"),
        });
    }
}
