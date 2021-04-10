using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WLinkClone.Helpers;
using WLinkClone.Models;
using WLinkClone.Views.Billing.Popups;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace WLinkClone.ViewModels.Billing
{
    public class BillingPageViewModel : BasePageViewModel
    {
        public static Random Random = new Random();
        public IAsyncCommand MoreTappedCommand { get; }
        public ObservableRangeCollection<Transaction> Transactions { get; set; } = new ObservableRangeCollection<Transaction>();
        public BillingPageViewModel()
        {
            MoreTappedCommand = new AsyncCommand(HandleMoreTappedAsync, allowsMultipleExecutions: false);
            var items = new List<Transaction>();
            for(int i=0; i<10; i++)
            {
                items.Add(new Transaction
                {
                    PaidAmount = Random.Next(1000, 3000),
                    Number = Random.Next(100000, 999999).ToString(),
                });
            }
            Transactions.AddRange(items);
        }
        private async Task HandleMoreTappedAsync()
        {
            await PageHelper.PushRgPageAsync(new AccountSupport());
        }
    }
}
