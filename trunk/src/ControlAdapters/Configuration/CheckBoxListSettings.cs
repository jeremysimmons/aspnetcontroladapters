using System;
using System.Configuration;
using ControlAdapters.Adapters;

namespace ControlAdapters.Configuration
{
	/// <summary>
	/// Represents the configuration settings for the <see cref="CheckBoxListAdapter"/>.
	/// </summary>
	public class CheckBoxListSettings : ConfigurationElement
	{
		private static readonly CheckBoxListSettings _defaultSettings = new CheckBoxListSettings();

		/// <summary>
		/// Initializes a new instance of <see cref="CheckBoxListSettings"/>.
		/// </summary>
		public CheckBoxListSettings()
		{
		}

		/// <summary>
		/// Gets an instance of <see cref="CheckBoxListSettings"/> providing default values.
		/// </summary>
		public static CheckBoxListSettings Default
		{
			get { return _defaultSettings; }
		}

		/// <summary>
		/// Gets or sets the CSS class used by the <see cref="CheckBoxListAdapter"/>.
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
