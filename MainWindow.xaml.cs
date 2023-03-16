using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Table_tennis
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        bool isWiden = false;
        bool isFullScreen = false;
        private void window_initiateWiden(object sender, System.Windows.Input.MouseEventArgs e)
        {
            isWiden = true;
        }

        private void window_endWiden(object sender, System.Windows.Input.MouseEventArgs e)
        {
            isWiden = false;

            // Make sure capture is released.
            Rectangle rect = (Rectangle)sender;
            rect.ReleaseMouseCapture();
        }

        private void window_Widen(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Rectangle rect = (Rectangle)sender;
            if (isWiden)
            {
                rect.CaptureMouse();
                double newWidth = e.GetPosition(this).X + 0;
                if (newWidth > 0) this.Width = newWidth;
            }
        }

        bool isElevate = false;
        private void window_initiateElevate(object sender, System.Windows.Input.MouseEventArgs e)
        {
            isElevate = true;
        }

        private void window_endElevate(object sender, System.Windows.Input.MouseEventArgs e)
        {
            isElevate = false;

            // Make sure capture is released.
            Rectangle rect = (Rectangle)sender;
            rect.ReleaseMouseCapture();
        }

        private void window_Elevate(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Rectangle rect = (Rectangle)sender;
            if (isElevate)
            {
                rect.CaptureMouse();
                double newHeight = e.GetPosition(this).Y + 0;
                if (newHeight > 0) this.Height = newHeight;
            }
        }

        private void titleBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) //Перемещение по экрану /**/
        {
            this.DragMove();
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void FullScreen_Click(object sender, RoutedEventArgs e)
        {
            if (isFullScreen)
            {
                this.Width = 1920;
                this.Height = 1080;
                isFullScreen = false;
                this.Top = 100;
                this.Left = 300;
            }
            else
            {
                this.Width = System.Windows.SystemParameters.PrimaryScreenWidth - 5;
                this.Height = System.Windows.SystemParameters.PrimaryScreenHeight - 45;
                isFullScreen = true;
                this.Top = 1;
                this.Left = 1;
            }
        }

        private void Wrap_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
    }
}

