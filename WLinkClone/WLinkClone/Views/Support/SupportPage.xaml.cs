using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WLinkClone.ViewModels.Support;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WLinkClone.Views.Support
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SupportPage : ContentPage
    {
        public SupportPage()
        {
            InitializeComponent();
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            if(BindingContext is SupportPageViewModel supportPageViewModel)
            {
                supportPageViewModel?.Dispose();
            }
        }
    }
}