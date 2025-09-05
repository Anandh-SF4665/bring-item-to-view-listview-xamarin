**[View document in Syncfusion Xamarin Knowledge base](https://www.syncfusion.com/kb/12159/how-to-bring-the-entire-item-to-view-when-the-expander-sfexpander-is-expanding-in-xamarin)**

## Sample

```xaml
<sflistview:SfListView x:Name="listView" AutoFitMode="DynamicHeight" ItemsSource="{Binding ContactsInfo}">
    <sflistview:SfListView.ItemTemplate>
        <DataTemplate>
            <local:ExtendedExpander x:Name="expander" ListView="{x:Reference listView}" HeaderIconPosition="None" IsExpanded="{Binding IsExpanded, Mode=TwoWay}">
                <local:ExtendedExpander.Header>
                    <code>
                    . . .
                    . . .
                    <code>
                </local:ExtendedExpander.Header>
                <local:ExtendedExpander.Content>
                    <code>
                    . . .
                    . . .
                    <code>
                </local:ExtendedExpander.Content>
            </local:ExtendedExpander>
        </DataTemplate>
    </sflistview:SfListView.ItemTemplate>
</sflistview:SfListView>

C#:

public class ExtendedExpander: SfExpander
{
    public SfListView ListView { get; set; }

    public ExtendedExpander()
    {
        this.Expanded += ExtendedExpander_Expanded;
    }

    private void ExtendedExpander_Expanded(object sender, ExpandedAndCollapsedEventArgs e)
    {
        var item = (sender as SfExpander).BindingContext as Contact;
        var itemIndex = ListView.DataSource.DisplayItems.IndexOf(item);

        Device.BeginInvokeOnMainThread(async () =>
        {
            await Task.Delay(200);
            ListView.LayoutManager.ScrollToRowIndex(itemIndex, Syncfusion.ListView.XForms.ScrollToPosition.MakeVisible, false);
        });
    }

    protected override void Dispose(bool disposing)
    {
        this.ListView = null;
        this.Expanded -= ExtendedExpander_Expanded;
        base.Dispose(disposing);
    }
}
```