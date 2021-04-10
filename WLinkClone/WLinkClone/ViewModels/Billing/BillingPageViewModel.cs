using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using WLinkClone.Models;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace WLinkClone.ViewModels.Billing
{
    public class BillingPageViewModel : BasePageViewModel
    {
        public static Random Random = new Random();
        private bool _parentScrollViewEnabled = true;

        public bool ParentScrollViewEnabled
        {
            get { return _parentScrollViewEnabled; }
            set { _parentScrollViewEnabled = value; OnPropertyChanged(nameof(ParentScrollViewEnabled)); }
        }
        private bool _childScrollViewEnabled;

        public bool ChildScrollViewEnabled
        {
            get { return _childScrollViewEnabled; }
            set { _childScrollViewEnabled = value; OnPropertyChanged(nameof(ChildScrollViewEnabled)); }
        }
        public ICommand ParentScrollViewScrolledCommand { get; }
        public ObservableRangeCollection<Transaction> Transactions { get; set; } = new ObservableRangeCollection<Transaction>();
        public BillingPageViewModel()
        {
            ParentScrollViewScrolledCommand = new Command<ScrollView>((parentScrollView) => HandleParentScrollView(parentScrollView));
            var items = new List<Transaction>();
            for(int i=0; i<10; i++)
            {
                items.Add(new Transaction
                {
                    Title = "Online Payment",
                    PaidAmount = Random.Next(1000, 3000),
                    Number = Random.Next(100000, 999999).ToString(),
                    Date = RandomDate(2020),
                });
            }
            Transactions.AddRange(items);
        }
        private string RandomDate(int startYear = 1960, string outputDateFormat = "yyyy-MM-dd")
        {
            DateTime start = new DateTime(startYear, 1, 1);
            Random gen = new Random(Guid.NewGuid().GetHashCode());
            int range = (DateTime.Today - start).Days;
            return start.AddDays(gen.Next(range)).ToString(outputDateFormat);
        }
        private void HandleParentScrollView(ScrollView parentScrollView)
        {
            Debug.WriteLine($"Scroll Y: {parentScrollView.ScrollY}");
            if (parentScrollView.ScrollY >= 170)
            {
                //ParentScrollViewEnabled = false;
                ChildScrollViewEnabled = true;
            }
            else
            {
                //ParentScrollViewEnabled = true;
                ChildScrollViewEnabled = false;
            }
        }
    }
}
