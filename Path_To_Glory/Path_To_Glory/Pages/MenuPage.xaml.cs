using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Core;
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
    public sealed partial class MenuPage : Page
    {
        public MenuPage()
        {
            this.InitializeComponent();
        }

        private void PlayBtn_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            PlayImg.Source = new BitmapImage(new Uri("ms-appx:///Assets/Buttons/PressedPlayButton.png"));
        }

        private void PlayBtn_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            PlayImg.Source = new BitmapImage(new Uri("ms-appx:///Assets/Buttons/PlayButton.png"));
        }

        private void OptionBtn_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            OptionImg.Source = new BitmapImage(new Uri("ms-appx:///Assets/Buttons/PressedOptionButton.png"));
        }

        private void OptionBtn_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            OptionImg.Source = new BitmapImage(new Uri("ms-appx:///Assets/Buttons/OptionButton.png"));
        }

        private void ShopBtn_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            ShopImg.Source = new BitmapImage(new Uri("ms-appx:///Assets/Buttons/PressedShopButton.png"));
        }

        private void ShopBtn_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            ShopImg.Source = new BitmapImage(new Uri("ms-appx:///Assets/Buttons/ShopButton.png"));
        }

        private void QuitBtn_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            QuitImg.Source = new BitmapImage(new Uri("ms-appx:///Assets/Buttons/PressedQuitButton.png"));
        }

        private void QuitBtn_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            QuitImg.Source = new BitmapImage(new Uri("ms-appx:///Assets/Buttons/QuitButton.png"));
        }

        private void OptionBtn_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(OptionsPage));
        }

        private void ShopBtn_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ShopPage));
        }

        private void QuitBtn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Exit();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(SignUp));
        }

        private void Button_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            SignUpImg.Source = new BitmapImage(new Uri("ms-appx:///Assets/Buttons/PressedSignUp.png"));
        }

        private void Button_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            SignUpImg.Source = new BitmapImage(new Uri("ms-appx:///Assets/Buttons/SignUpButton.png"));
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(LoginPage));
        }

        private void LoginBtn_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            LoginImg.Source = new BitmapImage(new Uri("ms-appx:///Assets/Buttons/PressedLoginButton.png"));
        }

        private void LoginBtn_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            LoginImg.Source = new BitmapImage(new Uri("ms-appx:///Assets/Buttons/LoginButton.png"));
        }

        private void LeaderBtn_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(LeaderboardPage));
        }

        private void LeaderBtn_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            LeaderImg.Source = new BitmapImage(new Uri("ms-appx:///Assets/Buttons/PressedLeaderboardButton.png"));
            Windows.UI.Xaml.Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Hand, 1);
        }

        private void LeaderBtn_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            LeaderImg.Source = new BitmapImage(new Uri("ms-appx:///Assets/Buttons/LeaderboardButton.png"));
            Windows.UI.Xaml.Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Arrow, 1);
        }

        
        private void AboutBtn_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AboutPage));
        }

        private void AboutBtn_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            AboutImg.Source = new BitmapImage(new Uri("ms-appx:///Assets/Buttons/PressedAboutButton.png"));
        }

        private void AboutBtn_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            AboutImg.Source = new BitmapImage(new Uri("ms-appx:///Assets/Buttons/AboutButton.png"));
        }
    }
}
