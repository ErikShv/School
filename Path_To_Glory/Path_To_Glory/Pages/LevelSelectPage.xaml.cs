﻿using Path_To_Glory.GameServices;
using Path_To_Glory.Pages.Levels.Tutorial;
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
    public sealed partial class LevelSelectPage : Page
    {
        public LevelSelectPage()
        {
            this.InitializeComponent();
        }

        private void NewGameBtn_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            NewGameImg.Source = new BitmapImage(new Uri("ms-appx:///Assets/Buttons/PressedNewGameButton.png"));
            Windows.UI.Xaml.Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Hand, 1);
        }

        private void NewGameBtn_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            NewGameImg.Source = new BitmapImage(new Uri("ms-appx:///Assets/Buttons/NewGameButton.png"));
            Windows.UI.Xaml.Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Arrow, 1);
        }

        private void TutorialBtn_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            TutorialImg.Source = new BitmapImage(new Uri("ms-appx:///Assets/Buttons/PressedTutorialButton.png"));
            Windows.UI.Xaml.Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Hand, 1);
        }

        private void TutorialBtn_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            TutorialImg.Source = new BitmapImage(new Uri("ms-appx:///Assets/Buttons/TutorialButton.png"));
            Windows.UI.Xaml.Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Arrow, 1);
        }

        private void TutorialBtn_Click(object sender, RoutedEventArgs e)
        {
            var clickbutton = (Button)sender;//'גיליתי מהו הלחצן שגרם לפעולה להתבצע
            CreateLevel(clickbutton.TabIndex);
            Frame.Navigate(typeof(Room1));
        }
        //הפעולה תמלא ערכי השלב שהמשתמש בחר
        private void CreateLevel(int Level)
        {
            switch (Level)
            {
                case 1:GameManager.GameUser.CurrentLevel.LevelId = 1;
                    GameManager.GameUser.CurrentLevel.LevelNum = 1;
                    GameManager.GameUser.CurrentLevel.SkeletonHp = 1;
                    GameManager.GameUser.CurrentLevel.ReaprHp = 1;
                    GameManager.GameUser.CurrentLevel.GolemHp = 3;
                    GameManager.GameUser.CurrentLevel.CountBoss = 0;
                    GameManager.GameUser.CurrentLevel.CountReaper = 1;
                    GameManager.GameUser.CurrentLevel.CountSkeleton = 1;
                    GameManager.GameUser.CurrentLevel.CountGolem = 2;
                    GameManager.GameUser.CurrentLevel.CountPlatform = 3;
                    GameManager.GameUser.CurrentLevel.CountMonster = 4;
                    break;
                case 2:
                    GameManager.GameUser.CurrentLevel.LevelId = 2;
                    GameManager.GameUser.CurrentLevel.LevelNum = 2;
                    GameManager.GameUser.CurrentLevel.SkeletonHp = 1;
                    GameManager.GameUser.CurrentLevel.ReaprHp = 2;
                    GameManager.GameUser.CurrentLevel.GolemHp = 3;
                    GameManager.GameUser.CurrentLevel.CountBoss = 0;
                    GameManager.GameUser.CurrentLevel.CountReaper = 1;
                    GameManager.GameUser.CurrentLevel.CountSkeleton = 3;
                    GameManager.GameUser.CurrentLevel.CountGolem = 1;
                    GameManager.GameUser.CurrentLevel.CountPlatform = 5;
                    GameManager.GameUser.CurrentLevel.CountMonster = 5;
                    break;
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
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
    }
}
