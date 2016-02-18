# Introduction #

Adapted content for the `RadioButtonList` control is available through the `RadioButtonListAdapter` or the `ControlAdapters.WebControls.RadioButtonList` control.


# HTML Rendering #

The `RadioButtonList` has two rendering modes.

  1. Block mode, using `RepeatLayout.Table`, renders the `RadioButtonList` in an unordered list (`ul`), with each radio button/label included in a list item (`li`)
  1. Flow mode, using `RepeatLayout.Flow`, renders the `RadioButtonList` inside a `span`, with minimal additional formatting.


## Sample Markup ##

ASP.Net Code:
```
<asp:RadioButtonList ID="RadioButtonList1" runat="server" repeatLayout="Table">
	<asp:ListItem Value="0">Normal</asp:ListItem>
	<asp:ListItem Value="1" Text="Disabled" Enabled="false" />
	<asp:ListItem Value="2" Text="Selected" Selected="True" />
	<asp:ListItem Value="NoText" />
	<asp:ListItem />
</asp:RadioButtonList>
```

Control Adapter markup (using default `RepeatLayout.Table`):
```
<ul id="RadioButtonList1" class="radioButtonList vertical">
	<li><input id="RadioButtonList1_0" name="RadioButtonList1" type="radio" value="0" tabindex="0" /><label for="RadioButtonList1_0">Normal</label></li>
	<li class="disabled"><input id="RadioButtonList1_1" name="RadioButtonList1" type="radio" value="1" disabled="disabled" tabindex="0" /><label for="RadioButtonList1_1">Disabled</label></li>
	<li><input id="RadioButtonList1_2" name="RadioButtonList1" type="radio" value="2" checked="checked" tabindex="0" /><label for="RadioButtonList1_2">Selected</label></li>
	<li><input id="RadioButtonList1_3" name="RadioButtonList1" type="radio" value="NoText" tabindex="0" /><label for="RadioButtonList1_3">NoText</label></li>
	<li><input id="RadioButtonList1_4" name="RadioButtonList1" type="radio" tabindex="0" /></li>
</ul>
```

Control Adapter markup (using default `RepeatLayout.Flow`):
```
<span id="RadioButtonList1" class="radioButtonList vertical">
	<input id="RadioButtonList1_0" name="RadioButtonList1" type="radio" value="0" tabindex="0" /><label for="RadioButtonList1_0">Normal</label>
	<span class="disabled"><input id="RadioButtonList1_1" name="RadioButtonList1" type="radio" value="1" disabled="disabled" tabindex="0" /><label for="RadioButtonList1_1">Disabled</label>
	<input id="RadioButtonList1_2" name="RadioButtonList1" type="radio" value="2" checked="checked" tabindex="0" /><label for="RadioButtonList1_2">Selected</label>
	<input id="RadioButtonList1_3" name="RadioButtonList1" type="radio" value="NoText" tabindex="0" /><label for="RadioButtonList1_3">NoText</label>
	<input id="RadioButtonList1_4" name="RadioButtonList1" type="checkbox" tabindex="0" />
</span>
```


# Configuration #

Configuration options include the following:

| `CssClass` | The class applied to the `ul` element. |
|:-----------|:---------------------------------------|
| `DisabledCssClass` | If the control, or a list item in the control, is disabled, this class is applied to the `li` element. |

A sample configuration follows.

```
<RadioButtonList cssClass="radioButtonList" 
	  disabledCssClass="disabled" />
```


# Implementation Notes #

## Recommended Default CSS ##

The following is a minimum recommended default CSS, using the sample configuration shown above.

```
ul.radioButtonList {
	list-style:none;
	margin: 0;
	padding: 0;
}
ul.radioButtonList.horizontal li {
	display: inline;
}
ul.radioButtonList li.disabled {
	color: Gray;
}
```


## RadioButtonList Properties Supported ##

The following table outlines those properties of the `RadioButtonList` control that are implemented in the `RadioButtonListAdapter` control. Properties not listed are not supported or implemented.

| **Property** | **Support** | **Notes** |
|:-------------|:------------|:----------|
| `AccessKey`  | Full        | When specified, the `accesskey` attribute with this value is applied to each radio button. |
| `Attributes` | Full        | Each attribute's name/value pair is added to the unordered list. |
| `AutoPostBack` | Full        | When set to `true`, each radio button control is configured to initiate a postback event. |
| `BackColor`  | Full        | When set other than `Color.Empty`, it is added to the `style` attribute of the outer `ul` or `span`. |
| `BorderColor` | Full        | When set other than `Color.Empty`, it is added to the `style` attribute of the outer `ul` or `span`. |
| `BorderStyle` | Full        | When set other than `BorderStyle.NotSet`, it is added to the `style` attribute of the outer `ul` or `span`. |
| `BorderWidth` | Full        | When set other than `Unit.Empty`, it is added to the `style` attribute of the outer `ul` or `span`. |
| `ClientID`   | Full        | Used as the surrounding tag's `id` attribute. |
| `CssClass`   | Full        | When not null or empty, it is added to the unordered list's `class` list. |
| `Enabled`    | Full        | When set to `false` and the default `DisabledCssClass` is specified, this class is added to the unordered list's and each list item's `class` list. |
| `ForeColor`  | Full        | When set other than `Color.Empty`, it is added to the `style` style of the outer `ul` or `span`. |
| `Height`     | Full        | When set other than `Unit.Empty`, it is added to the `style` attribute of the outer `ul` or `span`. |
| `Items`      | Full        | All items in the control are rendered. Items which are disabled have the default `DisabledCssClass` applied to the appropriate list item element. |
| `RepeatDirection` | Full        | A lower-case string representation of `RepeatDirection` (i.e. `horizontal` or `vertical` is added as a CSS class in the unordered list's `class` list. In block layout mode (`RepeatLayout.Table`), this adds the CSS class `horizontal` or `vertical` to the outer `ul` tag. In flow layout mode (`RepeatLayout.Flow`), if set to `Vertical`, a line break (`br` tag) is added after each radio button/label combination. |
| `TextAlign`  | Full        | Specifies placement of the HTML `label` tag before or after the `input` radio button. |
| `Width`      | Full        | When set other than `Unit.Empty`, it is added to the `style` attribute of the outer `ul` or `span`. |


## ListItem Properties Supported ##

The following table outlines those properties of the `RadioButtonList` control's `Items` collection that are implemented in the `RadioButtonListAdapter` control. Properties not listed are not supported or implemented.

| **Property** | **Implementation** |
|:-------------|:-------------------|
| `Enabled`    | When disabled, the default `DisabledCssClass` is applied to the list item. |
| `Selected`   | When selected, the attribute `checked` is added to the radio button with the value `checked` (this makes the radio button checked). |
| `Text`       | Used as the text of the `label` tag. If this is not used, the `Value` property is used. If neither are used, the label is not rendered. |
| `Value`      | Used as the radio button's `value` attribute. Note that this is not added in standard ASP.Net markup. |