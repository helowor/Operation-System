﻿#pragma checksum "D:\乱七八糟的东西\代码\操作系统模拟\App\MyProcess\Cogradient.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "E2E57F3A02168F2930239FEE6868518FEE603D3A6E382411A3923A61897DBC19"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace App.MyProcess
{
    partial class Cogradient : 
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
            case 2: // MyProcess\Cogradient.xaml line 20
                {
                    this.operation = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 3: // MyProcess\Cogradient.xaml line 21
                {
                    this.name = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 4: // MyProcess\Cogradient.xaml line 26
                {
                    this.Result = (global::Windows.UI.Xaml.Controls.ListBox)(target);
                }
                break;
            case 5: // MyProcess\Cogradient.xaml line 23
                {
                    this.Mystop = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.Mystop).Click += this.Mystop_Click;
                }
                break;
            case 6: // MyProcess\Cogradient.xaml line 24
                {
                    this.Myrun = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.Myrun).Click += this.Myrun_Click;
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

