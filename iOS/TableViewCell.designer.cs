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
	[Register ("TableViewCell")]
	partial class TableViewCell
	{
		[Outlet]
		UIKit.UILabel m_lb { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (m_lb != null) {
				m_lb.Dispose ();
				m_lb = null;
			}
		}
	}
}
