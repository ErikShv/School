using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Traffic_Lights.Objects;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Traffic_Lights
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private Lights _myLights;
        public MainPage()
        {
            this.InitializeComponent();
        }


        /// <summary>
        /// הפעולה תתבצע באופן אוטומטי כאשר הדף ייפתח
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            _myLights = new Lights(elpRed, elpGreen, elpYellow);//כך בונים רמזור

        }

        private void btnManual_Click(object sender, RoutedEventArgs e)
        {
            _myLights.SetState();
        }

        private void btnAuto_Click(object sender, RoutedEventArgs e)
        {
            _myLights.IsAuto = !_myLights.IsAuto;
            btnAuto.Content = _myLights.IsAuto ? "Stop": "Auto";
            btnManual.IsEnabled = !_myLights.IsAuto;
        }
    }
}
