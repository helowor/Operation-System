using App.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography;
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
    public sealed partial class Deadlock : Page
    {
        List<PCB> pPCBs1= new List<PCB>();
        List<PCB> pPCBs2=new List<PCB>();
        List<PCB> pPCBs3 = new List<PCB>();

        int resource1 = -1;
        int resource2 = -1;
        int resource3 = -1;

        public Deadlock()
        {
            this.InitializeComponent();
        }

        private void MyAdd_Click(object sender, RoutedEventArgs e)
        {
            int x = 0;
            int y = 0;
            int z = 0;

            if (int.TryParse(Text1.Text, out x) && int.TryParse(Text2.Text, out y) && int.TryParse(Text3.Text, out z))
            {
                resource1 = x; 
                resource2 = y; 
                resource3 = z;

                result.Items.Add("资源1空闲数量：" + resource1 + "；资源2空闲数量：" + resource2 + "；资源3空闲数量：" + resource3);

            }
        }

        private void MyRun_Click(object sender, RoutedEventArgs e)
        {
            result.Items.Clear();

            list1.Items.Clear();
            list2.Items.Clear();    
            list3.Items.Clear();

            Random random = new Random();
            for (int i = 0; i < 5; i++)
            {
                int x1 = 0;
                int y1 = 0;
                int z1 = 0;

                for (int j = 0; j < 3; j++)
                {
                    x1 = random.Next(10);
                    y1 = random.Next(10);
                    z1 = random.Next(10);
                }

                PCB pCB1 = new PCB();
                PCB pCB2 = new PCB();
                PCB pCB3 = new PCB();

                pCB1.resource1= x1; 
                pCB1.resource2= y1; 
                pCB1.resource3= z1;
                pCB1.Pid = i.ToString();

                list1.Items.Add("进程 "+i+": 资源1: "+ pCB1.resource1 + "; 资源2: " + pCB1.resource2 + "; 资源3: " + pCB1.resource3);

                pPCBs1.Add(pCB1);

                int x2 = 0;
                int y2 = 0;
                int z2 = 0;

                for (int j = 0; j < 3; j++)
                {
                    x2 = random.Next(pCB1.resource1);
                    y2 = random.Next(pCB1.resource2);
                    z2 = random.Next(pCB1.resource3);
                }

                pCB2.resource1 = x2;
                pCB2.resource2 = y2;
                pCB2.resource3 = z2;
                pCB2.Pid = i.ToString();

                list2.Items.Add("进程 " + i + ": 资源1: " + pCB2.resource1 + "; 资源2: " + pCB2.resource2 + "; 资源3: " + pCB2.resource3);

                pPCBs2.Add(pCB2);

                //list3.Items.Add("进程 " + i + ": 资源1: " + (x1-x2)
                  //  + "; 资源2: " + (y1 - y2)
                    //+ "; 资源3: " + (z1 - z2));

                pCB3.resource1 = x1 - x2;
                pCB3.resource2 = y1 - y2;
                pCB3.resource3 = z1 - z2;
                pCB3.Pid = i.ToString();

                list3.Items.Add("进程 " + i + ": 资源1: " + pCB3.resource1 + "; 资源2: " + pCB3.resource2 + "; 资源3: " + pCB3.resource3);

                pPCBs3.Add(pCB3);
            }
        }

        private void MyDebug_Click(object sender, RoutedEventArgs e)
        {
            if(resource1!=-1&& resource2 != -1&& resource3 != -1)
            {

                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < pPCBs3.Count; j++)
                    {
                        if(resource1 >= pPCBs3[j].resource1 && resource2 >= pPCBs3[j].resource2 && resource3 >= pPCBs3[j].resource3)
                        {
                            resource1 = resource1 + pPCBs2[j].resource1;
                            resource2 = resource2 + pPCBs2[j].resource2;
                            resource3 = resource3 + pPCBs2[j].resource3;

                            result.Items.Add("进程"+ pPCBs3[j].Pid + "所需资源得到满足\n"+
                                "资源1空闲数量：" + resource1 + "；资源2空闲数量：" + resource2 + "；资源3空闲数量：" + resource3
                                +"\n");

                            pPCBs1.Remove(pPCBs1[j]);
                            pPCBs2.Remove(pPCBs2[j]);
                            pPCBs3.Remove(pPCBs3[j]);

                            break;
                        }
                    }
                }

                if(pPCBs3.Count!=0)
                {
                    result.Items.Clear();
                    result.Items.Add("系统处于不安全状态");
                }
            }
        }
    }
}
