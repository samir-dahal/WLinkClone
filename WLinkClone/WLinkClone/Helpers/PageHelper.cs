using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
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
        public static Page CurrentPage => App.Current.MainPage;
        public static INavigation Navigation => CurrentPage.Navigation;
        public static IReadOnlyList<Page> NavigationStack => Navigation.NavigationStack;
        public static IReadOnlyList<PopupPage> PopupNavigationStack => PopupNavigation.Instance.PopupStack;
        public static async Task SetMainPageAsync(Page page)
        {

            if (NavigationStack.LastOrDefault(p => p.GetType() == page.GetType()) is not null) return;
            await Navigation.PushAsync(page, false);
            var firstPage = NavigationStack.FirstOrDefault();
            if (firstPage is not null)
            {
                Navigation.RemovePage(firstPage);
            }
        }
        public static async Task PushRgPageAsync(PopupPage page)
        {
            if(PopupNavigationStack.FirstOrDefault(p => p.GetType() == page.GetType()) is null)
            {
                await PopupNavigation.Instance.PushAsync(page);
            }
        }
        public static async Task PopRgPageAsync()
        {
            if(PopupNavigationStack.Any())
            {
                await PopupNavigation.Instance.PopAsync();
            }
        }
        public static async Task PopAllRgPagesAsync()
        {
            if (PopupNavigationStack.Any())
            {
                await PopupNavigation.Instance.PopAllAsync();
            }
        }
    }
}
