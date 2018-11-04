using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Reactive.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Prism.Services;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using RxXamarinTest.ViewModels;
using Xamarin.Forms;

namespace RxXamarinTest.Views
{
    public partial class MyMasterDetailPage : MasterDetailPage/*, IPageDialogService*/ , INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }



        private IPageDialogService _pageDialogService;

        public long doublePressInterval_ms = 300;

        public DateTime _lastPressTime { get; set; }
        //public DateTime LastPressTime
        //{
        //    get { return _lastPressTime; }
        //    set { SetProperty(ref _lastPressTime, value); }
        //}

        public MyMasterDetailPage(/*IPageDialogService pageDialogService*/)
        {
            InitializeComponent();

            //_pageDialogService = pageDialogService;
        }

        public static void callBackButton() {
            MyMasterDetailPage master=new MyMasterDetailPage();
            master.callBack();
        }

        public void callBack() {
            OnBackButtonPressed();
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

        //protected override bool OnBackButtonPressed()
        //{
        //    DateTime pressTime = DateTime.Now;
        //    //if ((pressTime - _lastPressTime).TotalMilliseconds <= doublePressInterval_ms)

        //    Task.Run(async () => await DisplayAlert("title","wanna close?" , "ok"));
        //    if ((pressTime - _lastPressTime).TotalSeconds <= 2)
        //    {
        //        Debug.WriteLine("close the app By Double back Button");

        //        return false;
        //    }

        //    _lastPressTime = pressTime;

        //    return true;
        //}

        //protected override bool OnBackButtonPressed() {
        //    // Open a PopupPage
        //    Navigation.PushPopupAsync(new ClosePopupPage());

        //    return true;
        //    //return base.OnBackButtonPressed();
        //}


        #region test 1
        /*
        public long doublePressInterval_s = 2;
        public DateTime _lastClickTime { get; set; }

        protected override bool OnBackButtonPressed() {
            DateTime now = DateTime.Now;
            var minus = now.Subtract(_lastClickTime).TotalSeconds;
            if (minus < doublePressInterval_s) { return false; }

            _lastClickTime = DateTime.Now;
            DisplayAlert("do you want TITLE" , "do you want to close?" , "cancel");
            return true;
        }
        */
        #endregion test1

        #region test2
        /*
        private bool _isClicked;
        public bool IsClicked
        {
            get { return _isClicked; }
            set
            {
                if (_isClicked != value)
                {
                    _isClicked = value;
                    NotifyPropertyChanged();
                }
            }
        }

        protected override bool OnBackButtonPressed()
        {
            var result = Observable
                .FromEventPattern<PropertyChangedEventArgs>(this, nameof(PropertyChanged))
                .Where(x => x.EventArgs.PropertyName == nameof(SearchBoxText))
                // slow it down
                .Throttle(TimeSpan.FromMilliseconds(700));

            return base.OnBackButtonPressed();
        }
        */
        #endregion test2

        #region test3

        protected override bool OnBackButtonPressed() {
            bool dialogResult = true;
            Device.BeginInvokeOnMainThread(async () =>
            {
                var result = await DisplayAlert("Alert!", "Do you really want to exit the application?", "Yes", "No");
                if (result)
                {
                    //if (Device.OS == TargetPlatform.Android)
                    //{
                    //    Android.OS.Process.KillProcess(Android.OS.Process.MyPid());
                    //}
                    dialogResult = false;/* return true;*/
                }
            });

            return dialogResult;
        }

        #endregion

        #endregion
    }
}