﻿using DatabaseProject;
using Path_To_Glory.GameServices;
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
        private void ContinueBtn_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            ContinueImg.Source = new BitmapImage(new Uri("ms-appx:///Assets/Buttons/PressedContinueButton.png"));
            Windows.UI.Xaml.Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Hand, 1);
        }

        private void ContinueBtn_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            ContinueImg.Source = new BitmapImage(new Uri("ms-appx:///Assets/Buttons/ContinueButton.png"));
            Windows.UI.Xaml.Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Arrow, 1);
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
        //מכניס את השחקן לשלב שמלמד אותו איך לשחק
        private void TutorialBtn_Click(object sender, RoutedEventArgs e)
        {
            var clickbutton = (Button)sender;//גיליתי מהו הלחצן שגרם לפעולה להתבצע
            GameManager.GameUser.MaxLevel = 1;
            GameManager.GameUser.CurrentLevel.LevelId = 1;
            GameManager.GameUser.CurrentLevel.LevelNum = 1;
            GameManager.GameUser.Coins = 0;
            GameManager.GameUser.Hp = 3;
            Server.SaveData(GameManager.GameUser);
            CreateLevel(clickbutton.TabIndex);
            Frame.Navigate(typeof(Room1));
        }
        //הפעולה תמלא ערכי השלב שהמשתמש בחר
        private void CreateLevel(int Level)
        {
            Server.SetCurrentLevel(GameManager.GameUser, GameManager.GameUser.MaxLevel);
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
        //שם את השחקן בלבל האחרון ששיחק בו
        private void ContinueBtn_Click(object sender, RoutedEventArgs e)
        {
            var clickbutton = (Button)sender;//גיליתי מהו הלחצן שגרם לפעולה להתבצע
            CreateLevel(clickbutton.TabIndex);
            Frame.Navigate(typeof(Room1));
        }
        //שם את הערכים הדיפולטיווים של המשחק ומתחיל משחק חדש
        private void NewGameBtn_Click(object sender, RoutedEventArgs e)
        {
            var clickbutton = (Button)sender;//גיליתי מהו הלחצן שגרם לפעולה להתבצע
            GameManager.GameUser.MaxLevel = 2;
            GameManager.GameUser.CurrentLevel.LevelId = 2;
            GameManager.GameUser.CurrentLevel.LevelNum = 2;
            GameManager.GameUser.Coins = 0;
            GameManager.GameUser.Hp = 3;
            Server.SaveData(GameManager.GameUser);
            CreateLevel(clickbutton.TabIndex);
            Frame.Navigate(typeof(Room1));
        }
    }
}
