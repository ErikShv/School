using DatabaseProject;
using Path_To_Glory.GameServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.ServiceModel.Channels;
using System.Text.RegularExpressions;
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
    public sealed partial class SignUp : Page
    {
        public SignUp()
        {
            this.InitializeComponent();
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

        private async void ContinueBtn_Click(object sender, RoutedEventArgs e)
        {
            if (UsernameSignUp.Text == "" || PasswordSignUp.Password == "" || RePasswordSignUp.Password == "" || EmailSignUp.Text == "")
            {
                await new MessageDialog("Data is Missing!", "Path To Glory").ShowAsync();
            }
            else if (PasswordSignUp.Password != RePasswordSignUp.Password)
            {
                await new MessageDialog("Passwords Arent Matching!", "Path To Glory").ShowAsync();
            }
            else if (!IsValidGmail(EmailSignUp.Text.Trim()))
            {
                await new MessageDialog("Mail Isnt Valid!", "Path To Glory").ShowAsync();
            }
            else
            {
                int? userId = Server.ValidateUser(UsernameSignUp.Text.Trim(), PasswordSignUp.Password.Trim());
                if (userId == null)
                {
                    GameManager.GameUser = Server.AddNewUser(UsernameSignUp.Text.Trim(), PasswordSignUp.Password.Trim(), EmailSignUp.Text.Trim());
                    await new MessageDialog("User Added Succesfully!", "Path To Glory").ShowAsync();
                    Frame.Navigate(typeof(MenuPage));
                }
                else
                {
                    await new MessageDialog("This User Already Exists", "Path To Glory").ShowAsync();
                }
            }
            
        }
        public static bool IsValidGmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            // Regular expression to validate Gmail addresses
            string pattern = @"^[a-zA-Z0-9._%+-]+@gmail\.com$";
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);

            return regex.IsMatch(email);
        }
    }
}
