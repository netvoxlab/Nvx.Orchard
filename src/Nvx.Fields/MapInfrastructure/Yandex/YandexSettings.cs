using System;
using System.Web;

namespace Nvx.Fields.MapInfrastructure.Yandex {
    public enum YandexPointColor
    {
        Wt,
        Do,
        Db,
        Bl,
        Gn,
        Gr,
        Lb,
        Nt,
        Or,
        Pn,
        Rd,
        Vv,
        Yw
    }

    public enum YandexPointSize
    {
        S, M, L
    }

    [Serializable]
    public class YandexSettings
    {
        //private string geocoderUrl = "http://geocode-maps.yandex.ru/1.x/";
        private string geocoderUrl = @"http://geocode-maps.yandex.ru/1.x/?geocode={0}&key={1}";
        private string staticMapUrl = @"http://geocode-maps.yandex.ru/1.x/?geocode={0}&key={1}";
        private string mapsKey = "AJMOsk4BAAAAjD3EOgMAuJOCjRbQ2jaZns2Zv4z1CsEaW9IAAAAAAAAAAADDfli9DMYX-tHjOFNERMyd_Qs8mQ==";
        public string GeocoderUrl
        {
            get { return geocoderUrl; }
            set { geocoderUrl = value; }
        }

        public string MapsKey
        {
            get { return mapsKey; }
            set { mapsKey = value; }
        }

        public string GetStaticMapUrl(int h, int w, double lat, double lng) {
            return GetStaticMapUrl(h, w, lat, lng, YandexPointColor.Vv, YandexPointSize.L, 1);
        }

        public string GetStaticMapUrl(int h, int w, double lat, double lng, YandexPointColor color, YandexPointSize size, int pointNumber) {
            string style = "pm" + color + size + pointNumber;
            style = style.ToLower();
            return string.Format("http://static-maps.yandex.ru/1.x/?size={0},{1}&l=map&pt={2},{3},{4}&key={5}",
                                 h, w, lat.ToString("0.000000").Replace(',', '.'), lng.ToString("0.000000").Replace(',', '.'), style, mapsKey);
        }

        public string GetQueryUrl(string address)
        {
            var aa = HttpUtility.UrlEncode(address);
            return string.Format(GeocoderUrl, address, mapsKey);
        }
    }
}