using System;
using System.Collections.Generic;
using Foundation;
using UIKit;

using Debug = System.Diagnostics.Debug;

namespace xamarin2.iOS
{
	public partial class ViewController : UIViewController
	{
		//private List<string> arrList { get; set; }

		public ViewController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			// Perform any additional setup after loading the view, typically from a nib.
			m_lb.Text = "List";
			ShowTable();
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


			var todoSource = new TodoSource(list);
			m_table.Source = todoSource;

			todoSource.TodoSelected += (object sender, TodoSelectedEventArgs e) =>
			{
				//Debug.WriteLine($"Name:{e.selectedTodo.Name}; Description:{e.selectedTodo.Desc}");
				Debug.WriteLine($"selected item:{e.selectedTodo}");

				PerformSegue("toDetail", this);
			};

		}

		class TodoSource : UITableViewSource
		{
			private List<string> Todos { get; set; }
			public event EventHandler<TodoSelectedEventArgs> TodoSelected;

			const string MyTableViewCellID = "TableViewCell";

			public TodoSource(IEnumerable<string> source)
			{
				Todos = new List<string>();
				Todos.AddRange(source);
			}

			public override nint RowsInSection(UITableView tableview, nint section)
			{
				//throw new NotImplementedException();
				return Todos.Count;
			}

			public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
			{
				//throw new NotImplementedException();

				TableViewCell cell = tableView.DequeueReusableCell(MyTableViewCellID) as TableViewCell;

				var todo = Todos[indexPath.Row];
				cell.Update(todo);

				return cell;
			}

			public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
			{
				//base.RowSelected(tableView, indexPath);

				tableView.DeselectRow(indexPath, true);

				var todo = Todos[indexPath.Row];

				EventHandler<TodoSelectedEventArgs> handler = TodoSelected;
				if (null != handler)
				{
					handler(this, new TodoSelectedEventArgs { selectedTodo = todo });
				}
			}

		}

		public class TodoSelectedEventArgs : EventArgs
		{
			public string selectedTodo { get; set; }
		}
	}
}
