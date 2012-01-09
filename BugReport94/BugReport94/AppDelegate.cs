using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.Dialog;

namespace BugReport94
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the 
	// User Interface of the application, as well as listening (and optionally responding) to 
	// application events from iOS.
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		// class-level declarations
		UINavigationController navigation;
		UIWindow window;

		//
		// This method is invoked when the application has loaded and is ready to run. In this 
		// method you should instantiate the window, load the UI into it and then make the window
		// visible.
		//
		// You have 17 seconds to return from this method, or iOS will terminate your application.
		//
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			navigation = new UINavigationController();
			window = new UIWindow(UIScreen.MainScreen.Bounds);
			
			//
			// Create our UI and add it to the current toplevel navigation controller
			// this will allow us to have nice navigation animations.
			//
			var dv = new SearchDialogViewController () {
				Autorotate = true
			};
			navigation.PushViewController (dv, true);				

			window.MakeKeyAndVisible ();

			// On iOS5 we use the new window.RootViewController, on older versions, we add the subview
            if (UIDevice.CurrentDevice.CheckSystemVersion (5, 0))
				window.RootViewController = navigation;	
			else
				window.AddSubview (navigation.View);

			return true;
		}
	}
}

