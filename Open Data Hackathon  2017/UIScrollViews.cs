using Foundation;
using System;
using UIKit;
using Xamarin.Forms;

namespace Open_Data_Hackathon__2017
{
    public partial class UIScrollViews : UIScrollView
    {
        public UIScrollViews (IntPtr handle) : base (handle)
        {
            var stack = new StackLayout();

            for (int i = 0; i < 100; i++)
            {
                stack.Children.Add(new Button { Text = "Button " + i });
            }
            
        }
    }
}