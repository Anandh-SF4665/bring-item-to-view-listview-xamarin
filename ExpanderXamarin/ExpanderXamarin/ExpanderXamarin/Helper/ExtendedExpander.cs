using Syncfusion.ListView.XForms;
using Syncfusion.ListView.XForms.Control.Helpers;
using Syncfusion.XForms.Expander;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ExpanderXamarin
{
    public class ExtendedExpander: SfExpander
    {
        #region Fields
        public SfListView ListView { get; set; }
        #endregion

        #region Constructor
        public ExtendedExpander()
        {
            this.Expanded += ExtendedExpander_Expanded;
        }

        #endregion

        #region Call back

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
        #endregion

        #region Dispose

        protected override void Dispose(bool disposing)
        {
            this.ListView = null;
            this.Expanded -= ExtendedExpander_Expanded;
            base.Dispose(disposing);
        }

        #endregion
    }
}
