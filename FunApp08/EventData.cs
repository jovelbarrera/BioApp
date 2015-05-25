using System;

namespace BioApp
{
	/* Esta es la clase que manejará las peticiones a Parse a través de la REST Api tengo problemas implementando esta parte*/
	public class EventData
	{
		public EventData ()
		{
		}
		/* Esta clase deberá peticionar los campos objectId, Image, Title,Category de la clase Event en la Parse App para alimentar la EventListPage*/
		/* Mientras logro hacer las peticiones este método regresa un arreglos con datos de prueba */
		public static EventItem[] GetAListOfAllEvents ()
		{
			return new EventItem [] {
				new EventItem {
					objectId="1",
					Image = "http://2.bp.blogspot.com/-oNADtgTQK-s/UTAgGFoBVQI/AAAAAAAABNE/pUltwszG2XM/s1600/monsenor-romero.jpg",
					Title = "Oscar Arnulfo Romero",
					Category = "Religión"
				},
				new EventItem {
					objectId="2",
					Image = "http://www.crystalinks.com/einstein1199.jpg",
					Title = "Albert Einstein",
					Category = "Ciencias"
				},
				new EventItem {
					objectId="3",
					Image = "http://crenshawcomm.com/wp-content/uploads/2014/01/Martin-Luther-King-Jr-9365086-1-402.jpg",
					Title = "Martin Luther King Jr",
					Category = "Política"
				},
				new EventItem {
					objectId="4",
					Image = "http://3.bp.blogspot.com/-Z5zhgOJytwo/U5x5H1ivWYI/AAAAAAAAAEM/-XD67Laeu-Q/s1600/claudia-lars2.png",
					Title = "Claudia Lars",
					Category = "Literatura"
				},
			};
		}
		/* Este método deberá poder obtener el campo descrición de un objeto determinado en la clase Event de Parse App*/
		public static string GetEvenDetail (string objectId)
		{
			return objectId+" Descripction";
		}
	}
}

