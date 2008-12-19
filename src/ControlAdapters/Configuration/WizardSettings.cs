using System;
using System.Configuration;
using ControlAdapters.Adapters;

namespace ControlAdapters.Configuration
{
	/// <summary>
	/// Represents the configuration settings for the <see cref="WizardAdapter"/>.
	/// </summary>
	public class WizardSettings : ConfigurationElement
	{
		private static readonly WizardSettings _defaultSettings = new WizardSettings();

		/// <summary>
		/// Initializes a new instance of <see cref="WizardSettings"/>.
		/// </summary>
		public WizardSettings()
		{
		}

		/// <summary>
		/// Gets an instance of <see cref="WizardSettings"/> providing default values.
		/// </summary>
		public static WizardSettings Default
		{
			get { return _defaultSettings; }
		}

		/// <summary>
		/// Gets or sets the CSS class used by the <see cref="WizardAdapter"/>.
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
