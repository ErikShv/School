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
        bool flag = true;
        bool flag2 = true;
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void _btneql_Click(object sender, RoutedEventArgs e)
        {
            
            double num1, num2, answer =0;
            string msg = "";
            if (_Num.Text == "" || _Num2.Text == "" || _Operator.Text == "" || _Num.Text.IndexOf('.') != _Num2.Text.LastIndexOf('.'))
            {
                msg = "Error";
                num1 = 0;
                num2 = 0;
                _operation = '+';
            }
            else
            {
                num1 = double.Parse(_Num.Text);//כך מתרגמים את המספר שהוזן כמחרוזת לממש מספר 
                num2 = double.Parse(_Num2.Text);
            }
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
                    if (num2 != 0)
                    {
                        answer = num1 / num2;
                    }
                    else
                    {
                        msg = "Error";
                    }
                    break;
            }
            
            
            if (msg == "")
            {
                _Output.Text = answer.ToString();
            }
            else
            {
                _Output.Text = msg;
            }
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

            
            if(_operation == '@')
            {
                string back = _Num.Text.Remove(_Num.Text.Length - 1);
                _Num.Text = back;
            }
            if(_Num2.Text != "")
            {
                string back2 = _Num2.Text.Substring(0, _Num2.Text.Length - 1);
                _Num2.Text = back2;
            }
            if (_operation != '@' && _Num2.Text == "")
            {
                _operation = '@';
                _Operator.Text = "";
            }
        }

        private void _ans_Click(object sender, RoutedEventArgs e)
        {
             
            _Num.Text = _Output.Text;
            if (_Output.Text != "")
            {
                _Num2.Text = "";
                _Operator.Text = "";
            }

            
            _Output.Text = "";
            _operation = '@';
        }

        private void _dot_Click(object sender, RoutedEventArgs e)
        {
            if(_operation == '@')
            {
                if (flag == true)
                {
                    _Num.Text += '.';
                    flag = false;
                }
            }
            
            else
            {
                
                if (flag2 == true)
                {
                    _Num2.Text += '.';
                    flag2 = false;
                }
            }
        }
    }
}
