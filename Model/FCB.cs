using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Model
{
    public class FCB
    {
        //自己的名字
        public string Name { get; set; }

        //父目录
        public FCB Parent { get; set; }
        public int status { get; set; } = 0;
        public string coverImage {  get; set; }
        public ObservableCollection<FCB> MyFcbs { get; set; }

        public string head {  get; set; }

        public string context {  get; set; }

        public void Fsort()
        {
            int n = MyFcbs.Count;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (MyFcbs[j].status > MyFcbs[j + 1].status)
                    {
                        // 交换 array[j] 和 array[j + 1] 的位置
                        FCB temp = MyFcbs[j];
                        MyFcbs[j] = MyFcbs[j + 1];
                        MyFcbs[j + 1] = temp;
                    }
                }
            }
        }




        public FCB()
        {
            MyFcbs = new ObservableCollection<FCB>();
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
