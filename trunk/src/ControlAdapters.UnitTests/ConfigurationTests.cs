using System;
using System.Configuration;
using NUnit.Framework;
using ControlAdapters.Configuration;

namespace ControlAdapters.UnitTests
{
	[TestFixture]
	public class ConfigurationTests
	{
		private ControlAdaptersConfigurationSection config;

		[Test]
		public void TestAppConfigSection()
		{
			config = ConfigurationManager.GetSection("ControlAdapters") as ControlAdaptersConfigurationSection;
			Assert.IsNotNull(config, "Unable to read ControlAdapters section from application configuration file");
			
			CheckBoxListSettings checkBoxSettings = config.CheckBoxList;
			Assert.IsNotNull(checkBoxSettings, "Unable to read CheckBoxList section");
			Assert.AreEqual(checkBoxSettings.CssClass, "checkBoxList", "CheckBoxList CssClass not set properly");
			Assert.AreEqual(checkBoxSettings.DisabledCssClass, "disabled", "CheckBoxList DisabledCssClass not set properly");
		}
	}
}
