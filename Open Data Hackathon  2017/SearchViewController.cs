using Foundation;
using System;
using System.IO;
using System.Collections.Generic;
using System.CodeDom.Compiler;
using UIKit;
using SQLite;
using CoreGraphics;

namespace Open_Data_Hackathon__2017
{
    public partial class SearchViewController : UIViewController
    {
        public SearchViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            b_SearchButton.TouchUpInside += SearchButtonPressed;
        }

        void SearchButtonPressed(object sender, EventArgs e)
        {
            t_SearchNavBarText.Title = t_SearchCity.Text;
        }
    }
}