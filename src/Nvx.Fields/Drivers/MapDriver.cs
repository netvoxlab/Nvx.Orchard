using System;
using Nvx.Fields.MapInfrastructure;
using Nvx.Fields.Models;
using Nvx.Fields.Settings;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;

namespace Nvx.Fields.Drivers
{
    public class MapDriver : ContentPartDriver<MapPart>
    {
        private static Random rdn = new Random();
        protected override DriverResult Display(
            MapPart part, string displayType, dynamic shapeHelper)
        {            
            return ContentShape("Parts_Map", () => shapeHelper.Parts_Map(
                Longitude: part.Longitude,
                Latitude: part.Latitude,
                ModelId: "YMapsID"+rdn.Next(int.MaxValue),
                Adress: part.Address));
        }

        //GET
        protected override DriverResult Editor(
            MapPart part, dynamic shapeHelper)
        {

            return ContentShape("Parts_Map_Edit",
                () => shapeHelper.EditorTemplate(
                    TemplateName: "Parts/Map",
                    Model: part,
                    Prefix: Prefix));
        }
        //POST
        protected override DriverResult Editor(
            MapPart part, IUpdateModel updater, dynamic shapeHelper)
        {
            var settings = part.Settings.GetModel<MapPartSettings>();
            
            if(updater.TryUpdateModel(part, Prefix, null, null)) {
                switch (settings.Engine) {
                    case MapEngineType.Yandex:
                        if (!string.IsNullOrEmpty(part.Address.Trim())) {
                            var loc = MapProcessor.GeocodeLocation(part.Address.Trim());
                            part.Latitude = loc.Lattitude;
                            part.Longitude = loc.Longitude;
                        }
                        break;
                    case MapEngineType.Google:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

            }
            return Editor(part, shapeHelper);
        }
    }
}
