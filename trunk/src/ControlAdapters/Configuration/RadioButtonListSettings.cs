using System;
using System.Configuration;
using ControlAdapters.Adapters;

namespace ControlAdapters.Configuration
{
	/// <summary>
	/// Represents the configuration settings for the <see cref="RadioButtonListAdapter"/>.
	/// </summary>
	public class RadioButtonListSettings : ConfigurationElement
	{
		private static readonly RadioButtonListSettings _defaultSettings = new RadioButtonListSettings();

		/// <summary>
		/// Initializes a new instance of <see cref="RadioButtonListSettings"/>.
		/// </summary>
		public RadioButtonListSettings()
		{
		}

		/// <summary>
		/// Gets an instance of <see cref="RadioButtonListSettings"/> providing default values.
		/// </summary>
		public static RadioButtonListSettings Default
		{
			get { return _defaultSettings; }
		}

		/// <summary>
		/// Gets or sets the CSS class used by the <see cref="RadioButtonListAdapter"/>.
		/// </summary>
		[ConfigurationProperty("cssClass", IsRequired = false)]
		public string CssClass
		{
			get
			{
				if (base["cssClass"] == null)
					return String.Empty;
				else
					return (string)base["cssClass"];
			}
			set { base["cssClass"] = value; }
		}

		/// <summary>
		/// Gets or sets the CSS class used to mark a disabled control.
		/// </summary>
		[ConfigurationProperty("disabledCssClass", IsRequired = false)]
		public string DisabledCssClass
		{
			get
			{
				if (base["disabledCssClass"] == null)
					return String.Empty;
				else
					return (string)base["disabledCssClass"];
			}
			set { base["disabledCssClass"] = value; }
		}
	}
}
