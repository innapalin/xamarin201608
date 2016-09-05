using System;
using CoreLocation;
using MapKit;
using UIKit;

namespace xamarin2.iOS
{
	public partial class MapViewController : UIViewController
	{
		//public MapViewController() : base("MapViewController", null)
		public MapViewController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.

			Title = "Map";

			var mapCenter = new CLLocationCoordinate2D(
				25.076351, 121.5729);
			m_mapView.CenterCoordinate = mapCenter;


			var mapRegion = MKCoordinateRegion.FromDistance(mapCenter, 4000, 4000);
			m_mapView.Region = mapRegion;

			m_mapView.ShowsUserLocation = true;
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}


