using System;
using System.Configuration;
using MigSharp;

namespace Sitetree.Core.Helpers
{
    /// <summary>
    ///     Helper class for web.config configuration values.
    /// </summary>
    public static class SitetreeConfiguration
    {
        /// <summary>
        ///     Retrieves the 'DefaultConnection' connection string.
        /// </summary>
        public static string ConnectionString
            => ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        /// <summary>
        ///     Retrieves the 'Sitetree.DbPlatform' database platform value.
        ///     This value should be a <see cref="Platform"/> enum value.
        /// </summary>
        public static Platform DbPlatform
        {
            get
            {
                Platform dbPlatform;
                var dbProviderSetting = ConfigurationManager.AppSettings["Sitetree.DbPlatform"];
                if (Enum.TryParse(dbProviderSetting, out dbPlatform))
                {
                    return dbPlatform;
                }
                return Platform.SqlServer;
            }
        }

        /// <summary>
        ///     Retrieves the 'Sitetree.DbVersion' database version value.
        ///     This value should be an <see cref="int"/> value.
        /// </summary>
        public static int DbVersion
        {
            get
            {
                int dbVersion;
                var dbProviderSetting = ConfigurationManager.AppSettings["Sitetree.DbVersion"];
                if (int.TryParse(dbProviderSetting, out dbVersion))
                {
                    return dbVersion;
                }
                return 14;
            }
        }
    }
}