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

        public SearchViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            b_SearchButton.TouchUpInside += SearchButtonPressed;
            b_SearchCurrentLocation.TouchUpInside += SearchCurrentLocationButtonPressed;

            locationManager.RequestWhenInUseAuthorization();

            m_SearchMap.ShowsUserLocation = true;
            m_SearchMap.DidUpdateUserLocation += UpdateMap;

            AddPins();
        }

        void SearchButtonPressed(object sender, EventArgs e)
        {
            GeocodeToUpdateMap(t_SearchCity.Text);
        }

        void SearchCurrentLocationButtonPressed(object sender, EventArgs e)
        {
            t_SearchNavBarText.Title = m_SearchMap.UserLocation.Coordinate.ToString();
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

            MKCoordinateSpan span = new MKCoordinateSpan(KilometresToLatitudeDegrees(10000), KilometresToLongitudeDegrees(10000, coords.Latitude));
            m_SearchMap.Region = new MKCoordinateRegion(coords, span);
        }

        void UpdateMap(CLLocationCoordinate2D coords)
        {
            MKCoordinateSpan span = new MKCoordinateSpan(KilometresToLatitudeDegrees(10000), KilometresToLongitudeDegrees(10000, coords.Latitude));
            m_SearchMap.Region = new MKCoordinateRegion(coords, span);
        }

        async void GeocodeToUpdateMap(string address)
        {
            var geoCoder = new CLGeocoder();
            CLPlacemark[] placemarks = await geoCoder.GeocodeAddressAsync(address);
            UpdateMap(placemarks[0].Location.Coordinate);
        }

        int counter = 0;
        async void AddPins()
        {

            for (int i = 0; i < AppDelegate.allStores.Count; i++)
            {
                Store store = AppDelegate.allStores[i];
                try
                {
                    CLPlacemark[] placemarks = await geoCoder.GeocodeAddressAsync(store.Address + " " + store.City);
                    t_SearchNavBarText.Title = store.Producer;
                    m_SearchMap.AddAnnotations(new MKPointAnnotation()
                    {
                        Title = store.Producer,
                        Coordinate = new CLLocationCoordinate2D(placemarks[0].Location.Coordinate.Latitude, placemarks[0].Location.Coordinate.Longitude)
                    });
                    counter++;
                }
                catch
                {

                }
            }
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
    }
}