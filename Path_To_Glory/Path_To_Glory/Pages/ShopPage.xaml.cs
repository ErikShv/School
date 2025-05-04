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
using Windows.UI.Popups;
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
    public sealed partial class ShopPage : Page
    {
        public ShopPage()
        {
            this.InitializeComponent();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MenuPage));
        }

        private void BuyPistol_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            BuyPistolImg.Source = new BitmapImage(new Uri("ms-appx:///Assets/Buttons/PressedBuyButton.png"));
        }

        private void BuyPistol_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            BuyPistolImg.Source = new BitmapImage(new Uri("ms-appx:///Assets/Buttons/BuyButton.png"));
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
            Souls.Text = GameManager.GameUser.Souls.ToString();
            if (GameManager.GameUser.UserName == "Anonymous")
            {
                EquipmentBtn.IsEnabled = false;
            }
        }
        //קניית הפוואר אפ
         private async void BuyPowerup1_Click(object sender, RoutedEventArgs e)
        {
            if(GameManager.GameUser.Souls < 1)
            {
                await new MessageDialog("Not Enough Souls!", "Path To Glory").ShowAsync();
            }
            else
            {
                List<int> Ids = Server.GetOwnProductsId(GameManager.GameUser);
                if (Ids.Contains(1))
                {
                    await new MessageDialog("You Already Own This Product!", "Path To Glory").ShowAsync();
                }
                else
                {
                    GameManager.GameUser.Souls -=1;
                    GameManager.GameUser.CurrentPowerUp = 2;
                    Server.AddProduct(GameManager.GameUser);
                    Souls.Text = GameManager.GameUser.Souls.ToString();
                    await new MessageDialog("Product Added Succesfully!", "Path To Glory").ShowAsync();
                    Server.SaveData(GameManager.GameUser);
                }
            }
        }
         /// <summary>
         /// קניית הפוואר אפ
         /// </summary>
        private async void PowerUp3_Click(object sender, RoutedEventArgs e)
        {
            if (GameManager.GameUser.Souls < 2)
            {
                await new MessageDialog("Not Enough Souls!", "Path To Glory").ShowAsync();
            }
            else
            {
                List<int> Ids = Server.GetOwnProductsId(GameManager.GameUser);
                if (Ids.Contains(3))
                {
                    await new MessageDialog("You Already Own This Product!", "Path To Glory").ShowAsync();
                }
                else
                {
                    GameManager.GameUser.Souls -= 2;
                    GameManager.GameUser.CurrentPowerUp = 3;
                    Server.AddProduct(GameManager.GameUser);
                    Souls.Text = GameManager.GameUser.Souls.ToString();
                    await new MessageDialog("Product Added Succesfully!", "Path To Glory").ShowAsync();
                    Server.SaveData(GameManager.GameUser);
                }
            }
        }

        private void EquipmentBtn_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            EquipmentImg.Source = new BitmapImage(new Uri("ms-appx:///Assets/Buttons/PressedEquipmentBtn.png"));
            Windows.UI.Xaml.Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Hand, 1);
        }

        private void EquipmentBtn_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            EquipmentImg.Source = new BitmapImage(new Uri("ms-appx:///Assets/Buttons/EquipmentBtn.png"));
            Windows.UI.Xaml.Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Arrow, 1);
        }

        private void EquipmentBtn_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(PowerupSelect));
        }
    }
}
