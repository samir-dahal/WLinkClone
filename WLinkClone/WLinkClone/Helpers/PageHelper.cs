using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
namespace WLinkClone.Helpers
{
    public static class PageHelper
    {
        public static async Task SetMainPageAsync(Page page)
        {
            //if(App.Current.MainPage.Navigation.NavigationStack.FirstOrDefault(p => p.GetType() == page.GetType()) is null)
            //{
            //    await App.Current.MainPage.Navigation.PushAsync(page, false);
            //}


            if (App.Current.MainPage.Navigation.NavigationStack.LastOrDefault(p => p.GetType() == page.GetType()) is not null) return;
            await App.Current.MainPage.Navigation.PushAsync(page, false);
            var firstPage = App.Current.MainPage.Navigation.NavigationStack.FirstOrDefault();
            if (firstPage is not null)
            {
                App.Current.MainPage.Navigation.RemovePage(firstPage);
            }
        }
    }
}
