using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RGR_abc_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Метод запускающий все елементы при клики
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            foreach (UIElement el in MainPanel.Children)
            {
                if (el is Button)
                {
                    ((Button)el).Click += Button_Click;
                }
            }
        }

        string value = "";

        /// <summary>
        /// Метод проходящий по кнопкам
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string str = (string)((Button)e.OriginalSource).Content;

            switch (str)
            {
                case "+":
                    value = methods.implementation(textcap.Text);
                    if (value == "Ошибка!")
                    {
                        textcap.Text = value;
                    }
                    else
                    {
                        textcap.Text = value + "+";
                    }
                    break;
                case "-":
                    value = methods.implementation(textcap.Text);
                    if (value == "Ошибка!")
                    {
                        textcap.Text = value;
                    }
                    else
                    {
                        textcap.Text = value + "-";
                    }
                    break;
                case "*":
                    value = methods.implementation(textcap.Text);
                    if (value == "Ошибка!")
                    {
                        textcap.Text = value;
                    }
                    else
                    {
                        textcap.Text = value + "*";
                    }
                    break;
                case "/":
                    value = methods.implementation(textcap.Text);
                    if (value == "Ошибка!")
                    {
                        textcap.Text = value;
                    }
                    else
                    {
                        textcap.Text = value + "/";
                    }
                    break;
                case "AC":
                    textcap.Text = "";
                    value = "";
                    break;
                case "=":
                    textcap.Text = methods.implementation(textcap.Text);
                    value = "";
                    break;
                default:
                    textcap.Text += str;
                    break;
            }
        }
    }
}
