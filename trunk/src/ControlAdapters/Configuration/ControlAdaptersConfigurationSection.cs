using System;
using System.Configuration;

namespace ControlAdapters.Configuration
{
	/// <summary>
	/// Represents the ControlAdapters configuration section within a configuration file.
	/// </summary>
	/// <example>
	/// To implement the ControlAdapters configuration section, add the appropriate declaration to the
	/// <code>configSections</code> section of the configuration file, and add the <code>ControlAdapters</code>
	/// section with your desired configuration.
	/// 
	/// <![CDATA[
	/// <configuration>
	///		<configSections>
	///			<section name="ControlAdapters" type="ControlAdapters.Configuration.ControlAdaptersConfigurationSection, ControlAdapters" />
	///		</configSections>
	///		<ControlAdapters enabled="False">
	///		</ControlAdapters>
	///	</configuration>
	///	]]>
	/// </example>
	public class ControlAdaptersConfigurationSection : ConfigurationSection
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ControlAdaptersConfigurationSection"/> class with default values.
		/// </summary>
		public ControlAdaptersConfigurationSection()
		{
		}

		[ConfigurationProperty("CheckBoxList", IsRequired = false)]
		public CheckBoxListSettings CheckBoxList
		{
			get
			{
				if (this["CheckBoxList"] == null)
					return CheckBoxListSettings.Default;
				else
					return (CheckBoxListSettings)this["CheckBoxList"];
			}
			set { this["CheckBoxList"] = value; }
		}
	}
}
