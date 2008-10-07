using System;
using System.Configuration;

namespace ControlAdapters.Configuration
{
	public static class ControlAdaptersConfiguration
	{
		private static ControlAdaptersConfigurationSection _config;

		/// <summary>
		/// Initializes a new instance of a <see cref="ControlAdaptersConfiguration"/>.
		/// </summary>
		static ControlAdaptersConfiguration()
		{
			 _config = ConfigurationManager.GetSection("ControlAdapters") as ControlAdaptersConfigurationSection;

			 if (_config == null)
			 {
				 _config = new ControlAdaptersConfigurationSection();
			 }
		}

		public static ControlAdaptersConfigurationSection Settings
		{
			get { return _config; }
		}
	}
}
