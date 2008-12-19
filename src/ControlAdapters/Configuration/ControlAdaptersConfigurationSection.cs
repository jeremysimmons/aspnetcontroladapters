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

		/// <summary>
		/// Provides access to the <see cref="CheckBoxListSettings"/>.
		/// If no settings are defined, the default settings from <see cref="CheckBoxListSettings.Default"/> are returned.
		/// </summary>
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

		/// <summary>
		/// Provides access to the <see cref="RadioButtonListSettings"/>.
		/// If no settings are defined, the default settings from <see cref="RadioButtonListSettings.Default"/> are returned.
		/// </summary>
		[ConfigurationProperty("RadioButtonList", IsRequired = false)]
		public RadioButtonListSettings RadioButtonList
		{
			get
			{
				if (this["RadioButtonList"] == null)
					return RadioButtonListSettings.Default;
				else
					return (RadioButtonListSettings)this["RadioButtonList"];
			}
			set { this["RadioButtonList"] = value; }
        }

        /// <summary>
        /// Provides access to the <see cref="MenuSettings"/>.
        /// If no settings are defined, the default settings from <see cref="MenuSettings.Default"/> are returned.
        /// </summary>
        [ConfigurationProperty("Menu", IsRequired = false)]
        public MenuSettings Menu
        {
            get
            {
                if (this["Menu"] == null)
                    return MenuSettings.Default;
                else
                    return (MenuSettings)this["Menu"];
            }
            set { this["Menu"] = value; }
        }

        /// <summary>
        /// Provides access to the <see cref="WizardSettings"/>.
        /// If no settings are defined, the default settings from <see cref="WizardSettings.Default"/> are returned.
        /// </summary>
        [ConfigurationProperty("Wizard", IsRequired = false)]
        public MenuSettings Wizard
        {
            get
            {
                if (this["Wizard"] == null)
                    return MenuSettings.Default;
                else
                    return (MenuSettings)this["Wizard"];
            }
            set { this["Wizard"] = value; }
        }
	}
}
