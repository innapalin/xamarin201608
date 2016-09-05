// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace xamarin2.iOS
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		UIKit.UIImageView m_iv { get; set; }

		[Outlet]
		UIKit.UILabel m_lb { get; set; }

		[Outlet]
		UIKit.UITableView m_table { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (m_iv != null) {
				m_iv.Dispose ();
				m_iv = null;
			}

			if (m_lb != null) {
				m_lb.Dispose ();
				m_lb = null;
			}

			if (m_table != null) {
				m_table.Dispose ();
				m_table = null;
			}
		}
	}
}
