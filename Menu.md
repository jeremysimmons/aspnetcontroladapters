# Introduction #

Adapted content for the `Menu` control is available through the `MenuAdapter` control.

**LIMITED IMPLEMENTATION** Many rendering features, particularly those related to dynamic menus, are not yet supported.


# HTML Rendering #

The adapted `Menu` is rendered as a series of nested unordered lists (`ul`). Each menu item is an anchor (`a`) in a list item (`li`).


## Sample Markup ##

ASP.Net Code:
```
<asp:Menu ID="adaptedMenu" runat="server" StaticDisplayLevels="2"
	MaximumDynamicDisplayLevels="2">
	<Items>
		<asp:MenuItem Text="File" Value="1" ToolTip="Perform a file operation">
			<asp:MenuItem Text="New" Value="11" ToolTip="Open a new document" />
			<asp:MenuItem Text="Open" Value="12" />
		</asp:MenuItem>
		<asp:MenuItem Text="Edit" Value="2">
			<asp:MenuItem Text="Copy" Value="21" />
			<asp:MenuItem Text="Paste" Value="22" />
			<asp:MenuItem Text="Clear" Value="23" Enabled="false" />
		</asp:MenuItem>
		<asp:MenuItem Text="View" Value="3" Enabled="false">
			<asp:MenuItem Text="Normal" Value="31" />
			<asp:MenuItem Text="Preview" Value="32" />
		</asp:MenuItem>
		<asp:MenuItem Text="Help" Value="4">
			<asp:MenuItem Text="How To" Value="41">
				<asp:MenuItem Text="Contents" Value="411" />
				<asp:MenuItem Text="Index" Value="412" />
				<asp:MenuItem Text="Search" Value="413" />
			</asp:MenuItem>
			<asp:MenuItem Text="About" Value="42" />
		</asp:MenuItem>
		<asp:MenuItem Value="NoText" />
		<asp:MenuItem />
	</Items>
</asp:Menu>
```

Adapted markup (formatted for easy reading0:
```
<ul id="adaptedMenu" class="menu vertical class">
	<li><a title="Perform a file operation" href="javascript:__doPostBack('adaptedMenu','1')">File</a>
		<ul>
			<li><a title="Open a new document" href="javascript:__doPostBack('adaptedMenu','11')">New</a></li>
			<li><a href="javascript:__doPostBack('adaptedMenu','12')">Open</a></li>
		</ul>
	</li>
	<li><a href="javascript:__doPostBack('adaptedMenu','2')">Edit</a>
		<ul>
			<li><a href="javascript:__doPostBack('adaptedMenu','21')">Copy</a></li>
			<li><a href="javascript:__doPostBack('adaptedMenu','22')">Paste</a></li>
			<li class="disabled"><a>Clear</a></li>
		</ul>
	</li>
	<li class="disabled"><a>View</a>
		<ul>
			<li><a href="javascript:__doPostBack('adaptedMenu','31')">Normal</a></li>
			<li><a href="javascript:__doPostBack('adaptedMenu','32')">Preview</a></li>
		</ul>
	</li>
	<li><a href="javascript:__doPostBack('adaptedMenu','4')">Help</a>
		<ul>
			<li><a href="javascript:__doPostBack('adaptedMenu','41')">How To</a>
				<ul class="dynamic">
					<li><a href="javascript:__doPostBack('adaptedMenu','411')">Contents</a></li>
					<li><a href="javascript:__doPostBack('adaptedMenu','412')">Index</a></li>
					<li><a href="javascript:__doPostBack('adaptedMenu','413')">Search</a></li>
				</ul>
			</li>
			<li><a href="javascript:__doPostBack('adaptedMenu','42')">About</a></li>
		</ul>
	</li>
	<li><a href="javascript:__doPostBack('adaptedMenu','NoText')">NoText</a></li>
	<li><a href="javascript:__doPostBack('adaptedMenu','')"></a></li>
</ul>
```


# Configuration #

Configuration options include the following:

| `CssClass` | The class applied to the outer `ul` element. |
|:-----------|:---------------------------------------------|
| `DisabledCssClass` | If the menu or menu item is nto enabled, this class is applied to the `li` element. |

A sample configuration follows.

```
<Menu cssClass="menu" 
	  disabledCssClass="disabled" />
```


# Implementation Notes #

## Recommended Default CSS ##

The following is a minimum recommended default CSS, using the sample configuration shown above. **Note:** Some CSS classes are hard coded right now.

```
ul.menu, ul.menu ul {
	list-style: none;
	margin: 0;
	padding: 0;
}
ul.dynamic {
	display: none;
}
ul.menu.horizontal ul {
	display: inline;
}
ul.menu.horizontal li {
	display: inline;
}
ul.menu ul {
	margin-left: 20px;
}
```


## Menu Properties Supported ##

The following table outlines those properties of the `Menu` control that are implemented in the `MenuAdapter` control. Properties not listed are not supported or implemented.

| **Property** | **Support** | **Notes** |
|:-------------|:------------|:----------|
| `Attributes` | Full        | Each attribute's name/value pair is added to the outer `ul`. |
| `BackColor`  | Full        | When set other than `Color.Empty`, it is added to the `style` attribute of the outer `ul`. |
| `BorderColor` | Full        | When set other than `Color.Empty`, it is added to the `style` attribute of the outer `ul`. |
| `BorderStyle` | Full        | When set other than `BorderStyle.NotSet`, it is added to the `style` attribute of the outer `ul`. |
| `BorderWidth` | Full        | When set other than `Unit.Empty`, it is added to the `style` attribute of the outer `ul`. |
| `ClientID`   | Full        | Used as the unordered list's `id` attribute. |
| `CssClass`   | Full        | When not null or empty, it is added to the outer `ul` `class` list. |
| `Enabled`    | Full        | When set to `false` and the default `DisabledCssClass` is specified, this class is added to the outer `ul` and each list item's `class` list. |
| `ForeColor`  | Full        | When set other than `Color.Empty`, it is added to the `style` style of the outer `ul`. |
| `Height`     | Full        | When set other than `Unit.Empty`, it is added to the `style` attribute of the outer `ul`. |
| `Items`      | Full        | Items in the control are rendered based on rendering rules. |
| `MaximumDynamicDisplayLevels` | Full        | Specifies how many nested `ul` menus are included for dynamic display. By default, dynamic menus are given the `dynamic` CSS class. |
| `StaticDisplayLevels` | Full        | Specifies how many nested `ul` menus are included in the markup. |
| `TabIndex`   | Full        | When set to a number greater than zero, its value is added as a `tabindex` attribute on the outer `ul`. |
| `Width`      | Full        | When set other than `Unit.Empty`, it is added to the `style` attribute of the outer `ul` or `span`. |


## MenuItem Properties Supported ##

The following table outlines those properties of the `Menu` control's `Items` collection that are implemented in the `MenuAdapter` control. Properties not listed are not supported or implemented.

| **Property** | **Implementation** |
|:-------------|:-------------------|
| `ChildItems` | All child items are parsed to the extent permitted by the `StaticDisplayLevels` and `MaximumDynamicDisplayLevels` properties. |
| `Enabled`    | When not enabled, the default `DisabledCssClass` is applied to the list item. |
| `Selectable` | If a menu item is not selectable, no `href` is applied to the anchor tag. (The menu item exists, but is not clickable.) |
| `Text`       | Used as the text of the menu item. If this is not used, the `Value` property is used. If neither are used, no text is used for the menu item (not recommended!). |
| `Tooltip`    | Tooltip text is applied as a `title` attribute to the menu item anchor tag. |
| `Value`      | Used as the menu's `value` attribute. Note that this is not added in standard ASP.Net markup. |