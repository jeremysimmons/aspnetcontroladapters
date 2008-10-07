using System;
using System.Configuration;

namespace ControlAdapters.Configuration
{
	public class CheckBoxListSettings : ConfigurationElement
	{
		private static readonly CheckBoxListSettings _defaultSettings = new CheckBoxListSettings();

		/// <summary>
		/// Initializes a new instance of <see cref="CheckBoxListSettings"/>.
		/// </summary>
		public CheckBoxListSettings()
		{
		}

		public static CheckBoxListSettings Default
		{
			get { return _defaultSettings; }
		}

		/// <summary>
		/// Gets or sets the CSS class.
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
		/// Gets or sets the CSS class when the control is disabled.
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

		/// <summary>
		/// Gets or sets the CSS class for the control's items.
		/// </summary>
		[ConfigurationProperty("itemCssClass", IsRequired = false)]
		public string ItemCssClass
		{
			get
			{
				if (base["itemCssClass"] == null)
					return String.Empty;
				else
					return (string)base["itemCssClass"];
			}
			set { base["itemCssClass"] = value; }
		}

		/// <summary>
		/// Gets or sets the CSS class for the control's repeat direction.
		/// </summary>
		[ConfigurationProperty("repeatDirectionCssClass", IsRequired = false)]
		public string RepeatDirectionCssClass
		{
			get
			{
				if (base["repeatDirectionCssClass"] == null)
					return String.Empty;
				else
					return (string)base["repeatDirectionCssClass"];
			}
			set { base["repeatDirectionCssClass"] = value; }
		}
	}
}
