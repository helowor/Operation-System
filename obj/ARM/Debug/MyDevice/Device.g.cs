﻿#pragma checksum "D:\乱七八糟的东西\代码\操作系统模拟\App\MyDevice\Device.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "B689B9E1E259AACE5C7FCA6E9CCBF8BE5221931086D2D4FE9E378AC69715E7E2"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace App
{
    partial class Device : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 0.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // MyDevice\Device.xaml line 21
                {
                    this.result = (global::Windows.UI.Xaml.Controls.ListBox)(target);
                }
                break;
            case 3: // MyDevice\Device.xaml line 26
                {
                    this.Born = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.Born).Click += this.Born_Click;
                }
                break;
            case 4: // MyDevice\Device.xaml line 27
                {
                    this.MyRun = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.MyRun).Click += this.MyRun_Click;
                }
                break;
            case 5: // MyDevice\Device.xaml line 24
                {
                    this.Tresult = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 0.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}
