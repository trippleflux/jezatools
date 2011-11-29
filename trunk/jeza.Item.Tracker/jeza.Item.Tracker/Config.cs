using System;
using System.Configuration;
using NLog;

namespace jeza.Item.Tracker
{
    public static class Config
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Gets the key value from configuration file.
        /// </summary>
        /// <param name="keyName">Name of the key.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>Key value or <see cref="defaultValue"/></returns>
        public static string GetKeyValue(string keyName,
                                         string defaultValue)
        {
            return GetKeyValue(keyName) ?? defaultValue;
        }

        /// <summary>
        /// Gets the key value from configuration file.
        /// </summary>
        /// <param name="keyName">Name of the key.</param>
        /// <returns>Key value or <c>null</c>.</returns>
        public static string GetKeyValue(string keyName)
        {
            Log.Debug("GetKeyValue '{0}'", keyName);
            try
            {
                string appSetting = ConfigurationManager.AppSettings[keyName];
                if (appSetting == null)
                {
                    Log.Warn("Failed to get key[\"{0}\"]", keyName);
                }
                return appSetting;
            }
            catch (Exception exception)
            {
                Log.Error(exception.ToString);
            }
            return null;
        }

        public static string DataSource
        {
            get { return GetKeyValue("DataSource"); }
        }
    }
}