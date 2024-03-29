using App.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using App.MyFile;
using Windows.Devices.Enumeration;
using static App.File;
using System.Collections.Immutable;

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace App.MyFile
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MyFolder : Page
    {
        private ObservableCollection<FCB> FCBs;
        private NavigationHelper navigationHelper;
        private Frame parentFrame;

        

        public MyFolder()
        {
            this.InitializeComponent();
            FCBs = new ObservableCollection<FCB>();
            navigationHelper = new NavigationHelper(Frame);
            this.Loaded += MyFolder_Loaded;
        }

        private void MyFolder_Loaded(object sender, RoutedEventArgs e)
        {
            if (this.Frame != null)
            {
                // 尝试获取传递的Frame参数
                parentFrame = this.Frame.Tag as Frame;
            }
        }


        //创建文件夹
        private async void create_Click(object sender, RoutedEventArgs e)
        {

            FCB fcb = new FCB();
            Input inputDialog = new Input();

            fcb.status = 0;
            fcb.coverImage = "ms-appx:///Assets/file2.png";
            fcb.Parent = App.Cfcb;

            // 显示对话框
            ContentDialogResult result = await inputDialog.ShowAsync();

            // 获取并处理用户输入的文本
            string inputText = inputDialog.InputText;
            if (result == ContentDialogResult.Primary)
            {
                bool exist1 = App.Cfcb.MyFcbs.Any(item => item.Name == inputText);
                bool exist2 = false;
                foreach (var item in App.Cfcb.MyFcbs)
                {
                    if (item.Name == inputText)
                    {
                        if (item.status == fcb.status)
                        {
                            exist2 = true;
                        }
                    }
                }
                bool exists = exist1 && exist2;
                if (exists)
                {
                    var dialog = new Windows.UI.Popups.MessageDialog("姓名已存在，请重新输入");
                    await dialog.ShowAsync();
                }
                else
                {
                    fcb.Name = inputText;
                   // FCBs.Add(fcb);
                    App.Cfcb.MyFcbs.Add(fcb);
                }
            }


            App.Cfcb.Fsort();


        }


        //创建文件
        private async void initatite_Click(object sender, RoutedEventArgs e)
        {

            FCB fcb = new FCB();
            Input inputDialog = new Input();

            fcb.status = 1;
            fcb.coverImage = "ms-appx:///Assets/file1.png";
            fcb.Parent = App.Cfcb;

            // 显示对话框
            ContentDialogResult result = await inputDialog.ShowAsync();

            // 获取并处理用户输入的文本
            string inputText = inputDialog.InputText;

            if (result == ContentDialogResult.Primary)
            {
                bool exist1 = App.Cfcb.MyFcbs.Any(item => item.Name == inputText);
                bool exist2 = false;
                foreach (var item in App.Cfcb.MyFcbs)
                {
                    if (item.Name == inputText)
                    {
                        if (item.status == fcb.status)
                        {
                            exist2 = true;
                        }
                    }
                }
                bool exists = exist1 && exist2;
                if (exists)
                {
                    var dialog = new Windows.UI.Popups.MessageDialog("姓名已存在，请重新输入");
                    await dialog.ShowAsync();
                }
                else
                {
                    fcb.Name = inputText;
                    //FCBs.Add(fcb);
                    App.Cfcb.MyFcbs.Add(fcb);
                }
            }


            App.Cfcb.Fsort();
        }


        //重命名
        private async void rename_Click(object sender, RoutedEventArgs e)
        {
            var selectedItems = nList.SelectedItems.ToList();

            foreach (var selectedItem in selectedItems)
            {
                FCB fcb = selectedItem as FCB;
                if (fcb != null)
                {
                    Input inputDialog = new Input();
                    ContentDialogResult result = await inputDialog.ShowAsync();
                    string inputText = inputDialog.InputText;
                    if (result == ContentDialogResult.Primary)
                    {
                        //判断是否有同名
                        bool exist1 = App.Cfcb.MyFcbs.Any(item => item.Name == inputText);
                        //判断文件类型是否相同
                        bool exist2 = false;
                        foreach (var item in App.Cfcb.MyFcbs)
                        {
                            if(item.Name==inputText)
                            {
                                if(item.status == fcb.status)
                                {
                                    exist2 = true;
                                }
                            }
                        }
                        bool exists = exist1 && exist2;
                        if (exists)
                        {
                            var dialog = new Windows.UI.Popups.MessageDialog("姓名已存在，请重新输入");
                            await dialog.ShowAsync();
                        }
                        else
                        {
                            fcb.Name = inputText;

                            // 更新 UI 中对应项的显示文本
                            //var index1 = FCBs.IndexOf(fcb);
                            //FCBs[index1] = fcb;

                            var index2 = App.Cfcb.MyFcbs.IndexOf(fcb);
                            App.Cfcb.MyFcbs[index2] = fcb;
                        }

                    }
                }
            }
        }

        //删除
        private void delete_Click(object sender, RoutedEventArgs e)
        {
            var selectedItems = nList.SelectedItems.ToList();
            List<FCB> itemsToRemove = new List<FCB>();

            foreach (var item in selectedItems)
            {
                FCB fcb = item as FCB;
                if (fcb != null)
                {
                    itemsToRemove.Add(fcb);
                }
            }

            foreach (var itemToRemove in itemsToRemove)
            {
                //FCBs.Remove(itemToRemove);
                App.Cfcb.MyFcbs.Remove(itemToRemove);
            }
        }

        //打开文件/文件夹
        private void nList_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            FCB selectedFCB = (e.OriginalSource as FrameworkElement)?.DataContext as FCB;
            if (selectedFCB != null)
            {
                foreach (var item in App.Cfcb.MyFcbs)
                {
                    if(item.Name==selectedFCB.Name)
                    {
                        App.Cfcb=item;
                    }
                }

                if (selectedFCB.status == 0)
                {
                    parentFrame?.Navigate(typeof(MyFolder));
                }
                else
                {
                    parentFrame?.Navigate(typeof(text));
                }
            }
        }

        //Frame导航
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if(App.Cfcb.MyFcbs != null)
            {
                FCBs = App.Cfcb.MyFcbs;
            }
        }

    }
}
