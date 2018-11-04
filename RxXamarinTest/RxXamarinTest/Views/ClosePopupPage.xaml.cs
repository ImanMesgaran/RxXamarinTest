using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;

namespace RxXamarinTest.Views
{
    public partial class ClosePopupPage : PopupPage
    {
        public ClosePopupPage()
        {
            InitializeComponent();
        }

        // Invoked when background is clicked
        protected override bool OnBackgroundClicked()
        {
            // Return false if you don't want to close this popup page when a background of the popup page is clicked
            //
            //return base.OnBackgroundClicked();
            MyMasterDetailPage.callBackButton();
            return true;
        }
    }
}
