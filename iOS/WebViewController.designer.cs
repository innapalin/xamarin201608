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
	[Register ("WebViewController")]
	partial class WebViewController
	{
		[Outlet]
		UIKit.UIWebView m_wv { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (m_wv != null) {
				m_wv.Dispose ();
				m_wv = null;
			}
		}
	}
}
