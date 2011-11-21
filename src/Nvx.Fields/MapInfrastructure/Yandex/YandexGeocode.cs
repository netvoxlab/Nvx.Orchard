using System;
using System.Net;
using System.Text;
using System.Xml;

namespace Nvx.Fields.MapInfrastructure.Yandex {
    public class YandexGeocode : IGeocode {
        private readonly YandexSettings settings;

        public YandexGeocode() : this(new YandexSettings()) { }

        public YandexGeocode(YandexSettings settings)
        {
            this.settings = settings;
        }

        public Location GetLocation(string adress)
        {
            var url = settings.GetQueryUrl(adress);
            var wc = new WebClient();
            var res = wc.DownloadString(url);
            //Console.WriteLine(res);

            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(res);

            XmlNamespaceManager nsMgr = new XmlNamespaceManager(xmlDoc.NameTable);
            nsMgr.AddNamespace("tns", "http://www.opengis.net/gml");
            nsMgr.AddNamespace("x", "http://www.yandex.ru/xscript");
            nsMgr.AddNamespace("xi", "http://www.w3.org/2001/XInclude");

            XmlNodeList selectedNodes = xmlDoc.SelectNodes("//tns:pos", nsMgr);
            double lat = 0, lng = 0;
            if (selectedNodes != null)
                foreach (XmlNode selectedNode in selectedNodes)
                {
                    var loc = selectedNode.InnerText.Replace('.', ',').Split(' ');
                    lat = double.Parse(loc[0]);
                    lng = double.Parse(loc[1]);
                    break;
                }
            return new Location { Lattitude = lat, Longitude = lng, Name = adress };
        }

        public string GetMapUrl(int h, int w, Location point) {
            return settings.GetStaticMapUrl(h, w, point.Lattitude, point.Longitude);
        }

        public string MakeMap(string controlid) {
            return string.Format("http://api-maps.yandex.ru/1.1/index.xml?key={0}", settings.MapsKey);
        }

        public string AddPoint(string controlid, double lat, double lng, string label) {
            var sb = new StringBuilder();
            /*sb.AppendFormat(@" <script type=""text/javascript"">
YMaps.jQuery(function () {
            var map = new YMaps.Map(YMaps.jQuery(#" + controlid + @")[0]);            
            var placemark = new YMaps.Placemark(new YMaps.GeoPoint({0}, {1}));
            placemark.name = ""{2}"";
            placemark.description = ""{2}"";

            // Задает содержимое балуна наиболее приоритетным способом
            placemark.setBalloonContent(""<div>{2}</div>"");

            map.addOverlay(placemark);

            // Открывает балун с надписью: <div>Новое описание метки</div>
            placemark.openBalloon();
        })
    </script>", lat.ToString().Replace(',', '.'), lng.ToString().Replace(',', '.'), label);*/
            return sb.ToString();
        }
    }
}