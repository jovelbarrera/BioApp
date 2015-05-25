using System;

using Xamarin.Forms;

namespace BioApp
{
	/* Clase encargada de preparar ordenar los elementos que irán dentro del la lista se utiliza en la clase EventListPage*/
	public class EventCell : ViewCell
	{
		/* Genera la vista a utilizar en cada elemento de la lista */
		public EventCell ()
		{
			var image = new Image {
				HorizontalOptions = LayoutOptions.Start
			};

			image.SetBinding (Image.SourceProperty,"Image");

			image.WidthRequest = image.HeightRequest = 80;

			var titleLayout = CreateTitleLayout ();

			var viewLayout = new StackLayout () {
				Orientation = StackOrientation.Horizontal,
				Children = { image, titleLayout }
			};
			View = viewLayout;
		}
		/* método que crea el layout de con la imagen título y categoría de cada elemento de la lista */
		static StackLayout CreateTitleLayout ()
		{
			var titleLabel = new Label {
				HorizontalOptions = LayoutOptions.FillAndExpand,
				FontAttributes = FontAttributes.Bold,
			};
			titleLabel.SetBinding (Label.TextProperty, "Title");

			var categoryLabel = new Label {
				HorizontalOptions = LayoutOptions.FillAndExpand,
				FontAttributes = FontAttributes.Italic
			};
			categoryLabel.SetBinding (Label.TextProperty, "Category");

			var titleLayout = new StackLayout () {
				HorizontalOptions = LayoutOptions.StartAndExpand,
				Orientation = StackOrientation.Vertical,
				Children = { titleLabel, categoryLabel }
			};
			return titleLayout;
		}
	}
}


