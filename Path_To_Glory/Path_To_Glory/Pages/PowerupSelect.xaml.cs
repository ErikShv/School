using DatabaseProject;
using DatabaseProject.Models;
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
    public sealed partial class PowerupSelect : Page
    {
        private List<int> _ownproductsId = null; //רשימת מספרי המוצרים ששייכים לי
        private List<Product> _allproducts = null;//רשימת כל המוצרים
        private List<Product> _chooseproduct = null;
        public PowerupSelect()
        {
            this.InitializeComponent();
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
        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MenuPage));
        }
        /// <summary>
        /// מראה את כל המשקים שיש למשתמש
        /// </summary>
        private void Page_Loaded_1(object sender, RoutedEventArgs e)
        {
            PowerList.SelectedIndex = 0;
            Souls.Text = GameManager.GameUser.Souls.ToString();
            _ownproductsId = Server.GetOwnProductsId(GameManager.GameUser); //מקבלים את מספרי המוצרים בבעלות השחקן
            _chooseproduct = new List<Product>();
            _allproducts = GetProducts();

            foreach (Product product in _allproducts)
            {
                if (IsExist(_ownproductsId, product.Id))
                {
                    _chooseproduct.Add(product);
                }
            }
            ShowProducts();//הפעולה מראה את המוצרים שנמצעים בבעלות המשתמש על המסך
        }
        //שם את התמונות של המשקים
        private void ShowProducts()
        {
            Image image;
            foreach (Product prdct in _chooseproduct)
            {
                image = GetImage(prdct.Id);
                PowerList.Items.Add(image);
            }
        }
        //לוקח את התמונות מה Assets
        private Image GetImage(int id)
        {
            Image image = new Image();
            image.Width = 50;
            image.Height = 50;
            switch (id)
            {
                case 1: image.Source = new BitmapImage(new Uri("ms-appx:///Assets/Powerups/Powerup.png"));break;
                case 2: image.Source = new BitmapImage(new Uri("ms-appx:///Assets/ShopItems/Shoes.png")); break;
                case 3: image.Source = new BitmapImage(new Uri("ms-appx:///Assets/ShopItems/Scythe.png")); break;
            }
            return image;
        }
        //בודק אם המשק קיים
        private bool IsExist(List<int> ownproductsId, int id)
        {
            foreach( int index in ownproductsId)
            {
                if(index == id)
                {
                    return true;
                }
            }
            return false;
        }
        //רשימה של כל המשקים
        private List<Product> GetProducts() // הפעולה ממלאה את רשימת המוצרים שיש במשחק
        {
            _allproducts = new List<Product>();
            _allproducts.Add(new Product
            {
                Id = 1,
                Price =0
            }) ;
            _allproducts.Add(new Product
            {
                Id = 2,
                Price = 1
            });
            _allproducts.Add(new Product
            {
                Id = 3,
                Price = 2

            });
            return _allproducts;
        }

        private void YesBtn_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            YesImg.Source = new BitmapImage(new Uri("ms-appx:///Assets/Buttons/PressedYesBtn.png"));
            Windows.UI.Xaml.Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Hand, 1);
        }

        private void YesBtn_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            YesImg.Source = new BitmapImage(new Uri("ms-appx:///Assets/Buttons/YesBtn.png"));
            Windows.UI.Xaml.Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Arrow, 1);
        }

        private void NoBtn_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            NoImg.Source = new BitmapImage(new Uri("ms-appx:///Assets/Buttons/PressedNoBtn.png"));
            Windows.UI.Xaml.Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Hand, 1);
        }

        private void NoBtn_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            NoImg.Source = new BitmapImage(new Uri("ms-appx:///Assets/Buttons/NoBtn.png"));
            Windows.UI.Xaml.Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Arrow, 1);
        }
        //שומר את המשק שהמשתמש בחר
        private void YesBtn_Click(object sender, RoutedEventArgs e)
        {
            GameManager.GameUser.CurrentPowerUp = PowerList.SelectedIndex +1;
            Server.SaveData(GameManager.GameUser);
        }

        private void NoBtn_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ShopPage));
        }
    }
}
