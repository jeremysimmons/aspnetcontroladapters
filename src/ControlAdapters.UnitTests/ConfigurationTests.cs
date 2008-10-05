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
			Assert.AreEqual(checkBoxSettings.CssClass, "AspNet-CheckBoxList", "CheckBoxList CssClass not set properly");
			Assert.AreEqual(checkBoxSettings.DisabledCssClass, "AspNet-CheckBoxList-Disabled", "CheckBoxList DisabledCssClass not set properly");
			Assert.AreEqual(checkBoxSettings.ItemCssClass, "AspNet-CheckBoxList-Item", "CheckBoxList ItemCssClass not set properly");
			Assert.AreEqual(checkBoxSettings.RepeatDirectionCssClass, "AspNet-CheckBoxList-RepeatDirection-", "CheckBoxList RepeatDirectionCssClass not set properly");
		}
	}
}
