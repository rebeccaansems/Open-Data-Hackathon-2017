using System;
using System.Collections.Generic;
using System.IO;
using Foundation;
using UIKit;

namespace Open_Data_Hackathon__2017
{
    public class TableSource : UITableViewSource
    {
        protected Store[] storeItems;
        protected string[] tableItems;
        protected string cellIdentifier = "TableCell";
        SearchViewController owner;

        public TableSource(string[] items, Store[] sItems, SearchViewController owner)
        {
            tableItems = items;
            storeItems = sItems;
            this.owner = owner;
        }

        /// <summary>
        /// Called by the TableView to determine how many cells to create for that particular section.
        /// </summary>
        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return tableItems.Length;
        }

        /// <summary>
        /// Called when a row is touched
        /// </summary>
        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            string message = "";

            if(storeItems[indexPath.Row].Phone != "")
            {
                message += "Phone: " + storeItems[indexPath.Row].Phone + "\n";
            }
            if (storeItems[indexPath.Row].Address != "")
            {
                message += "Address: " + storeItems[indexPath.Row].Address + "\n";
            }
            if (storeItems[indexPath.Row].Hours != "")
            {
                message += "Hours: " + storeItems[indexPath.Row].Hours + "\n";
            }
            if (storeItems[indexPath.Row].Website != "")
            {
                message += "Website: " + storeItems[indexPath.Row].Website;
            }

            UIAlertController okAlertController = UIAlertController.Create(storeItems[indexPath.Row].Producer,message, UIAlertControllerStyle.Alert);

            if (storeItems[indexPath.Row].Phone != "")
            {
                okAlertController.AddAction(UIAlertAction.Create("Call", UIAlertActionStyle.Default, CallStore));
            }
            if (storeItems[indexPath.Row].Address != "")
            {
                okAlertController.AddAction(UIAlertAction.Create("Directions", UIAlertActionStyle.Default, DirectionsToStore));
            }
            if (storeItems[indexPath.Row].Website != "")
            {
                okAlertController.AddAction(UIAlertAction.Create("Website", UIAlertActionStyle.Default, GotoWebsite));
            }

            okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Cancel, null));
            owner.PresentViewController(okAlertController, true, null);

            tableView.DeselectRow(indexPath, true);
        }

        /// <summary>
        /// Called by the TableView to get the actual UITableViewCell to render for the particular row
        /// </summary>
        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            // request a recycled cell to save memory
            UITableViewCell cell = tableView.DequeueReusableCell(cellIdentifier);
            // if there are no cells to reuse, create a new one
            if (cell == null)
                cell = new UITableViewCell(UITableViewCellStyle.Subtitle, cellIdentifier);

            cell.TextLabel.Text = storeItems[indexPath.Row].Producer;
            cell.DetailTextLabel.Text = storeItems[indexPath.Row].Address;

            return cell;
        }

        void CallStore(UIAlertAction obj)
        {

        }

        void DirectionsToStore(UIAlertAction obj)
        {

        }

        void GotoWebsite(UIAlertAction obj)
        {

        }
    }
}