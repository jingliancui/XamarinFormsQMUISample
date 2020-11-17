using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SampleApp
{
    public partial class MainPage : ContentPage
    {
        public const string OpenDialog = "OpenDialog";
        public const string TextChanged = "TextChanged";
        public MainPage()
        {
            InitializeComponent();
        }

        private void DialogBtn_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(new object(), OpenDialog);
        }
    }
}
