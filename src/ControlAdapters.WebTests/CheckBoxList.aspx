<%@ Page Language="C#" AutoEventWireup="false" %>
<%@ Import Namespace="ControlAdapters.Renderers" %>

<script runat="server">
	protected override void OnLoad(EventArgs e)
	{
		base.OnLoad(e);

		defaultCheckBoxList.Attributes["attrib1"] = "test1";
		adaptedCheckBoxList.Attributes["attrib1"] = "test1";

		RepeatDirection rDir = (repeatDirectionOption.SelectedValue == "horizontal"
			? RepeatDirection.Horizontal : RepeatDirection.Vertical);

		defaultCheckBoxList.RepeatDirection = rDir;
		adaptedCheckBoxList.RepeatDirection = rDir;

		CheckBoxListHtmlRenderer renderer = new CheckBoxListHtmlRenderer(adaptedCheckBoxList);
		adaptedMarkup.InnerHtml = Server.HtmlEncode(renderer.RenderBeginTag() + renderer.RenderContents() + renderer.RenderEndTag());
	}
</script>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
	<head runat="server">
		<title>Control Adapters: CheckBoxList</title>
	</head>
	<body>
		<form id="form1" runat="server">
			<div>
				<h1>ControlAdapters CheckBoxList Adapter Tests</h1>

				<h2>Markup Options</h2>

				<asp:DropDownList runat="server" ID="repeatDirectionOption" AutoPostBack="true">
					<asp:ListItem Value="vertical">Vertical</asp:ListItem>
					<asp:ListItem Value="horizontal">Horizontal</asp:ListItem>
				</asp:DropDownList>

				<hr />

				<h2>Default ASP.Net Markup</h2>

				<asp:CheckBoxList ID="defaultCheckBoxList" runat="server" AccessKey="A" CssClass="class" attrib2="test2" AutoPostBack="true">
					<asp:ListItem Value="0">Normal</asp:ListItem>
					<asp:ListItem Value="1" Text="Disabled" Enabled="false" />
					<asp:ListItem Value="2" Text="Selected" Selected="True" />
					<asp:ListItem Value="NoText" />
					<asp:ListItem />
				</asp:CheckBoxList>

				<hr />

				<h2>Adapted ASP.Net Markup</h2>

				<asp:Panel runat="server" ID="defaultPostbackResult"></asp:Panel>
				<ca:CheckBoxList ID="adaptedCheckBoxList" runat="server" AccessKey="B" CssClass="class" attrib2="test2" AutoPostBack="true">
					<asp:ListItem Value="0">Normal</asp:ListItem>
					<asp:ListItem Value="1" Text="Disabled" Enabled="false" />
					<asp:ListItem Value="2" Text="Selected" Selected="True" />
					<asp:ListItem Value="NoText" />
					<asp:ListItem />
				</ca:CheckBoxList>

				<pre runat="server" id="adaptedMarkup"></pre>
			</div>
		</form>
	</body>
</html>
