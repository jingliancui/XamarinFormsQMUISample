using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xamarin.Forms;
using Com.Qmuiteam.Qmui.Widget.Dialog;

namespace SampleApp.Droid
{
    [Activity(
        Label = "SampleApp", 
        Icon = "@mipmap/icon", 
        //Theme = "@style/MainTheme",
        Theme = "@style/MyQMTheme",
        MainLauncher = true,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        private QMUIDialog.EditTextDialogBuilder dialogBuilder;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());

            dialogBuilder = new QMUIDialog.EditTextDialogBuilder(this)
            .SetPlaceholder("Type something here")
            .SetInputType((int)Android.Text.InputTypes.ClassText)
            .SetTitle("Hello!") as QMUIDialog.EditTextDialogBuilder;
            dialogBuilder.AddAction("Cancel", new CancelActionListener());
            dialogBuilder.AddAction("OK", new OKActionListener(dialogBuilder));

            MessagingCenter.Subscribe<object>(this, MainPage.OpenDialog, obj => 
            {
                dialogBuilder.Show();
            });
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }

    public class OKActionListener : Java.Lang.Object, QMUIDialogAction.IActionListener
    {
        private QMUIDialog.EditTextDialogBuilder builder;
        public OKActionListener(QMUIDialog.EditTextDialogBuilder dialogBuilder)
        {
            builder = dialogBuilder;
        }
        public void OnClick(QMUIDialog dialog, int p1)
        {
            var text = builder.EditText?.Text;
            dialog.Dismiss();
            MessagingCenter.Send(new object(), MainPage.TextChanged, text);
        }
    }

    public class CancelActionListener : Java.Lang.Object, QMUIDialogAction.IActionListener
    {
        public void OnClick(QMUIDialog dialog, int p1)
        {
            dialog.Dismiss();
        }
    }
}