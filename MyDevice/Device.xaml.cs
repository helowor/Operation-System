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

namespace App
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class Device : Page
    {
        List<int> ints = new List<int>();
        public Device()
        {
            this.InitializeComponent();
        }

        private void Born_Click(object sender, RoutedEventArgs e)
        {
            ints.Clear();

            Random random = new Random();

            for (int i = 0; i < 15; i++)
            {
                int r = random.Next(100);
                while (ints.Contains(r))
                {
                    r = random.Next(100);
                }
                ints.Add(r);
            }

            string output = string.Join(", ", ints);

            Tresult.Text = output;

            result.Items.Clear();

            result.Items.Add("生成的随机序列为：" + output);

        }

        private void MyRun_Click(object sender, RoutedEventArgs e)
        {
            int head = ints[0];
            ints.Sort();
            int index = 0;
            for(int i = 0;i < 15;i++)
            {
                if (ints[i] == head)
                {
                    index=i; break;
                }
            }

            for(int i = index;i < ints.Count;i++)
            {
                result.Items.Add("已到达第" + ints[i]+"号柱面\n"
                    + "寻道时间为：" + (ints[i] - ints[index]));
            }

            for(int i= 0;i < index;i++)
            {
                result.Items.Add("已到达第" + ints[i] + "号柱面\n"
                    + "寻道时间为：" + (ints[ints.Count-1]*2 - ints[index] + ints[i] ));
            }
        }
    }
}
