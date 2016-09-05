using System;
using Foundation;
using UIKit;

namespace xamarin2.iOS
{
	public partial class WebViewController : UIViewController
	{
		//public WebViewController() : base("WebViewController", null)
		public WebViewController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.

			Title = "Web";

			m_wv.LoadRequest(new NSUrlRequest(new NSUrl(@"https://www.google.com.tw")));
			m_wv.ScalesPageToFit = true;
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}


