using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WLinkClone.Helpers;
using WLinkClone.Views.Home;
using WLinkClone.Views.Support;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace WLinkClone.ViewModels
{
    public class BasePageViewModel : ObservableBase
    {

        public ObservableRangeCollection<FooterMenu> FooterMenuItems { get; set; } = new ObservableRangeCollection<FooterMenu>();
        public BasePageViewModel()
        {
            FooterMenuItems.CollectionChanged += FooterMenuItems_CollectionChanged;
            var items = new List<FooterMenu>();
            items.Add(new FooterMenu(async () => await PageHelper.SetMainPageAsync(new HomePage()))
            {
                Name = "Home",
                Type = FooterMenuType.Home,
                Icon = MaterialIconHelper.Home,
            });
            items.Add(new FooterMenu(async () => await PageHelper.SetMainPageAsync(new SupportPage()))
            {
                Name = "Support",
                Type = FooterMenuType.Support,
                Icon = MaterialIconHelper.Headphones,
            });
            items.Add(new FooterMenu
            {
                Name = "Billing",
                Type = FooterMenuType.Billing,
                Icon = MaterialIconHelper.NoteText,
            });
            items.Add(new FooterMenu
            {
                Name = "More",
                Type = FooterMenuType.More,
                Icon = MaterialIconHelper.Menu,
            });
            FooterMenuItems.AddRange(items);
        }

        private void FooterMenuItems_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            var currentFooterTab = FooterMenuItems.FirstOrDefault(item => item.Type == App.CurrentFooterMenuType);
            currentFooterTab.SelectedColor = App.SelectedTabColor;
        }
        public override void Dispose()
        {
            FooterMenuItems.CollectionChanged -= FooterMenuItems_CollectionChanged;
        }
    }
    public enum FooterMenuType
    {
        Home,
        Support,
        More,
        Billing,
    }
    public class FooterMenu : ObservableBase
    {
        public string Icon { get; set; }
        public string Name { get; set; }
        private Color _selectedColor = Color.Gray;

        public Color SelectedColor
        {
            get { return _selectedColor; }
            set { _selectedColor = value; OnPropertyChanged(nameof(SelectedColor)); }
        }
        public FooterMenuType Type { get; set; }
        public ICommand FooterMenuTappedCommand { get; }
        private Func<Task> _menuTappedAction;
        public FooterMenu(Func<Task> menuTappedAction = null)
        {
            _menuTappedAction = menuTappedAction;
            FooterMenuTappedCommand = new Command(async () =>
            {
                App.CurrentFooterMenuType = this.Type;
                if(menuTappedAction is not null) await menuTappedAction();
            });
        }
    }
}
