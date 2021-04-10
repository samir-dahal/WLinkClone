using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WLinkClone.ViewModels.Billing;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WLinkClone.Views.Billing
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BillingPage : ContentPage
    {
        public BillingPage()
        {
            InitializeComponent();
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            if(BindingContext is BillingPageViewModel billingPageViewModel)
            {
                billingPageViewModel?.Dispose();
            }
        }
    }
}