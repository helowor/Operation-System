using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace App.MyProcess
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class Cogradient : Page
    {
        private bool isRunning = true;
        public Cogradient()
        {
            this.InitializeComponent();
        }

        private void Myrun_Click(object sender, RoutedEventArgs e)
        {
            // 缓冲区大小
            const int bufferSize = 5;

            // 使用 BlockingCollection 作为缓冲区
            BlockingCollection<int> buffer = new BlockingCollection<int>(bufferSize);

            async Task Producer()
            {
                while (isRunning)
                {
                    await Task.Delay(1000); // 模拟生产延迟

                    int item = GenerateItem();

                    await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                    {
                        Result.Items.Add($"生产者生产物品: {item}");
                    });

                    buffer.Add(item);
                }
            }

            // 消费者方法
            async Task Consumer()
            {
                while (isRunning)
                {
                    int item = buffer.Take();

                    await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                    {
                        Result.Items.Add($"消费者消费物品: {item}");
                    });

                    // 模拟消费延迟
                    await Task.Delay(2000);
                }
            }

            // 生成物品的方法
            int GenerateItem()
            {
                return new Random().Next(100);
            }

            // 启动生产者和消费者任务
            Task.Run(() => Producer());
            Task.Run(() => Consumer());
        }

        private void Mystop_Click(object sender, RoutedEventArgs e)
        {
            isRunning = false;
        }
    }
}
