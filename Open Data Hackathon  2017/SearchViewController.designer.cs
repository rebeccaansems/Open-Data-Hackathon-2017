﻿// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace Open_Data_Hackathon__2017
{
    [Register ("SearchViewController")]
    partial class SearchViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton b_SearchButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton b_SearchCurrentLocation { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        Open_Data_Hackathon__2017.MapViews m_SearchMap { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        Open_Data_Hackathon__2017.UITextFields t_SearchCity { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        Open_Data_Hackathon__2017.UINavBar t_SearchNavBar { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        Open_Data_Hackathon__2017.UINavigationItems t_SearchNavBarText { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        Open_Data_Hackathon__2017.UIViews v_SearchScreen { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        Open_Data_Hackathon__2017.UITableViews v_SearchTableView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (b_SearchButton != null) {
                b_SearchButton.Dispose ();
                b_SearchButton = null;
            }

            if (b_SearchCurrentLocation != null) {
                b_SearchCurrentLocation.Dispose ();
                b_SearchCurrentLocation = null;
            }

            if (m_SearchMap != null) {
                m_SearchMap.Dispose ();
                m_SearchMap = null;
            }

            if (t_SearchCity != null) {
                t_SearchCity.Dispose ();
                t_SearchCity = null;
            }

            if (t_SearchNavBar != null) {
                t_SearchNavBar.Dispose ();
                t_SearchNavBar = null;
            }

            if (t_SearchNavBarText != null) {
                t_SearchNavBarText.Dispose ();
                t_SearchNavBarText = null;
            }

            if (v_SearchScreen != null) {
                v_SearchScreen.Dispose ();
                v_SearchScreen = null;
            }

            if (v_SearchTableView != null) {
                v_SearchTableView.Dispose ();
                v_SearchTableView = null;
            }
        }
    }
}