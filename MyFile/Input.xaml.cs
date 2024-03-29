using Windows.UI.Xaml.Controls;


// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace App.MyFile
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class Input : ContentDialog
    {
        public string InputText { get; private set; }
        public Input()
        {
            this.InitializeComponent();
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            // 确认按钮被点击
            InputText = InputTextBox.Text;
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            // 取消按钮被点击，不需要做任何特别处理
        }
    }
}
