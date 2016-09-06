
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.Locations;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using LiddleSay = System.Diagnostics.Debug;

namespace xamarin2.Droid
{
	[Activity(Label = "MapActivity")]
	public class MapActivity : Activity,
	Android.Locations.ILocationListener,
	Android.Gms.Maps.GoogleMap.IOnMyLocationButtonClickListener
	{
		private MapFragment _mapFragment;
		private GoogleMap _map;

		private Location _currentLocation;
		private bool currentLocationReceieved;
		private LocationManager _locationManager;
		private string _locationProvider;

		public void OnConnected(Bundle bundle)
		{

		}
		public void OnConnectionSuspended(int code)
		{

		}
		public void OnConnectionFailed(Android.Gms.Common.ConnectionResult result)
		{
		}

		#region ILocationListener

		public void OnLocationChanged(Android.Locations.Location location)
		{

			_currentLocation = location;
			if (_currentLocation == null)
			{
				LiddleSay.WriteLine("Unable to determine your location.");
			}
			else
			{

				LiddleSay.WriteLine(string.Format("Latitude:{0};Longitude:{1}", _currentLocation.Latitude, _currentLocation.Longitude));

			}
		}

		public void OnProviderDisabled(string provider)
		{
			LiddleSay.WriteLine("ProviderDisabled");
		}

		public void OnProviderEnabled(string provider)
		{
			LiddleSay.WriteLine("ProviderEnabled");
		}

		public void OnStatusChanged(string provider, Availability status, Bundle extras)
		{
			LiddleSay.WriteLine(string.Format("provider:{0}, status:{1}", provider, status));
		}

		#endregion


		#region IOnMyLocationButtonClickListener

		public bool OnMyLocationButtonClick()
		{

			try
			{
				var lastLocation = _locationManager.GetLastKnownLocation(LocationManager.GpsProvider);

				if (null != lastLocation && lastLocation.Latitude > 0 && lastLocation.Longitude > 0)
				{
					_currentLocation = lastLocation;
					currentLocationReceieved = true;

					_map.Clear();


					_map.AnimateCamera(CameraUpdateFactory.NewLatLngZoom(new LatLng(_currentLocation.Latitude, _currentLocation.Longitude), 14.5f));
				}

				LiddleSay.WriteLine("OnMyLocationButtonClick(), current location:{0},{1}", _currentLocation.Latitude, _currentLocation.Longitude);
			}
			catch (Exception exception)
			{
				currentLocationReceieved = false;
				LiddleSay.WriteLine(exception.Message);
			}



			return true;
		}

		#endregion

		private LatLng defaultLocation;
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Create your application here
			SetContentView(Resource.Layout.Map);

			defaultLocation = new LatLng(23.9737437408, 120.981806398);

			//
			GoogleMapOptions mapOptions = new GoogleMapOptions()
				.InvokeMapType(GoogleMap.MapTypeSatellite)
				.InvokeCamera(new CameraPosition(defaultLocation, 14.0f, 3.0f, 0.0f))
				.InvokeZoomControlsEnabled(true)
				.InvokeCompassEnabled(true);


			_mapFragment = FragmentManager.FindFragmentByTag("map") as MapFragment;

			if (_mapFragment == null)
			{
				FragmentTransaction fragTx = FragmentManager.BeginTransaction();
				_mapFragment = MapFragment.NewInstance(mapOptions);
				fragTx.Add(Resource.Id.map_layout_mapWithOverlay, _mapFragment, "map");

				fragTx.Commit();
			}

			var mapReadyCallback = new MyOnMapReady();
			mapReadyCallback.MapReady += (object sender, MapReadyEventArgs args) =>
			{

				_map = args.Map;
				_map.MyLocationEnabled = true;
				_map.UiSettings.MyLocationButtonEnabled = true;
				_map.AnimateCamera(CameraUpdateFactory.NewLatLngZoom(defaultLocation, 12.0f));
			};

			_mapFragment.GetMapAsync(mapReadyCallback);

			InitializeLocationManager();
		}

		protected override void OnResume()
		{
			base.OnResume();

			Criteria locationCriteria = new Criteria();
			locationCriteria.Accuracy = Accuracy.Coarse;
			locationCriteria.PowerRequirement = Power.NoRequirement;

			string locationProvider = _locationManager.GetBestProvider(locationCriteria, true);

			if (!String.IsNullOrEmpty(locationProvider))
			{
				_locationManager.RequestLocationUpdates(locationProvider, 2000, 1, this);
			}
			else
			{
				LiddleSay.WriteLine(@"No Location Provider");
			}
		}

		protected override void OnPause()
		{
			base.OnPause();
			_locationManager.RemoveUpdates(this);

		}

		private void InitializeLocationManager()
		{
			_locationManager = (LocationManager)GetSystemService(LocationService);

			Criteria criteriaForLocationService = new Criteria
			{
				Accuracy = Accuracy.Fine
			};

			IList<string> acceptableLocationProviders = _locationManager.GetProviders(criteriaForLocationService, true);

			if (acceptableLocationProviders.Count(p => p == LocationManager.GpsProvider) == 1)
			{

				_locationProvider = LocationManager.GpsProvider;

				// NOTE : RequestLocationUpdates
				_locationManager.RequestLocationUpdates(_locationProvider, 100, 1, this);

				LiddleSay.WriteLine(@"Location Provider : GPS");

				try
				{
					var lastLocation = _locationManager.GetLastKnownLocation(LocationManager.GpsProvider);

					if (null != lastLocation && lastLocation.Latitude > 0 && lastLocation.Longitude > 0)
					{
						_currentLocation = lastLocation;
						currentLocationReceieved = true;

						LiddleSay.WriteLine("{0},{1}", _currentLocation.Latitude, _currentLocation.Longitude);
					}
				}
				catch (Exception exception)
				{
					currentLocationReceieved = false;
					LiddleSay.WriteLine(exception.Message);
				}


			}

		}

		#region Map Callback

		private class MyOnMapReady : Java.Lang.Object, IOnMapReadyCallback
		{
			public GoogleMap Map { get; private set; }

			public event EventHandler<MapReadyEventArgs> MapReady;

			public void OnMapReady(GoogleMap googleMap)
			{
				if (null != googleMap)
				{
					Map = googleMap;
					var handler = MapReady;
					if (handler != null)
						handler(this, new MapReadyEventArgs(googleMap));
				}
			}
		}

		private class MapReadyEventArgs
		{

			public MapReadyEventArgs(GoogleMap map)
			{
				Map = map;
			}
			public GoogleMap Map { get; private set; }
		}

		#endregion
	}
}

