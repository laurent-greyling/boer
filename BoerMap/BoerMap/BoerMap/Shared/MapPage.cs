using Android.Locations;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace BoerMap.Shared
{
    public class MapPage : ContentPage
    {
        public MapPage()
        {
            const string locationProvider = LocationManager.GpsProvider;
            var location = new Location(locationProvider);
            
            //TODO: find out why I end up not opening on pin but middle of ocean
            var map = new Map(
                MapSpan.FromCenterAndRadius(new Position(location.Latitude, location.Longitude), Distance.FromKilometers(0.3)))
            {
                IsShowingUser = true,
                HeightRequest = 100,
                WidthRequest = 960,
                VerticalOptions = LayoutOptions.FillAndExpand,
                MapType = MapType.Street
            };

            var stack = new StackLayout
            {
                Spacing = 0
            };

            //give this point the Latitude, Longitude of incoming message
            var position = new Position(52.39, 4.66);
            var pin = new Pin
            {
                Type = PinType.Place,
                Position = position,
                Label = "BoerMap"

            };

            map.Pins.Add(pin);

            //TODO: map route to pin

            stack.Children.Add(map);

            Content = stack;
        }
    }
}
