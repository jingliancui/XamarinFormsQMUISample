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
using Com.Qmuiteam.Qmui.Widget;
using SampleApp.Controls;
using SampleApp.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(VerticalTextView), typeof(VerticalTextViewRenderer))]
namespace SampleApp.Droid.Renderers
{
    public class VerticalTextViewRenderer : ViewRenderer<VerticalTextView, LinearLayout>
    {
        public VerticalTextViewRenderer(Context context) : base(context)
        {
            MessagingCenter.Subscribe<object,string>(this, MainPage.TextChanged, (sender,args) =>
            {
                qmuiTextView.Text = args;
            });
        }

        private QMUIVerticalTextView qmuiTextView;
        protected override void OnElementChanged(ElementChangedEventArgs<VerticalTextView> e)
        {
            var view = Inflate(Context, Resource.Layout.TextLayout, null) as LinearLayout;
            qmuiTextView = view.FindViewById<QMUIVerticalTextView>(Resource.Id.qmtext);
            qmuiTextView.Text = "你好哦！Xamarin!";
            SetNativeControl(view);
        }
    }
}