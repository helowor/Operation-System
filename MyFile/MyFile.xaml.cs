using App.MyFile;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using System.Collections.ObjectModel;
using App.Model;
using System;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace App
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    /// 
    public sealed partial class File : Page
    {
        private ObservableCollection<FCB> FCBs;
        private NavigationHelper navigationHelper;

        public class NavigationHelper
        {
            public Frame MainFrame { get; set; }

            public NavigationHelper(Frame mainFrame)
            {
                MainFrame = mainFrame;
            }

            public void NavigateToPage(Type pageType)
            {
                if (MainFrame != null)
                {
                    MainFrame.Navigate(pageType);
                }
            }
        }

        public File()
        {
            
            this.InitializeComponent();
          
            FCBs = new ObservableCollection<FCB>();
            MyFileFrame.Tag = MyFileFrame;
            MyFileFrame.Navigate(typeof(MyFolder),MyFileFrame);
            if (!MyFileFrame.CanGoBack)
            {
                back.IsEnabled = false;
            }
            navigationHelper = new NavigationHelper(MyFileFrame);
            MyFileFrame.Navigated += MyFileFrame_Navigated;
        }

        private void MyFileFrame_Navigated(object sender, NavigationEventArgs e)
        {
            // 每次导航完成后，更新back按钮的启用状态
            back.IsEnabled = MyFileFrame.CanGoBack;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            navigationHelper.MainFrame = MyFileFrame;
        }


        //返回
        private void back_Click(object sender, RoutedEventArgs e)
        {
            App.Cfcb = App.Cfcb.Parent;
            MyFileFrame.GoBack();
        }

        
    }
}
