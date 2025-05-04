using DatabaseProject;
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

namespace Path_To_Glory.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class YouWinPage : Page
    {
        public YouWinPage()
        {
            this.InitializeComponent();
        }
        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            Server.SaveData(GameManager.GameUser);
            Frame.Navigate(typeof(MenuPage));
        }

        private void BackBtn_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            BackImg.Source = new BitmapImage(new Uri("ms-appx:///Assets/Buttons/PressedBackButton.png"));
            Windows.UI.Xaml.Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Hand, 1);
        }

        private void BackBtn_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            BackImg.Source = new BitmapImage(new Uri("ms-appx:///Assets/Buttons/BackButton.png"));
            Windows.UI.Xaml.Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Arrow, 1);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            GameManager.GameUser.CurrentLevel.LevelNum = 2;
            GameManager.GameUser.MaxLevel = 2;
            GameManager.GameUser.Souls += GameManager.GameUser.Coins/20;
            GameManager.GameUser.Hp = 3;
            GameManager.GameUser.Coins = 0;
        }
    }
}
