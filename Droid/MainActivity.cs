using Android.App;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using Android.Views;
using Android.Content;

namespace xamarin2.Droid
{
	[Activity(Label = "xamarin2", MainLauncher = false, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		//int count = 1;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			ImageView iv = FindViewById<ImageView>(Resource.Id.list_iv);
			iv.SetImageResource(Resource.Mipmap.list);
			iv.SetBackgroundColor(Android.Graphics.Color.White);

			TextView tv = FindViewById<TextView>(Resource.Id.list_tv);
			tv.SetTextColor(Android.Graphics.Color.White);
			tv.SetBackgroundColor(Android.Graphics.Color.Gray);
			tv.Text = "text list";

			//ListView lv = FindViewById<ListView>(Resource.Id.list_lv);
			//lv.SetBackgroundColor(Android.Graphics.Color.Cyan);

			ShowTable();
		}

		private void ShowTable()
		{
			var list = new List<string>();
			list.Add("test1");
			list.Add("test2");
			list.Add("test3");
			list.Add("test4");
			list.Add("test5");
			list.Add("test6");
			list.Add("test7");
			list.Add("test8");
			list.Add("test9");
			list.Add("test10");

			ListView lv = FindViewById<ListView>(Resource.Id.list_lv);

			lv.Adapter = new TodoAdapter(list, this);

			lv.ItemClick += (object sender, AdapterView.ItemClickEventArgs e) =>
			{				
				System.Diagnostics.Debug.WriteLine($"selected item:{list[e.Position]}");

				Intent intent = new Intent(this, typeof(DetailActivity));
				StartActivity(intent);
			};
		}

		class TodoAdapter : BaseAdapter<string>
		{
			private List<string> Todoes { get; set; }
			private Activity Context { get; set; }

			public TodoAdapter(IEnumerable<string> source, Activity context)
			{
				Todoes = new List<string>();
				Todoes.AddRange(source);

				Context = context;
			}

			public override int Count => Todoes.Count;

			public override string this[int position] => Todoes[position];

			public override long GetItemId(int position)
			{
				return position;
			}

			public override View GetView(int position, View convertView, ViewGroup parent)
			{
				var view = convertView;

				if (null == view)
				{
					view = this.Context.LayoutInflater.Inflate(Resource.Layout.ListViewItemLayout, parent, false);
				}

				var todo = Todoes[position];

				//view.FindViewById<TextView>(Resource.Id.table_mylistview_itemview_name).Text = todo.Name;
				//view.FindViewById<TextView>(Resource.Id.table_mylistview_itemview_description).Text = todo.Description;
				view.FindViewById<TextView>(Resource.Id.listviewitem_tv).Text = todo;

				return view;
			}
		}
	}
}


