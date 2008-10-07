<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CheckBoxList.aspx.cs" Inherits="ControlAdapters.WebTests.CheckBoxList"
	MasterPageFile="~/Default.Master" %>

<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
	<h1>
		ControlAdapters CheckBoxList Adapter Tests</h1>
	<h2>
		Default ASP.Net Markup</h2>
	<pre>
&lt;table id=&quot;ctl00_ContentPlaceHolder1_CheckBoxList1&quot; border=&quot;0&quot;&gt;
	&lt;tr&gt;
		&lt;td&gt;
			&lt;input id=&quot;ctl00_ContentPlaceHolder1_CheckBoxList1_0&quot; type=&quot;checkbox&quot; name=&quot;ctl00$ContentPlaceHolder1$CheckBoxList1$0&quot; /&gt;
			&lt;label for=&quot;ctl00_ContentPlaceHolder1_CheckBoxList1_0&quot;&gt;Text 0&lt;/label&gt;
		&lt;/td&gt;
		&lt;td&gt;
			&lt;span disabled=&quot;disabled&quot;&gt;
				&lt;input id=&quot;ctl00_ContentPlaceHolder1_CheckBoxList1_1&quot; type=&quot;checkbox&quot; name=&quot;ctl00$ContentPlaceHolder1$CheckBoxList1$1&quot; disabled=&quot;disabled&quot; /&gt;
				&lt;label for=&quot;ctl00_ContentPlaceHolder1_CheckBoxList1_1&quot;&gt;Text 1&lt;/label&gt;
			&lt;/span&gt;
		&lt;/td&gt;
	&lt;/tr&gt;
&lt;/table&gt;
	</pre>
	<asp:CheckBoxList ID="CheckBoxList1" runat="server">
		<asp:ListItem Value="0" Text="Normal" />
		<asp:ListItem Value="1" Text="Disabled" Enabled="false" />
		<asp:ListItem Value="NoText" />
		<asp:ListItem />
	</asp:CheckBoxList>
	<h2>
		Adapted ASP.Net Markup</h2>
	<pre runat="server" id="adaptedMarkup">
	</pre>
	<ca:CheckBoxList ID="CheckBoxList2" runat="server">
		<asp:ListItem Value="0" Text="Normal" />
		<asp:ListItem Value="1" Text="Disabled" Enabled="false" />
		<asp:ListItem Value="NoText" />
		<asp:ListItem />
	</ca:CheckBoxList>
</asp:Content>
