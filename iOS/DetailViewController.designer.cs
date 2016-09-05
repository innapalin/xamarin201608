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
	[Register ("DetailViewController")]
	partial class DetailViewController
	{
		[Outlet]
		UIKit.UIButton m_btnMap { get; set; }

		[Outlet]
		UIKit.UIButton m_btnWeb { get; set; }

		[Outlet]
		UIKit.UIImageView m_iv { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (m_iv != null) {
				m_iv.Dispose ();
				m_iv = null;
			}

			if (m_btnMap != null) {
				m_btnMap.Dispose ();
				m_btnMap = null;
			}

			if (m_btnWeb != null) {
				m_btnWeb.Dispose ();
				m_btnWeb = null;
			}
		}
	}
}
