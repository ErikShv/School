using DatabaseProject;
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
            Server.SetCurrentLevel(GameManager.GameUser, GameManager.GameUser.MaxLevel);
            _gameManager = new GameManager(scene);
            Manager.GameEvent.OnRemoveLife += update;
            Manager.GameEvent.OnGetLife += PuckupHeart;
            Manager.GameEvent.OnGetCoin += PickUpCoin;
            Manager.GameEvent.OnGameOver += MainScreen;
            GameManager.Events.OnNextRoom += NextRoom;
            GameManager.Events.OnWinGame += WinScreen;
            GameManager.Events.CheckHp += CheckHp;
            GameManager.Events.CheckCoins += CheckCoins;
            GameManager.Events.CheckCoins(GameManager.GameUser.Coins);
            CheckHp(GameManager.GameUser.Hp);
        }
        /// <summary>
        /// מעביר למסך ניצחון
        /// </summary>
        private void WinScreen()
        {
            
            Frame.Navigate(typeof(YouWinPage));
            
        }
        /// <summary>
        /// מוודא מספר המטבעות שיש לשחקן הוא מספר המטבעות שעל המסך
        /// </summary>
        private void CheckCoins(int Coins)
        {
            Coinstxt.Text = Coins.ToString();
        }
        /// <summary>
        /// מוודא שכמות החיים שיש לשחקן זה כמות החיים שעל המסך
        /// </summary>
        /// <param name="Hp"> כמות החיים של השחקן</param>
        private void CheckHp(int Hp)
        {
            
            if (Hp == 2)
            {
                Hp3.Source = new BitmapImage(new Uri("ms-appx:///Assets/GameUi/EmptyHeart.png"));
                

            }
            if (Hp == 1)
            {
                Hp3.Source = new BitmapImage(new Uri("ms-appx:///Assets/GameUi/EmptyHeart.png"));
                Hp2.Source = new BitmapImage(new Uri("ms-appx:///Assets/GameUi/EmptyHeart.png"));

            }
        }
        /// <summary>
        /// מעביר את השחקן לחדר הבא
        /// </summary>
        private void NextRoom()
        {
            scene.RemoveAllObjects();
            if (GameManager.GameUser.CurrentLevel.LevelNum == 1)
            {
                GameManager.GameUser.CurrentLevel.LevelNum = 2;
                GameManager.GameUser.MaxLevel = 2;
                Frame.Navigate(typeof(Room1));
                

            }
            else
            {
                if (GameManager.GameUser.CurrentLevel.LevelNum == 2)
                {
                    GameManager.GameUser.CurrentLevel.LevelNum = 3;
                    GameManager.GameUser.MaxLevel = 3;
                    Frame.Navigate(typeof(Room1));
                    
                }
                else
                {
                    if (GameManager.GameUser.CurrentLevel.LevelNum == 3)
                    {
                        GameManager.GameUser.CurrentLevel.LevelNum = 4;
                        GameManager.GameUser.MaxLevel = 4;
                        Frame.Navigate(typeof(Room1));
                        
                    }
                   
                }
            }
            GameManager.GameUser.MaxLevel = GameManager.GameUser.CurrentLevel.LevelNum;
            Server.SaveData(GameManager.GameUser);


        }
        /// <summary>
        /// מחזיר את הערכים של השחקן לערכים הדיפולטיווים אחריי שמת
        /// </summary>
        private void MainScreen()
        {
            GameManager.GameUser.Hp = 3;
            GameManager.GameUser.Coins = 0;
            GameManager.GameUser.CurrentLevel.LevelId = 2;
            GameManager.GameUser.CurrentLevel.LevelNum = 2;
            GameManager.GameUser.MaxLevel = 2;
            Server.SaveData(GameManager.GameUser);
            Frame.Navigate(typeof(MenuPage));
        }
        //מוסיף למסך ולשחקן מטבעות
        private void PickUpCoin(int Coins)
        {

            Coinstxt.Text = Coins.ToString();
            GameManager.GameUser.Coins++;
        }
        //מוסיף לשחקן חיים
        private void PuckupHeart(int Hp)
        {
           
            if (Hp == 2)
            {
                Hp3.Source = new BitmapImage(new Uri("ms-appx:///Assets/GameUi/Heart.png"));

            }
            if (Hp == 1)
            {
                Hp2.Source = new BitmapImage(new Uri("ms-appx:///Assets/GameUi/Heart.png"));

            }
        }
        //אחריי שעובר דף מעדכן את החיים של השחקן לחיים שהיו לו בדף הקודם
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

        private void HomeBtn_Click(object sender, RoutedEventArgs e)
        {
            PopupMenu.Visibility = Visibility.Visible;
        }

        private void HomeBtn_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            HomeImg.Source = new BitmapImage(new Uri("ms-appx:///Assets/Buttons/HomeBtnPressed.png"));
            Windows.UI.Xaml.Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Hand, 1);
        }

        private void HomeBtn_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            HomeImg.Source = new BitmapImage(new Uri("ms-appx:///Assets/Buttons/HomeBtn.png"));
            Windows.UI.Xaml.Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Arrow, 1);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Server.SaveData(GameManager.GameUser);
            Frame.Navigate(typeof(MenuPage));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            PopupMenu.Visibility = Visibility.Collapsed;
        }

        private void Button_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            ContinueImg.Source = new BitmapImage(new Uri("ms-appx:///Assets/Buttons/PressedQuitButton.png"));
            Windows.UI.Xaml.Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Hand, 1);
        }

        private void Button_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            ContinueImg.Source = new BitmapImage(new Uri("ms-appx:///Assets/Buttons/QuitButton.png"));
            Windows.UI.Xaml.Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Arrow, 1);
        }

        private void Button_PointerEntered_1(object sender, PointerRoutedEventArgs e)
        {
            QuitImg.Source = new BitmapImage(new Uri("ms-appx:///Assets/Buttons/PressedContinueButton.png"));
            Windows.UI.Xaml.Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Hand, 1);
        }

        private void Button_PointerExited_1(object sender, PointerRoutedEventArgs e)
        {
            QuitImg.Source = new BitmapImage(new Uri("ms-appx:///Assets/Buttons/ContinueButton.png"));
            Windows.UI.Xaml.Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Arrow, 1);
        }
    }    }

