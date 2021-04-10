﻿using System;
using WLinkClone.Views;
using WLinkClone.Views.Home;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
[assembly: ExportFont("materialdesignicons.ttf", Alias = "Material")]
[assembly: ExportFont("PoppinsRegular.ttf", Alias = "PoppinsRegular")]
[assembly: ExportFont("PoppinsSemiBold.ttf", Alias = "PoppinsSemiBold")]
namespace WLinkClone
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new HomePage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
