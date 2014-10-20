using System.Linq;
using System.Web;
using Sitecore.Data.Items;
using Sitecore.Data.Managers;
using Sitecore.Globalization;

namespace CoreLib
{
    /// <summary>
    /// Class with extension methods for class <see cref="Sitecore.Data.Items.Item"/>.
    /// </summary>
    /// <author>Kevin Brechbühl - Unic AG</author>
    public static class ItemExtension
    {
        /// <summary>
        /// Extension method to check if the item has at least one version in a given language.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="language">The language.</param>
        /// <param name="availableLanguages">Comma-separated list of available languages. If the given language is not in this list, method returns <c>false</c>. Leave empty for accepting all languages.</param>
        /// <returns><c>True</c> if item has a valid language version, <c>false</c> otherwise.</returns>
        public static bool HasLanguageVersion(this Item item, Language language, string availableLanguages)
        {
           
            Item itemInLang = ItemManager.GetItem(item.ID, language, Sitecore.Data.Version.Latest, item.Database);
            if (itemInLang != null && itemInLang.Versions.GetVersions().Length > 0)
            {
                if (string.IsNullOrEmpty(availableLanguages)
                || (HttpContext.Current != null && HttpContext.Current.Request.QueryString["em_force"] == "true")
                || availableLanguages.ToLower().Split(',').Contains<string>(itemInLang.Language.Name.ToLower()))
                {
                    return true;
                }
            }
            return false;
        }
    }

    public static class StringExtensions
    {
        /// <summary>ip
        public static string ToTitleCase(this string str)
        {
            var cultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
            return cultureInfo.TextInfo.ToTitleCase(str.ToLower());
        }
    }
}