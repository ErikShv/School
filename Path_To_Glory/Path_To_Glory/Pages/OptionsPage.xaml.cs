using GameEngine.GameServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
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
    public sealed partial class OptionsPage : Page
    {
        public OptionsPage()
        {
            this.InitializeComponent();
        }
        //מדליק ומפסיק את המוזיקה ומשנה את התמונה בהתאם למצב
        private void SfxBtn_Click(object sender, RoutedEventArgs e)
        {
            if (SfxImg.Source is BitmapImage currentImage &&
     currentImage.UriSource == new Uri("ms-appx:///Assets/Buttons/OnButton.png"))
            {
                Music._Flag = true;
                SfxImg.Source = new BitmapImage(new Uri("ms-appx:///Assets/Buttons/OffButton.png"));
                Music.Pause();
            }
            else
            {
                SfxImg.Source = new BitmapImage(new Uri("ms-appx:///Assets/Buttons/OnButton.png"));
                Music.Play("MusicTest.mp3");
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

        private void SfxBtn_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            Windows.UI.Xaml.Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Hand, 1);
        }

        private void SfxBtn_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            Windows.UI.Xaml.Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Arrow, 1);
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

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            
            MusicSlider.Value = Music.Volume;
        }
        //שם את הווליום של המוזיקה בהתאם למספר שנמצא בסליידר
        private void MusicSlider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            Music.Volume = (int)MusicSlider.Value;
        }
        //שומר את השינויים שהמשתמש עשה למקשים
        private void YesBtn_Click(object sender, RoutedEventArgs e)
        {
            if (GoLeftBx.Text != string.Empty && GoRightBx.Text != string.Empty && JumpBx.Text != string.Empty && SlashBx.Text != string.Empty) {
                Keys.Leftkey = (VirtualKey)Enum.Parse(typeof(VirtualKey), GoLeftBx.Text, true);
                Keys.Rightkey = Keys.Leftkey = (VirtualKey)Enum.Parse(typeof(VirtualKey), GoRightBx.Text, true);
                Keys.Upkey = (VirtualKey)Enum.Parse(typeof(VirtualKey), JumpBx.Text, true);
                Keys.Slash = (VirtualKey)Enum.Parse(typeof(VirtualKey), SlashBx.Text, true);
            }
        }
    }
}

