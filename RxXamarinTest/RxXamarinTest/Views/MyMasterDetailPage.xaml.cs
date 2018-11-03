using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Prism.Services;
using RxXamarinTest.ViewModels;
using Xamarin.Forms;

namespace RxXamarinTest.Views
{
    public partial class MyMasterDetailPage : MasterDetailPage/*, IPageDialogService*/
    {
        private IPageDialogService _pageDialogService;

        public long doublePressInterval_ms = 300;

        public DateTime _lastPressTime { get; set; }
        //public DateTime LastPressTime
        //{
        //    get { return _lastPressTime; }
        //    set { SetProperty(ref _lastPressTime, value); }
        //}

        public MyMasterDetailPage(IPageDialogService pageDialogService)
        {
            InitializeComponent();

            _pageDialogService = pageDialogService;
        }

        //        protected override bool OnBackButtonPressed() {
        //            DateTime pressTime = DateTime.Now;
        ////            if ((pressTime - _lastPressTime).TotalMilliseconds <= doublePressInterval_ms)
        //            if ((pressTime - _lastPressTime).TotalSeconds <= 2)
        //            {
        //                Debug.WriteLine("close the app By Double back Button");

        //                _lastPressTime = pressTime;

        //                return false;
        //            } else
        //            {
        //                //var dialogResult = _pageDialogService.DisplayAlertAsync("app" , "Do you want to Exit the App" , "Exit" , "Cancel");
        //                Debug.WriteLine("close the app By One back Button");

        //                _lastPressTime = pressTime;

        //                var x = (MyMasterDetailPageViewModel) this.BindingContext;
        //                x.ShowDialog();

        //                return false;
        //                //return !dialogResult.Result;
        //            }
        //        }

        //protected override bool OnBackButtonPressed() {
        //    ShowMessage("Dialog Title", "Prompt", "Ok", async () =>
        //    {
        //        await ShowMessage("OK was pressed", "Message", "OK", null);
        //    });

        //    return true;
        //}

        //protected async override bool OnBackButtonPressed() {
        //    //ShowPopup();

        //    var x = (MyMasterDetailPageViewModel)this.BindingContext;

        //    var y=Task.Run(async () => { return await x.ShowDialog();});

        //    var z = y.Result;
        //    Debug.WriteLine($"*********************************** {z} ***********************************");

        //    return z;
        //}

        public async Task<bool> ShowPopup()
        {
            bool result = await NewMethod();

            return result;
        }

        private async Task<bool> NewMethod()
        {
            return await DisplayAlert("title", "wanna Exit>?", "ok", "cancel");
        }

        private async void Button_OnClicked(object sender, EventArgs e)
        {
            await ShowMessage("Dialog Title", "Prompt", "Ok", async () =>
            {
                await ShowMessage("OK was pressed", "Message", "OK", null);
            });
        }

        public async Task ShowMessage(string message,
            string title,
            string buttonText,
            Action afterHideCallback)
        {
            await DisplayAlert(
                title,
                message,
                buttonText);

            afterHideCallback?.Invoke();
        }

        #region Back Button

        protected override bool OnBackButtonPressed()
        {
            DateTime pressTime = DateTime.Now;
            //if ((pressTime - _lastPressTime).TotalMilliseconds <= doublePressInterval_ms)

            Task.Run(async () => await DisplayAlert("title","wanna close?" , "ok"));
            if ((pressTime - _lastPressTime).TotalSeconds <= 2)
            {
                Debug.WriteLine("close the app By Double back Button");
                
                return false;
            }

            _lastPressTime = pressTime;

            return true;
        }

        #endregion
    }
}