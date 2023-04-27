using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MealsExpensesTracker
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterDetailPageMealsFlyout : ContentPage
    {
        public ListView ListView;

        public MasterDetailPageMealsFlyout()
        {
            InitializeComponent();

            BindingContext = new MasterDetailPageMealsFlyoutViewModel();
            ListView = MenuItemsListView;
        }

        class MasterDetailPageMealsFlyoutViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MasterDetailPageMealsFlyoutMenuItem> MenuItems { get; set; }
            
            public MasterDetailPageMealsFlyoutViewModel()
            {
                MenuItems = new ObservableCollection<MasterDetailPageMealsFlyoutMenuItem>(new[]
                {
                    new MasterDetailPageMealsFlyoutMenuItem { Id = 0, Title = "Home", TargetType=typeof(Home) },
                    new MasterDetailPageMealsFlyoutMenuItem { Id = 1, Title = "Food Expense", TargetType=typeof(MainPage) },
                    new MasterDetailPageMealsFlyoutMenuItem { Id = 2, Title = "Record", TargetType=typeof(TabbedExpenses) },
                    new MasterDetailPageMealsFlyoutMenuItem { Id = 3, Title = "About", TargetType=typeof(About) },
                });
            }
            
            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}