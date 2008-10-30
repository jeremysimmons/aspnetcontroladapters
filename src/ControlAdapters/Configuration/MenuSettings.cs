using System;
using System.Configuration;
using ControlAdapters.Adapters;

namespace ControlAdapters.Configuration
{
	/// <summary>
	/// Represents the configuration settings for the <see cref="MenuAdapter"/>.
	/// </summary>
	public class MenuSettings : ConfigurationElement
	{
		private static readonly MenuSettings _defaultSettings = new MenuSettings();

		/// <summary>
		/// Initializes a new instance of <see cref="MenuSettings"/>.
		/// </summary>
		public MenuSettings()
		{
		}

		/// <summary>
		/// Gets an instance of <see cref="MenuSettings"/> providing default values.
		/// </summary>
		public static MenuSettings Default
		{
			get { return _defaultSettings; }
		}

		/// <summary>
		/// Gets or sets the CSS class used by the <see cref="MenuAdapter"/>.
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
