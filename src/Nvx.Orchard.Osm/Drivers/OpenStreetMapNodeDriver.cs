using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nvx.Orchard.Osm.Models;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;

namespace Nvx.Orchard.Osm.Drivers
{
    public class OpenStreetMapNodeDriver : ContentPartDriver<OpenStreetMapNodePart> {
        protected override DriverResult Display(
            OpenStreetMapNodePart part, string displayType, dynamic shapeHelper) {

            return ContentShape("Parts_OsmMap", () => shapeHelper.Parts_OsmMap(
                Longitude: part.Longitude,
                Latitude: part.Latitude));
        }

        //GET
        protected override DriverResult Editor(
            OpenStreetMapNodePart part, dynamic shapeHelper) {

            return ContentShape("Parts_OsmMap_Edit",
                () => shapeHelper.EditorTemplate(
                    TemplateName: "Parts/OsmMap",
                    Model: part,
                    Prefix: Prefix));
        }
        //POST
        protected override DriverResult Editor(
            OpenStreetMapNodePart part, IUpdateModel updater, dynamic shapeHelper) {

            updater.TryUpdateModel(part, Prefix, null, null);
            return Editor(part, shapeHelper);
        }
    }
}
