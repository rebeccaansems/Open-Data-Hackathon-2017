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
    [Register ("FirstViewController")]
    partial class FirstViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel l_EnterLocation { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        MapKit.MKMapView m_MainScreenMap { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField t_SearchLocation { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UINavigationBar u_MainNavigationBar { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView v_MainView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (l_EnterLocation != null) {
                l_EnterLocation.Dispose ();
                l_EnterLocation = null;
            }

            if (m_MainScreenMap != null) {
                m_MainScreenMap.Dispose ();
                m_MainScreenMap = null;
            }

            if (t_SearchLocation != null) {
                t_SearchLocation.Dispose ();
                t_SearchLocation = null;
            }

            if (u_MainNavigationBar != null) {
                u_MainNavigationBar.Dispose ();
                u_MainNavigationBar = null;
            }

            if (v_MainView != null) {
                v_MainView.Dispose ();
                v_MainView = null;
            }
        }
    }
}