using Foundation;
using System;
using System.IO;
using System.Collections.Generic;
using System.CodeDom.Compiler;
using UIKit;
using SQLite;
using CoreGraphics;
using CoreLocation;
using MapKit;
using Xamarin.Forms.Maps;
using System.Threading.Tasks;

namespace Open_Data_Hackathon__2017
{
    public partial class SearchViewController : UIViewController
    {
        CLLocationManager locationManager = new CLLocationManager();
        CLGeocoder geoCoder = new CLGeocoder();
        UITableView table;

        public SearchViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            table = v_SearchTableView;

            b_SearchButton.TouchUpInside += SearchButtonPressed;

            locationManager.RequestWhenInUseAuthorization();

            m_SearchMap.ShowsUserLocation = true;
            m_SearchMap.DidUpdateUserLocation += UpdateMap;
        }

        async void SearchButtonPressed(object sender, EventArgs e)
        {
            m_SearchMap.RemoveAnnotations();

            if (t_SearchCity.Text == "Current Location")
            {
                await AddPins();
                FindNearestStores(m_SearchMap.UserLocation.Coordinate.Latitude, m_SearchMap.UserLocation.Coordinate.Longitude);

                List<string> tableList = new List<string>();
                for (int i = 0; i < AppDelegate.nearestStores.Count; i++)
                {
                    tableList.Add(AppDelegate.nearestStores[i].Producer);
                }
                string[] tableItems = tableList.ToArray();
                table.Source = new TableSource(tableItems, AppDelegate.nearestStores.ToArray(), this);
                Add(table);
                table.ReloadData();
            }
            else
            {
                GeocodeToUpdateMap(t_SearchCity.Text);
            }
        }

        void UpdateSearchLocation(CLLocationCoordinate2D coords)
        {
            FindNearestStores(coords.Latitude, coords.Longitude);

            List<string> tableList = new List<string>();
            for (int i = 0; i < AppDelegate.nearestStores.Count; i++)
            {
                tableList.Add(AppDelegate.nearestStores[i].Producer);
            }
            string[] tableItems = tableList.ToArray();
            table.Source = new TableSource(tableItems, AppDelegate.nearestStores.ToArray(), this);
            Add(table);
            table.ReloadData();
        }

        void FindNearestStores(double lat, double lon)
        {
            AppDelegate.nearestStores.Clear();
            for (int i = 0; i < AppDelegate.allStores.Count; i++)
            {
                if (TestRange(AppDelegate.allStores[i].Lon, lon - 0.05, lon + 0.05) && TestRange(AppDelegate.allStores[i].Lat, lat - 0.05, lat + 0.05))
                {
                    AppDelegate.nearestStores.Add(AppDelegate.allStores[i]);
                }
            }
        }

        void UpdateMap(object sender, EventArgs e)
        {
            CLLocationCoordinate2D coords = new CLLocationCoordinate2D();
            if (!m_SearchMap.UserLocationVisible)
            {
                coords = m_SearchMap.UserLocation.Coordinate;
            }
            if (m_SearchMap.UserLocation != null)
            {
                coords = m_SearchMap.UserLocation.Coordinate;
            }

            MKCoordinateSpan span = new MKCoordinateSpan(KilometresToLatitudeDegrees(10), KilometresToLongitudeDegrees(10, coords.Latitude));
            m_SearchMap.Region = new MKCoordinateRegion(coords, span);
        }

        void UpdateMap(CLLocationCoordinate2D coords)
        {
            MKCoordinateSpan span = new MKCoordinateSpan(KilometresToLatitudeDegrees(10), KilometresToLongitudeDegrees(10, coords.Latitude));
            m_SearchMap.Region = new MKCoordinateRegion(coords, span);
        }

        async void GeocodeToUpdateMap(string address)
        {
            b_SearchButton.Enabled = false;
            var geoCoder = new CLGeocoder();

            try
            {
                CLPlacemark[] placemarks = await geoCoder.GeocodeAddressAsync(address);
                UpdateMap(placemarks[0].Location.Coordinate);

                await AddPins();
                UpdateSearchLocation(new CLLocationCoordinate2D(placemarks[0].Location.Coordinate.Latitude, placemarks[0].Location.Coordinate.Longitude));
            }
            catch
            {
                UIAlertController okAlertController = UIAlertController.Create("ERROR", "Invalid address, try again", UIAlertControllerStyle.Alert);
            }
            b_SearchButton.Enabled = true;
        }

        async Task AddPins()
        {
            b_SearchButton.Enabled = false;
            for (int i = 0; i < AppDelegate.allStores.Count; i++)
            {
                t_SearchNavBarText.Title = i+"";
                Store store = AppDelegate.allStores[i];
                try
                {
                    CLPlacemark[] placemarks = await geoCoder.GeocodeAddressAsync(store.Address + " " + store.City);

                    store.Lon = placemarks[0].Location.Coordinate.Longitude;
                    store.Lat = placemarks[0].Location.Coordinate.Latitude;

                    m_SearchMap.AddAnnotations(new MKPointAnnotation()
                    {
                        Title = store.Producer,
                        Coordinate = new CLLocationCoordinate2D(placemarks[0].Location.Coordinate.Latitude, placemarks[0].Location.Coordinate.Longitude)
                    });
                }
                catch
                {

                }
            }
            b_SearchButton.Enabled = true;
        }








        /// <summary>Converts kilometres to latitude degrees</summary>
        public double KilometresToLatitudeDegrees(double kms)
        {
            double earthRadius = 6371.0; // in kms
            double radiansToDegrees = 180.0 / Math.PI;
            return (kms / earthRadius) * radiansToDegrees;
        }

        /// <summary>Converts kilometres to longitudinal degrees at a specified latitude</summary>
        public double KilometresToLongitudeDegrees(double kms, double atLatitude)
        {
            double earthRadius = 6371.0; // in kms
            double degreesToRadians = Math.PI / 180.0;
            double radiansToDegrees = 180.0 / Math.PI;
            // derive the earth's radius at that point in latitude
            double radiusAtLatitude = earthRadius * Math.Cos(atLatitude * degreesToRadians);
            return (kms / radiusAtLatitude) * radiansToDegrees;
        }

        bool TestRange(double numberToCheck, double bottom, double top)
        {
            return (numberToCheck >= bottom && numberToCheck <= top);
        }



    }
}