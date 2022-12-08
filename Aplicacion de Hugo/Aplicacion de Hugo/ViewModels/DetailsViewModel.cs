using Aplicacion_de_Hugo.Models;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace Aplicacion_de_Hugo.ViewModels
{
    public class DetailsViewModel : BaseViewModel
    {

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

        private int position;

        public int Position
        {
            get
            {
                if (position != burgers.IndexOf(SelectedBurger))
                    return burgers.IndexOf(selectedBurger);
                return position;
            }
            set
            {
                position = value;
                selectedBurger = burgers[position];
                OnPropertyChanged();
                OnPropertyChanged(nameof(selectedBurger));
            }
        }

        public ICommand ChangePositionCommand => new Command(ChangePosition);

        private void ChangePosition(object obj)
        {
            string direction = (string)obj;

            if (direction == "L")
            {
                if (Position == 0)
                {
                    Position = burgers.Count - 1;
                    return;
                }

                Position -= 1;
            }
            else if (direction == "R")
            {
                if (Position == burgers.Count - 1)
                {
                    position = 0;
                    return;
                }
                Position += 1;
            }
        }
    }
}