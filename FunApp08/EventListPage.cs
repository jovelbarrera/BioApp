using System;

using Xamarin.Forms;

namespace BioApp
{
	/* Clase que genera la lista en la pantalla inicial */
	public class EventListPage : ContentPage
	{
		public EventListPage ()
		{
			ListView eventList = new ListView{};
			eventList.RowHeight = 80;
			eventList.ItemsSource = EventData.GetAListOfAllEvents ();
			eventList.ItemTemplate = new DataTemplate (typeof(EventCell));
			eventList.ItemTemplate.SetBinding (TextCell.TextProperty, "Title");
			eventList.ItemSelected += async (sender, e) => {
				var eventItem = (EventItem)e.SelectedItem;
				await Navigation.PushAsync (new EventDetailPage(eventItem));
			};
			this.Title = "BioApp";
			Content = new StackLayout {
				VerticalOptions = LayoutOptions.FillAndExpand,
				Children = { 
					eventList,
				}
			};
		}
	}
}


