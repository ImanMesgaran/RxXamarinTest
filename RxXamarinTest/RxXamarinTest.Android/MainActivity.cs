using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Prism;
using Prism.Ioc;
using Xamarin.Forms;

namespace RxXamarinTest.Droid
{
    [Activity(Label = "RxXamarinTest", Icon = "@mipmap/ic_launcher", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            Rg.Plugins.Popup.Popup.Init(this, bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App(new AndroidInitializer()));
        }

        //public override void OnBackPressed()
        //{
        //    if (Rg.Plugins.Popup.Popup.SendBackPressed(base.OnBackPressed))
        //    {
        //        // Do something if there are some pages in the `PopupStack`
        //    }
        //    else
        //    {
        //        // Do something if there are not any pages in the `PopupStack`
        //    }
        //}

        public override void OnBackPressed()
        {
            RunOnUiThread(
                async () =>
                {
                    var isCloseApp = await AlertAsync(this, "NameOfApp", "Do you want to close this app?", "Yes", "No");

                    if (isCloseApp)
                    {
                        var activity = (Activity)Forms.Context;
                        activity.FinishAffinity();
                    }
                });
        }

        public Task<bool> AlertAsync(Context context, string title, string message, string positiveButton, string negativeButton)
        {
            var tcs = new TaskCompletionSource<bool>();

            using (var db = new AlertDialog.Builder(context))
            {
                db.SetTitle(title);
                db.SetMessage(message);
                db.SetPositiveButton(positiveButton, (sender, args) => { tcs.TrySetResult(true); });
                db.SetNegativeButton(negativeButton, (sender, args) => { tcs.TrySetResult(false); });
                db.Show();
            }

            return tcs.Task;
        }
    }

    public class AndroidInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry container)
        {
            // Register any platform specific implementations
        }
    }
}

