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
            string message = "Phone: " + storeItems[indexPath.Row].Phone + "\n" +
                "Address: " + storeItems[indexPath.Row].Address + "\n" +
                "Hours: " + storeItems[indexPath.Row].Hours + "\n\n" +
                "Website: " + storeItems[indexPath.Row].Website + "\n";
            UIAlertController okAlertController = UIAlertController.Create(storeItems[indexPath.Row].Producer,message, UIAlertControllerStyle.Alert);
            okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Cancel, null));
            okAlertController.AddAction(UIAlertAction.Create("Call", UIAlertActionStyle.Default, CallStore));
            okAlertController.AddAction(UIAlertAction.Create("Directions", UIAlertActionStyle.Default, DirectionsToStore));
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
    }
}