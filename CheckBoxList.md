# Introduction #

Adapted content for the `CheckBoxList` control is available through the `CheckBoxListAdapter` or the `CssCheckBoxList` control.


# HTML Rendering #

The `CheckBoxList` has two rendering modes.

  1. Block mode, using `RepeatLayout.Table`, renders the `CheckBoxList` in an unordered list (`ul`), with each checkbox/label included in a list item (`li`)
  1. Flow mode, using `RepeatLayout.Flow`, renders the `CheckBoxList` inside a `span`, with minimal additional formatting.


## Sample Markup ##

ASP.Net Code:
```
<asp:CheckBoxList ID="CheckBoxList1" runat="server" repeatLayout="Table">
	<asp:ListItem Value="0">Normal</asp:ListItem>
	<asp:ListItem Value="1" Text="Disabled" Enabled="false" />
	<asp:ListItem Value="2" Text="Selected" Selected="True" />
	<asp:ListItem Value="NoText" />
	<asp:ListItem />
</asp:CheckBoxList>
```

Control Adapter markup (using default `RepeatLayout.Table`):
```
<ul id="CheckBoxList1" class="checkBoxList vertical">
	<li><input id="CheckBoxList1_0" name="CheckBoxList1$0" type="checkbox" value="0" tabindex="0" /><label for="CheckBoxList1_0">Normal</label></li>
	<li class="disabled"><input id="CheckBoxList1_1" name="CheckBoxList1$1" type="checkbox" value="1" disabled="disabled" tabindex="0" /><label for="CheckBoxList1_1">Disabled</label></li>
	<li><input id="CheckBoxList1_2" name="CheckBoxList1$2" type="checkbox" value="2" checked="checked" tabindex="0" /><label for="CheckBoxList1_2">Selected</label></li>

	<li><input id="CheckBoxList1_3" name="CheckBoxList1$3" type="checkbox" value="NoText" tabindex="0" /><label for="CheckBoxList1_3">NoText</label></li>
	<li><input id="CheckBoxList1_4" name="CheckBoxList1$4" type="checkbox" tabindex="0" /></li>
</ul>
```

Control Adapter markup (using default `RepeatLayout.Flow`):
```
<span id="CheckBoxList1" class="checkBoxList vertical">
	<input id="CheckBoxList1_0" name="CheckBoxList1$0" type="checkbox" value="0" tabindex="0" /><label for="CheckBoxList1_0">Normal</label>
	<span class="disabled"><input id="CheckBoxList1_1" name="CheckBoxList1$1" type="checkbox" value="1" disabled="disabled" tabindex="0" /><label for="CheckBoxList1_1">Disabled</label>
	<input id="CheckBoxList1_2" name="CheckBoxList1$2" type="checkbox" value="2" checked="checked" tabindex="0" /><label for="CheckBoxList1_2">Selected</label>

	<input id="CheckBoxList1_3" name="CheckBoxList1$3" type="checkbox" value="NoText" tabindex="0" /><label for="CheckBoxList1_3">NoText</label>
	<input id="CheckBoxList1_4" name="CheckBoxList1$4" type="checkbox" tabindex="0" />
</span>
```


# Configuration #

Configuration options include the following:

| `CssClass` | The class applied to the `ul` element. |
|:-----------|:---------------------------------------|
| `DisabledCssClass` | If the control, or a list item in the control, is disabled, this class is applied to the `li` element. |

A sample configuration follows.

```
<CheckBoxList cssClass="checkBoxList" 
	  disabledCssClass="disabled" />
```


# Implementation Notes #

## Recommended Default CSS ##

The following is a minimum recommended default CSS, using the sample configuration shown above.

```
ul.checkBoxList {
	list-style:none;
	margin: 0;
	padding: 0;
}
ul.checkBoxList.horizontal li {
	display: inline;
}
ul.checkBoxList li.disabled {
	color: Gray;
}
```


## CheckBoxList Properties Supported ##

The following table outlines those properties of the `CheckBoxList` control that are implemented in the `CheckBoxListAdapter` control. Properties not listed are not supported or implemented.

| **Property** | **Support** | **Notes** |
|:-------------|:------------|:----------|
| `AccessKey`  | Full        | When specified, the `accesskey` attribute with this value is applied to each checkbox. |
| `Attributes` | Full        | Each attribute's name/value pair is added to the unordered list. |
| `AutoPostBack` | Full        | When set to `true`, each checkbox control is configured to initiate a postback event. |
| `BackColor`  | Full        | When set other than `Color.Empty`, it is added to the `style` attribute of the outer `ul` or `span`. |
| `BorderColor` | Full        | When set other than `Color.Empty`, it is added to the `style` attribute of the outer `ul` or `span`. |
| `BorderStyle` | Full        | When set other than `BorderStyle.NotSet`, it is added to the `style` attribute of the outer `ul` or `span`. |
| `BorderWidth` | Full        | When set other than `Unit.Empty`, it is added to the `style` attribute of the outer `ul` or `span`. |
| `ClientID`   | Full        | Used as the unordered list's `id` attribute. |
| `CssClass`   | Full        | When not null or empty, it is added to the unordered list's `class` list. |
| `Enabled`    | Full        | When set to `false` and the default `DisabledCssClass` is specified, this class is added to the unordered list's and each list item's `class` list. |
| `ForeColor`  | Full        | When set other than `Color.Empty`, it is added to the `style` style of the outer `ul` or `span`. |
| `Height`     | Full        | When set other than `Unit.Empty`, it is added to the `style` attribute of the outer `ul` or `span`. |
| `Items`      | Full        | All items in the control are rendered. Items which are disabled have the default `DisabledCssClass` applied to the appropriate list item element. |
| `RepeatDirection` | Full        | A lower-case string representation of `RepeatDirection` (i.e. `horizontal` or `vertical` is added as a CSS class in the unordered list's `class` list. In block layout mode (`RepeatLayout.Table`), this adds the CSS class `horizontal` or `vertical` to the outer `ul` tag. In flow layout mode (`RepeatLayout.Flow`), if set to `Vertical`, a line break (`br` tag) is added after each checkbox/label combination. |
| `TextAlign`  | Full        | Specifies placement of the HTML `label` tag before or after the `input` checkbox. |
| `Width`      | Full        | When set other than `Unit.Empty`, it is added to the `style` attribute of the outer `ul` or `span`. |


## ListItem Properties Supported ##

The following table outlines those properties of the `CheckBoxList` control's `Items` collection that are implemented in the `CheckBoxListAdapter` control. Properties not listed are not supported or implemented.

| **Property** | **Implementation** |
|:-------------|:-------------------|
| `Enabled`    | When disabled, the default `DisabledCssClass` is applied to the list item. |
| `Selected`   | When selected, the attribute `checked` is added to the checkbox with the value `checked` (this makes the checkbox . |
| `Text`       | Used as the text of the `label` tag. If this is not used, the `Value` property is used. If neither are used, the label is not rendered. |
| `Value`      | Used as the checkbox's `value` attribute. Note that this is not added in standard ASP.Net markup. |