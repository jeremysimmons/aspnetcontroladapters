using System;
using System.Configuration;

namespace ControlAdapters.Configuration
{
	/// <summary>
	/// Provides access to the configuration options for the control adapters
	/// as defined in the application's configuration file.
	/// </summary>
	public static class ControlAdaptersConfiguration
	{
		private static ControlAdaptersConfigurationSection _config;

		/// <summary>
		/// Initializes the static instance of a <see cref="ControlAdaptersConfiguration"/> by reading
		/// the <c>ControlAdapters</c> section of the application's configuration file.
		/// </summary>
		static ControlAdaptersConfiguration()
		{
			 _config = ConfigurationManager.GetSection("ControlAdapters") as ControlAdaptersConfigurationSection;

			 if (_config == null)
			 {
				 _config = new ControlAdaptersConfigurationSection();
			 }
		}

		/// <summary>
		/// Returns the <see cref="ControlAdaptersConfigurationSection"/> based on the application's
		/// configuration file.
		/// </summary>
		public static ControlAdaptersConfigurationSection Settings
		{
			get { return _config; }
		}
	}
}
