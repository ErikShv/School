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
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Calculator
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private char _operation = '@';
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void _btneql_Click(object sender, RoutedEventArgs e)
        {
            double num1, num2, answer =0;
            num1 = double.Parse(_Num.Text);//כך מתרגמים את המספר שהוזן כמחרוזת לממש מספר 
            num2 = double.Parse(_Num2.Text);
            switch (_operation)
            {
                case '+': answer = num1 + num2;
                    break;
                case '-':
                    answer = num1 - num2;
                    break;
                case '*':
                    answer = num1 * num2;
                    break;
                case '/':
                    answer = num1 / num2;
                    break;
            }
            _Output.Text = answer.ToString();
        }
        
        //הפעולה המשותפת לכל הלחצנים של הספרות
        private void btn_Click(object sender, RoutedEventArgs e)
        {
            var chooseButton = (Button)sender; // כך מגלים מהו הלחצן שגרם לפעולה לקרות
            int digit =int.Parse( chooseButton.Name[chooseButton.Name.Length - 1].ToString());
            if(_operation == '@'){    //עדיין מקלידים את המספר הראשון
                _Num.Text += digit.ToString();
            }
            else
            {
                _Num2.Text += digit.ToString();
            }
        }

        private void _devide_Click(object sender, RoutedEventArgs e)
        {
            _Operator.Text = "/";
            _operation = '/';
        }

        private void _times_Click(object sender, RoutedEventArgs e)
        {
            _Operator.Text = "*";
            _operation = '*';
        }

        private void _minus_Click(object sender, RoutedEventArgs e)
        {
            _Operator.Text = "-";
            _operation = '-';
        }

        private void _plus_Click(object sender, RoutedEventArgs e)
        {
            _Operator.Text = "+"; //כך הפעולה תופיע על המסך
            _operation = '+'; //במקום @ מכניסים אופרטור
        }

        private void _del_Click(object sender, RoutedEventArgs e)
        {
            _Num.Text = "";
            _Num2.Text = "";
            _Operator.Text = "";
            _Output.Text = "";
            _operation = '@';
        }

        private void _backspace_Click(object sender, RoutedEventArgs e)
        {
            
            if (_Num.Text != "")
            {
                if(_Operator.Text != "")
                {
                    if(_Num2.Text != "")
                    {
                        
                    }
                }
            }
        }
    }
}
