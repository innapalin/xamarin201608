
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace xamarin2.Droid
{
	[Activity(Label = "DetailActivity")]
	public class DetailActivity : Activity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Create your application here
			SetContentView(Resource.Layout.Detail);

			ImageView iv = FindViewById<ImageView>(Resource.Id.detail_iv);
			iv.SetImageResource(Resource.Mipmap.detail);

			Button btn_map = FindViewById<Button>(Resource.Id.detail_btn_map);
			btn_map.Click += delegate {
				Intent listActivity = new Intent(this, typeof(MapActivity));

				StartActivity(listActivity);
			};

			Button btn_web = FindViewById<Button>(Resource.Id.detail_btn_web);
			btn_web.Click += delegate {
				Intent listActivity = new Intent(this, typeof(WebActivity));

				StartActivity(listActivity);
			};
		}
	}
}

