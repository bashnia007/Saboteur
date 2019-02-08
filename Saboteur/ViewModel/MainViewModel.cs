using System.Collections.Generic;
using System.Collections.ObjectModel;
using CommonLibrary.CardsClasses;
using Saboteur.MVVM;

namespace Saboteur.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public readonly MainWindow Window;
        public PlayerHandViewModel MyHand { get; set; }
        public PlayerHandViewModel EnemyHand { get; set; }
        public ObservableCollection<ObservableCollection<RouteCard>> Map { get; set; }

        public MainViewModel()
        {
            Window = new MainWindow();
            Window.DataContext = this;
            MyHand = new PlayerHandViewModel();
            EnemyHand = new PlayerHandViewModel();

            var list = new List<RouteCard>
            {
                new RouteCard(),
                new RouteCard(),
                new RouteCard(),
                new RouteCard(),
                new RouteCard(),
                new RouteCard(),
                new RouteCard(),
                new RouteCard(),
                new RouteCard(),
            };
            Map = new ObservableCollection<ObservableCollection<RouteCard>>();
            Map.Add(new ObservableCollection<RouteCard>(list));
            Map.Add(new ObservableCollection<RouteCard>(list));
            Map.Add(new ObservableCollection<RouteCard>(list));
            Map.Add(new ObservableCollection<RouteCard>(list));
            Map.Add(new ObservableCollection<RouteCard>(list));
            Map.Add(new ObservableCollection<RouteCard>(list));
            Map.Add(new ObservableCollection<RouteCard>(list));
        }
    }
}
