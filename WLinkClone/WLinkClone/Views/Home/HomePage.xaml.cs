using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WLinkClone.ViewModels.Home;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WLinkClone.Views.Home
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            if(BindingContext is HomePageViewModel homePageViewModel)
            {
                homePageViewModel?.Dispose();
            }
        }
    }
}