using App.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
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

namespace App.MyProcess
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class Attemper : Page
    {
        private ObservableCollection<PCB> PCBs1;
        private ObservableCollection<PCB> PCBs2;
        private ObservableCollection<PCB> PCBs3;
        private ObservableCollection<PCB> PCBs4;
        public Attemper()
        {
            this.InitializeComponent();
            PCBs1 = new ObservableCollection<PCB>();
            PCBs2 = new ObservableCollection<PCB>();
            PCBs3 = new ObservableCollection<PCB>();
            PCBs4 = new ObservableCollection<PCB>();
        }

        private async void Myadd_Click(object sender, RoutedEventArgs e)
        {
            PCB pCB = new PCB();
            int parsedTime;
            if (!string.IsNullOrEmpty(pname.Text) && !string.IsNullOrEmpty(pid.Text) && int.TryParse(time.Text, out parsedTime))
            {
                bool exist1 = PCBs1.Any(item => item.Pname == pname.Text);
                bool exist2 = PCBs1.Any(item => item.Pid == pid.Text);
                if (exist1 || exist2)
                {
                    var dialog = new Windows.UI.Popups.MessageDialog("名称或编号已存在，请重新输入");
                    await dialog.ShowAsync();
                }
                else
                {
                    pCB.Pname = pname.Text;
                    pCB.Pid = pid.Text;
                    pCB.Time = parsedTime;
                    PCBs1.Add(pCB);
                     result.Items.Add(pCB.Pname + "创建成功");
                }
            }
            pname.Text = "";
            pid.Text = "";
            time.Text = "";
        }

        private async void Myrun_Click(object sender, RoutedEventArgs e)
        {
            
            bool miu = true;

            int parsedMypri;
            int pri = 0;

            if ( int.TryParse(Mypri.Text, out parsedMypri))
            {
                Myadd.IsEnabled = false;
                Myrun.IsEnabled = false;
                PCBs2.Clear();
                pri = parsedMypri;
                int cnt = PCBs1.Count;
                PCB s = new PCB();

                for (int i = 0; i < cnt; i++)
                {
                    if (miu)
                    {
                        s = PCBs1[0];
                        PCBs1.Remove(s);
                        PCBs2.Add(s);
                        miu = false;
                        result.Items.Add(s.Pname + "需" + s.Time + "个时间片");
                    }

                    for (int j = 0; j < pri; j++)
                    {
                        if (s.Time != 0)
                        {
                            PCBs2[0] = s;
                            await Task.Delay(TimeSpan.FromSeconds(1));
                            s.Time -= 1;
                            result.Items.Add(s.Pname + "还需" + s.Time + "个时间片");
                        }
                        miu = true;
                    }

                    if (s.Time != 0)
                    {
                        PCBs2.Remove(s);
                        PCBs1.Add(s);
                        await Task.Delay(TimeSpan.FromSeconds(5));
                        i--;
                    }
                    else if (s.Time == 0)
                    {
                        result.Items.Add(s.Pname + "运行结束");
                        PCBs2.Remove(s);
                        PCBs4.Add(s);
                    }

                }
            }


            Mypri.Text = null;
        }
    }
}
