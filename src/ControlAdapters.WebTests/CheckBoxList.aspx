<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CheckBoxList.aspx.cs" Inherits="ControlAdapters.WebTests.CheckBoxList" MasterPageFile="~/Default.Master" %>

<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
	<h1>ControlAdapters CheckBoxList Adapter Tests</h1>
	
	<h2>Default ASP.Net Markup</h2>
	
	<pre>
&lt;table id=&quot;Table1&quot; border=&quot;0&quot;&gt;
	&lt;tr&gt;
		&lt;td&gt;&lt;input id=&quot;CheckBoxList1_0&quot; type=&quot;checkbox&quot; name=&quot;CheckBoxList1$0&quot; /&gt;&lt;label for=&quot;CheckBoxList1_0&quot;&gt;Text 0&lt;/label&gt;&lt;/td&gt;
		&lt;td&gt;&lt;input id=&quot;CheckBoxList1_1&quot; type=&quot;checkbox&quot; name=&quot;CheckBoxList1$1&quot; /&gt;&lt;label for=&quot;CheckBoxList1_1&quot;&gt;Text 1&lt;/label&gt;&lt;/td&gt;
	&lt;/tr&gt;
&lt;/table&gt;
	</pre>
	
	<asp:CheckBoxList ID="CheckBoxList1" runat="server" RepeatDirection="Horizontal">
		<asp:ListItem Value="0" Text="Text 0" />
		<asp:ListItem Value="1" Text="Text 1" />
	</asp:CheckBoxList>
</asp:Content>
