using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Parse;

namespace FunApp08.Android
{
	public class ParseStorage : IParseStorage
	{
		static ParseStorage todoServiceInstance = new ParseStorage();
		public static ParseStorage Default { get { return todoServiceInstance; } }
		public List<EventItem> Items { get; private set;}

		// Constructor
		protected ParseStorage()
		{
			Items = new List<EventItem>();

			// https://parse.com/apps/YOUR_APP_NAME/edit#app_keys
			// ApplicationId, Windows/.NET/Client key
			//ParseClient.Initialize ("APPLICATION_ID", ".NET_KEY");
			ParseClient.Initialize (Constants.ApplicationId, Constants.Key);
		}



		ParseObject ToParseObject (EventItem todo)
		{
			var po = new ParseObject("Task");
			if (todo.ID != string.Empty)
				po.ObjectId = todo.ID;
			po["Title"] = todo.Name;
			po["Description"] = todo.Notes;
			po["IsDone"] = todo.Done;

			return po;
		}

		static EventItem FromParseObject (ParseObject po)
		{
			var t = new EventItem();
			t.ID = po.ObjectId;
			t.Name = Convert.ToString(po["Title"]);
			t.Notes = Convert.ToString (po["Description"]);
			t.Done = Convert.ToBoolean (po["IsDone"]);
			return t;
		}

		public static async Task<List<EventItem>> GetAll () 
		{
			var query = ParseObject.GetQuery ("Task").OrderBy ("Title");
			var ie = await query.FindAsync ();

			var tl = new List<EventItem> ();
			foreach (var t in ie) {
				tl.Add (FromParseObject (t));
			}

			return tl;
		}



		async public Task<List<EventItem>> RefreshDataAsync()
		{
			var query = ParseObject.GetQuery ("Task").OrderBy ("Title");
			var ie = await query.FindAsync ();

			var Items = new List<EventItem> ();
			foreach (var t in ie) {
				Items.Add (FromParseObject (t));
			}

			return Items;
		}

		public async Task SaveEventItemAsync(EventItem todoItem)
		{
			await ToParseObject(todoItem).SaveAsync();
		}

		public async Task<EventItem> GetEventItemAsync(string id)
		{
			var query = ParseObject.GetQuery("Task").WhereEqualTo("objectId", id);
			var t = await query.FirstAsync();
			return FromParseObject (t);
		}

		public async Task DeleteEventItemAsync(EventItem item)
		{
			try 
			{
				await ToParseObject(item).DeleteAsync();
			} 
			catch (Exception e) 
			{
				Console.Error.WriteLine(@"				ERROR {0}", e.Message);
			}
		}

	}
}



