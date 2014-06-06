using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Decimal_Hexadecimal_Binary_Converter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private string[] allowedDec = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
        private string[] allowedHex = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "A", "B", "C", "D", "E", "F" };
        private string[] allowedBin = new string[] { "1", "0" };

        public MainWindow()
        {
            InitializeComponent();
        }

        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MinimizeWindow(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            UIFunctions.CenterObject(this);
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void decText_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (Array.IndexOf(allowedDec, e.Text) < 0 || decText.Text.Length >= 18)
            {
                e.Handled = true;
            }
        }

        private void hexText_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (Array.IndexOf(allowedHex, e.Text.ToUpper()) < 0 || decText.Text.Length >= 18)
            {
                e.Handled = true;
            }
        }

        private void binText_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (Array.IndexOf(allowedBin, e.Text) < 0 || decText.Text.Length >= 18)
            {
                e.Handled = true;
            }
        }

        private void decText_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (decText.IsFocused)
            {
                if (!decText.Text.Equals(""))
                {
                    if (long.Parse(decText.Text) <= long.MaxValue)
                    {
                        long num = long.Parse(decText.Text);
                        hexText.Text = num.ToString("X");
                        binText.Text = Convert.ToString(num, 2);
                    }
                }
                else
                {
                    hexText.Text = "";
                    binText.Text = "";
                }
            }
        }

        private void hexText_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (hexText.IsFocused)
            {
                if (!hexText.Text.Equals(""))
                {
                    if (Convert.ToInt64(hexText.Text, 16) <= long.MaxValue)
                    {
                        long num = Convert.ToInt64(hexText.Text, 16);
                        decText.Text = num.ToString();
                        binText.Text = Convert.ToString(num, 2);
                    }
                }
                else
                {
                    decText.Text = "";
                    binText.Text = "";
                }
            }
        }

        private void binText_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (binText.IsFocused)
            {
                if (!binText.Text.Equals(""))
                {
                    if (Convert.ToInt64(binText.Text, 2) <= long.MaxValue)
                    {
                        long num = Convert.ToInt64(binText.Text, 2);
                        decText.Text = num.ToString();
                        hexText.Text = num.ToString("X");
                    }
                }
                else
                {
                    decText.Text = "";
                    hexText.Text = "";
                }
            }
        }
    }
}
