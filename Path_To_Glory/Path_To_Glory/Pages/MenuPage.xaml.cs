﻿using GameEngine.GameServices;
using Path_To_Glory.GameServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
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
            Windows.UI.Xaml.Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Hand, 1);
        }
        private void PlayBtn_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            PlayImg.Source = new BitmapImage(new Uri("ms-appx:///Assets/Buttons/PlayButton.png"));
            Windows.UI.Xaml.Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Arrow, 1);
        }
        private void OptionBtn_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            OptionImg.Source = new BitmapImage(new Uri("ms-appx:///Assets/Buttons/PressedOptionButton.png"));
            Windows.UI.Xaml.Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Hand, 1);
        }
        private void OptionBtn_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            OptionImg.Source = new BitmapImage(new Uri("ms-appx:///Assets/Buttons/OptionButton.png"));
            Windows.UI.Xaml.Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Arrow, 1);
        }
        private void ShopBtn_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            ShopImg.Source = new BitmapImage(new Uri("ms-appx:///Assets/Buttons/PressedShopButton.png"));
            Windows.UI.Xaml.Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Hand, 1);
        }
        private void ShopBtn_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            ShopImg.Source = new BitmapImage(new Uri("ms-appx:///Assets/Buttons/ShopButton.png"));
            Windows.UI.Xaml.Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Arrow, 1);
        }
        private void QuitBtn_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            QuitImg.Source = new BitmapImage(new Uri("ms-appx:///Assets/Buttons/PressedQuitButton.png"));
            Windows.UI.Xaml.Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Hand, 1);
        }
        private void QuitBtn_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            QuitImg.Source = new BitmapImage(new Uri("ms-appx:///Assets/Buttons/QuitButton.png"));
            Windows.UI.Xaml.Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Arrow, 1);
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
            Popup.Visibility = Visibility.Visible;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(SignUp));
        }
        private void Button_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            SignUpImg.Source = new BitmapImage(new Uri("ms-appx:///Assets/Buttons/PressedSignUp.png"));
            Windows.UI.Xaml.Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Hand, 1);
        }
        private void Button_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            SignUpImg.Source = new BitmapImage(new Uri("ms-appx:///Assets/Buttons/SignUpButton.png"));
            Windows.UI.Xaml.Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Arrow, 1);
        }
        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(LoginPage));
        }
        private void LoginBtn_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            LoginImg.Source = new BitmapImage(new Uri("ms-appx:///Assets/Buttons/PressedLoginButton.png"));
            Windows.UI.Xaml.Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Hand, 1);
        }
        private void LoginBtn_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            LoginImg.Source = new BitmapImage(new Uri("ms-appx:///Assets/Buttons/LoginButton.png"));
            Windows.UI.Xaml.Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Arrow, 1);
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
            Windows.UI.Xaml.Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Hand, 1);
        }
        private void AboutBtn_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            AboutImg.Source = new BitmapImage(new Uri("ms-appx:///Assets/Buttons/AboutButton.png"));
            Windows.UI.Xaml.Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Arrow, 1);
        }
        private void QuitYesBtn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Exit();
        }
        private void QuitYesBtn_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            YesImg.Source = new BitmapImage(new Uri("ms-appx:///Assets/Buttons/PressedYesButton.png"));
            Windows.UI.Xaml.Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Hand, 1);
        }
        private void QuitYesBtn_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            YesImg.Source = new BitmapImage(new Uri("ms-appx:///Assets/Buttons/YesButton.png"));
            Windows.UI.Xaml.Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Arrow, 1);
        }
        private void QuitNoBtn_Click(object sender, RoutedEventArgs e)
        {
            Popup.Visibility = Visibility.Collapsed;
        }
        private void QuitNoBtn_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            NoImg.Source = new BitmapImage(new Uri("ms-appx:///Assets/Buttons/PressedNoButton.png"));
            Windows.UI.Xaml.Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Hand, 1);
        }
        private void QuitNoBtn_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            
            NoImg.Source = new BitmapImage(new Uri("ms-appx:///Assets/Buttons/NoButton.png"));
            Windows.UI.Xaml.Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Arrow, 1);
        }
        private void PlayBtn_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(LevelSelectPage));
        }
        //פעולות שקורות ישר שהדף עולה
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (!Music._Flag)
            {
                Music.Play("MusicTest.mp3");
            }
            if (GameManager.GameUser.UserName != "Anonymous")
            {
                LoginBtn.IsEnabled = false;
                LoginBtn.Visibility = Visibility.Collapsed;
                SignUpBtn.IsEnabled = false;
                SignUpBtn.Visibility = Visibility.Collapsed;
            }
        }
    }
}
