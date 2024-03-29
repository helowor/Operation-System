using App.Model;
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

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace App.MyFile
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class text : Page
    {
        public text()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
           if(App.Cfcb.head!=null&& App.Cfcb.context!=null) 
            {
                Head.Text = App.Cfcb.head;
                context.Text = App.Cfcb.context;
            }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            if (Head != null)
            {
                Head.Text = string.Empty;
            }
            if (context != null)
            {
                context.Text = string.Empty;
            }
            App.Cfcb.context = context.Text;
            App.Cfcb.head = Head.Text;

        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            App.Cfcb.context = context.Text;
            App.Cfcb.head = Head.Text;
        }
    }
}
