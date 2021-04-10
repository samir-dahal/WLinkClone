﻿using System;
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
            "https://bit.ly/3s1xTkV", "https://bit.ly/2PQGpq2", "https://bit.ly/3mC8nSw", "https://bit.ly/3t2oISG",
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
