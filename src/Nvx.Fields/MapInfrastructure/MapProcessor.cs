using Nvx.Fields.MapInfrastructure.Yandex;

namespace Nvx.Fields.MapInfrastructure
{
    public static class MapProcessor
    {
        private static readonly IGeocode geocoder;

        static MapProcessor()
        {
            geocoder = new YandexGeocode();
        }

        public static Location GeocodeLocation(string adress)
        {
            return geocoder.GetLocation(adress);
        }

        public static string GetStaticMapurl(int h, int w, double lat, double lng)
        {
            return geocoder.GetMapUrl(h, w, new Location() {Lattitude = lat, Longitude = lng});
        }

        public static string AddPoint(string controlid,double lat,double lng,string label) {
            return geocoder.AddPoint(controlid, lat, lng, label);
        }

        public static string MakeMap(string controlid) {
            return geocoder.MakeMap(controlid);
        }
    }
}
