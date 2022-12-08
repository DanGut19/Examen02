using Aplicacion_de_Hugo.Models;
using Aplicacion_de_Hugo.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Aplicacion_de_Hugo.ViewModels
{
    public class LandingViewModel : BaseViewModel
    {
        public LandingViewModel() 
        {
            burgers = GetBurgers();
        }

        ObservableCollection<Burger> burgers;
        public ObservableCollection<Burger> Burgers 
        { 
            get { return burgers; } 
            set
            {
                burgers = value;
                OnPropertyChanged();
            }
        }

        private Burger selectedBurger;

        public Burger SelectedBurger
        {
            get { return selectedBurger; }
            set
            {
                selectedBurger = value;
                OnPropertyChanged();
            }
        }

        public ICommand SelectionCommand => new Command(DisplayBurger);

        private void DisplayBurger()
        {
            if (selectedBurger != null)
            {
                var ViewModel = new DetailsViewModel { SelectedBurger = selectedBurger,Burgers = burgers,Position = burgers.IndexOf(selectedBurger) };
                var detailsPage = new DetailsPage { BindingContext = ViewModel };

                var navigation = Application.Current.MainPage as NavigationPage;
                navigation.PushAsync(detailsPage, true);
            }
        }

        private ObservableCollection<Burger> GetBurgers()
        {
            return new ObservableCollection<Burger>
            {
                new Burger {Name = "Doble", Price = 19.99f, Image = "doble", Description = ".........."},
                new Burger {Name = "Pollo", Price = 15.99f, Image = "pollo", Description = ".........."},
                new Burger {Name = "Carne", Price = 11.99f, Image = "carne", Description = ".........."},
                new Burger {Name = "BBQ", Price = 13.99f, Image = "BBQ", Description = ".........."},
            };
        }
    }
}