using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Com.Qmuiteam.Qmui.Arch;

namespace SampleApp
{
    [Activity(Label = "SecondActivity", Theme = "@style/MyQMTheme")]    
    public class SecondActivity : QMUIActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here

            SetContentView(Resource.Layout.layout1);
        }
    }
}