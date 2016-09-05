using System;
using Foundation;
using UIKit;

namespace xamarin2.iOS
{
	public partial class DetailViewController : UIViewController
	{
		//public DetailViewController() : base("DetailViewController", null)
		public DetailViewController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.

			Title = "Detail";

			m_btnMap.TouchUpInside += (sender, e) =>
			{
				PerformSegue("toMap", this);
			};

			m_btnWeb.TouchUpInside += (sender, e) => 
			{
				PerformSegue("toWeb", this);
			};
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}

		public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
		{
			base.PrepareForSegue(segue, sender);
		}
	}
}


