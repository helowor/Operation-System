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

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace App
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            MyFrame.Navigate(typeof(File));
        }

        private void Hambergurger_Click(object sender, RoutedEventArgs e)
        {
            split.IsPaneOpen = !split.IsPaneOpen;
        }

        private void list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Process.IsSelected)
            {
                MyFrame.Navigate(typeof(Process));
                Title.Text = "进程管理";
            }
            else if (Memory.IsSelected)
            {
                MyFrame.Navigate(typeof(Memory));
                Title.Text = "内存管理";
            }
            else if (File.IsSelected)
            {
                MyFrame.Navigate(typeof(File));
                Title.Text = "文件管理";
            }
            else if (Device.IsSelected)
            {
                MyFrame.Navigate(typeof(Device));
                Title.Text = "设备管理";
            }
        }
    }
}
