
namespace WarehouseSystem
{
    using System;
    using System.Windows;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    using System.Windows.Input;
    using System.Windows.Interop;
    using WarehouseSystem.Store;
    using WarehouseSystem.Engine;

    public partial class MainWindow : Window
    {
        public static DesktopStore InstanceStore = new DesktopStore();

        public MainWindow()
        {
            InitializeComponent();
            ProgramEngine renderer = new ProgramEngine(this);
            renderer.Run();
            //this.testasd.MouseLeftButtonDown += new MouseButtonEventHandler(move_window);
        }

        public void MoveWindow(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Close_App(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void Minimize_App(object sender, MouseButtonEventArgs e)
        {
            if (this.WindowState != WindowState.Minimized)
            {
                this.WindowState = WindowState.Minimized;
            }
        }

        private void Maximize_App(object sender, MouseButtonEventArgs e)
        {
            if (this.WindowState != WindowState.Maximized)
            {
                this.WindowState = WindowState.Maximized;
            }
            else
            {
                this.WindowState = WindowState.Normal;
            }
        }
    }
}
