using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Com.Qmuiteam.Qmui.Arch;

namespace SampleApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/MyQMTheme", MainLauncher = true)]
    public class MainActivity : QMUIActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            QMUISwipeBackActivityManager.Init(Application);

            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            var btn = FindViewById<Button>(Resource.Id.NaviBtn);
            btn.Click += Btn_Click;
        }

        private void Btn_Click(object sender, System.EventArgs e)
        {
            var intent = new Android.Content.Intent(this, typeof(SecondActivity));
            StartActivity(intent);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}