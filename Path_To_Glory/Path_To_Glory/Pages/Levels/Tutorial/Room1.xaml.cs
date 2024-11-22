using GameEngine.GameServices;
using Path_To_Glory.GameServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Path_To_Glory.Pages.Levels.Tutorial
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Room1 : Page
    {
        private GameManager _gameManager;
        public Room1()
        {
            this.InitializeComponent();
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            _gameManager = new GameManager(scene);
            Manager.GameEvent.OnRemoveLife += update;
        }
        private void update(int Hp)
        {
            if (Hp == 3)
            {
                Hp3.Source = new BitmapImage(new Uri("ms-appx:///Assets/GameUi/EmptyHeart.png"));

            }
            if (Hp == 2)
            {
                Hp2.Source = new BitmapImage(new Uri("ms-appx:///Assets/GameUi/EmptyHeart.png"));

            }
            if (Hp == 1)
            {
                Hp1.Source = new BitmapImage(new Uri("ms-appx:///Assets/GameUi/EmptyHeart.png"));

            }
        }
}    }

