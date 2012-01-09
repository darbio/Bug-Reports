using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.Dialog;
using System.Threading;

namespace BugReport94
{
	public class SearchDialogViewController : DialogViewController
	{	
		public SearchDialogViewController () : base (null, true)
		{
			EnableSearch = true;
			Style = UITableViewStyle.Plain;
			Title = "Search";
		}
		
		public override void SearchButtonClicked (string text)
		{
			base.SearchButtonClicked(text);
			
			Search (text);
		}
		
		public override void OnSearchTextChanged (string text)
		{
			base.OnSearchTextChanged (text);
			
			Search (text);
		}
		
		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);
			
			Root = new RootElement (Title){
				new Section()
			};
		}
		
		public IEnumerable<Element> PerformSearch(string text)
		{
			return new List<Element>(){
				new StringElement("Item 1"),
				new StringElement("Item 2"),
				new StringElement("Item 3"),
				new StringElement("Item 4"),
				new StringElement("Item 5"),
				new StringElement("Item 6"),
				new StringElement("Item 7"),
				new StringElement("Item 8"),
				new StringElement("Item 9"),
				new StringElement("Item 10"),
			};
		}
		
		public override void Selected (MonoTouch.Foundation.NSIndexPath indexPath)
		{
			base.Selected (indexPath);
		}
		
		public void Search(string searchText)
		{
			ThreadStart processDelegate = delegate {
				PopulateResults (PerformSearch (searchText));
			};
			Thread thread = new Thread (processDelegate);
			thread.Start ();
		}
		
		public void PopulateResults(IEnumerable<Element> elements)
		{
			// Simulate WS call by sleeping for 5 seconds
			Thread.Sleep (5000);
			
			BeginInvokeOnMainThread(() => {
				Section section = new Section("Search Results");
				section.AddAll(elements);
				
				Root = new RootElement(Title){
					section
				};
				
				TableView.ReloadData();
				TableView.SetNeedsDisplay ();
			});
		}
	}
}

