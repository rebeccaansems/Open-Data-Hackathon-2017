// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace Open_Data_Hackathon__2017
{
    [Register ("SecondViewController")]
    partial class SecondViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UINavigationBar u_OptionsNavigationBar { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView v_OptionsView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (u_OptionsNavigationBar != null) {
                u_OptionsNavigationBar.Dispose ();
                u_OptionsNavigationBar = null;
            }

            if (v_OptionsView != null) {
                v_OptionsView.Dispose ();
                v_OptionsView = null;
            }
        }
    }
}