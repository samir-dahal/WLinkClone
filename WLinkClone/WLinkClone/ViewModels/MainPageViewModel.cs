using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace WLinkClone.ViewModels
{
    public class MainPageViewModel : ObservableBase
    {
        private int _position;

        public int Position
        {
            get { return _position; }
            set { _position = value; OnPropertyChanged(nameof(Position)); }
        }
        public ObservableRangeCollection<string> Images { get; set; } = new ObservableRangeCollection<string>
        {
            "https://picsum.photos/500/500", "https://picsum.photos/499/499", "https://picsum.photos/498/498",
            "https://picsum.photos/497/497", "https://picsum.photos/496/496", "https://picsum.photos/495/495",
        };
        public MainPageViewModel()
        {
            Device.StartTimer(TimeSpan.FromSeconds(new Random().Next(2, 5)), (Func<bool>)(() =>
            {
                Position = (Position + 1) % Images.Count;
                return true;
            }));
        }
    }
}
