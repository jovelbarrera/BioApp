using System;

using Xamarin.Forms;

namespace BioApp
{
	/* Clase que genera la pantalla de detalle luego de hacer tap en un elemnto de la lista */
	public class EventDetailPage : ContentPage
	{
		public EventDetailPage (EventItem eventItem)
		{
			var image = new Image {
				HorizontalOptions = LayoutOptions.Center,
				Aspect = Aspect.AspectFit, 
			};
			image.Source = eventItem.Image;
			image.WidthRequest = image.HeightRequest = 160;

			this.Title = eventItem.Title;

			Content = new StackLayout {
				Padding = new Thickness (8, 8),
				Children = {
					new Label {
						Text = eventItem.Title,
						FontAttributes = FontAttributes.Bold,
						FontSize = Device.GetNamedSize (NamedSize.Large, typeof(Label)),
						HorizontalOptions = LayoutOptions.Center,
					},
					image,
					new Label {
						Text = eventItem.Category,
						FontAttributes = FontAttributes.Italic,
						FontSize = Device.GetNamedSize (NamedSize.Medium, typeof(Label)),
						HorizontalOptions = LayoutOptions.Center,
					},
					new Label { Text = EventData.GetEvenDetail(eventItem.objectId) },
				}
			};
		}
	}
}


