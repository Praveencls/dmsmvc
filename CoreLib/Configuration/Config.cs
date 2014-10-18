using Sitecore.Configuration;

namespace CoreLib.Configuration
{
    public static class Config
    {
        public static bool ProcessSystemFields
        {
            get
            {
                return Settings.GetBoolSetting("Fallback.ProcessSystemFields", false);
            }
        }

        public static string IgnoredFields
        {
            get
            {
                return Settings.GetSetting("Fallback.IgnoredFields");
            }
        }
    }
}
