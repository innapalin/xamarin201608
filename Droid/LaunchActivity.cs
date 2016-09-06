
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
	//[Activity(Label = "LaunchActivity")]
	[Activity(Label = "LaunchActivity", MainLauncher = true, Icon = "@mipmap/icon")]
	public class LaunchActivity : Activity
	{

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Create your application here
			SetContentView(Resource.Layout.Launch);

			ImageView iv = FindViewById<ImageView>(Resource.Id.launch_iv);
			iv.SetImageResource(Resource.Mipmap.launch);

			new Handler().PostDelayed(() =>
			{
				Intent intent = new Intent(this, typeof(MainActivity));
				StartActivity(intent);
				this.Finish();
			}, 5000);
		}
	}
}

