using App.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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
    public sealed partial class Memory : Page
    {

        List<int> ints = new List<int>();
        public Memory()
        {
            this.InitializeComponent();
        }

        private void Born_Click(object sender, RoutedEventArgs e)
        {
            ints.Clear();

             Random random = new Random();
            
            for (int i = 0; i < 10; i++)
            {
                ints.Add(random.Next(10));
            }

            string output = string.Join(", ", ints);

            Tresult.Text = output;

            result.Items.Clear();

            result.Items.Add("生成的随机序列为："+output);

        }

        private void MyRun_Click(object sender, RoutedEventArgs e)
        {
            List<PB> pBs = new List<PB>();

            pBs.Add(new PB());
            pBs.Add(new PB());
            pBs.Add(new PB());

            foreach (var item in ints)
            {
                int dex=-1;

                bool b = false; 

                foreach (var item1 in pBs)
                {
                    dex++;
                    if (item1.Context == -1 || item1.Context == item)
                    {
                        b = true;
                        break;
                    }
                }

                if (b)
                {
                    pBs[dex].Context = item;
                    if (dex == 0)
                    {
                        pBs[0].Wtime = 0;
                        pBs[1].Wtime += 1;
                        pBs[2].Wtime += 1;
                    }
                    else if (dex == 1)
                    {
                        pBs[0].Wtime += 1;
                        pBs[1].Wtime = 0;
                        pBs[2].Wtime += 1;
                    }
                    else
                    {
                        pBs[2].Wtime = 0;
                        pBs[1].Wtime += 1;
                        pBs[0].Wtime += 1;
                    }
                    result.Items.Add("在第" + (dex + 1) + "块物理块访问入" + item + "号页;\n" +
                        "1号等待时间：" + pBs[0].Wtime + "\n" +
                        "2号等待时间：" + pBs[1].Wtime + "\n" +
                        "3号等待时间：" + pBs[2].Wtime);
                }
                else
                {
                    int index = 0;
                    if (pBs[0].Wtime >= pBs[1].Wtime && pBs[0].Wtime >= pBs[2].Wtime)
                    {
                        index = 0;
                    }
                    else if(pBs[1].Wtime > pBs[0].Wtime && pBs[1].Wtime >= pBs[2].Wtime)
                    {
                        index = 1;
                    }
                    else if(pBs[2].Wtime > pBs[1].Wtime && pBs[2].Wtime > pBs[0].Wtime)
                    {
                        index = 2;
                    }

                    pBs[index].Context = item;
                    if (index == 0)
                    {
                        pBs[0].Wtime = 0;
                        pBs[1].Wtime += 1;
                        pBs[2].Wtime += 1;
                    }
                    else if (index == 1)
                    {
                        pBs[0].Wtime += 1;
                        pBs[1].Wtime = 0;
                        pBs[2].Wtime += 1;
                    }
                    else
                    {
                        pBs[2].Wtime = 0;
                        pBs[1].Wtime += 1;
                        pBs[0].Wtime += 1;
                    }
                    result.Items.Add("在第" + (index + 1) + "块物理块访问入" + item + "号页;\n" +
                        "1号等待时间：" + pBs[0].Wtime + "\n" +
                        "2号等待时间：" + pBs[1].Wtime + "\n" +
                        "3号等待时间：" + pBs[2].Wtime);
                }
            }
        }
    }
}
