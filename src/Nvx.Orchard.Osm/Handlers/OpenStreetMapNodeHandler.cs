using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nvx.Orchard.Osm.Models;
using Orchard.ContentManagement.Handlers;
using Orchard.Data;

namespace Nvx.Orchard.Osm.Handlers
{
    public class OpenStreetMapNodeHandler : ContentHandler
    {
        public OpenStreetMapNodeHandler(IRepository<OpenStreetMapNodeRecord> repository)
        {
            Filters.Add(StorageFilter.For(repository));
        }

        private static volatile int mapId = 0;

        public static string GetNextUniqueMapControlId() {
            return "map"+ (++mapId);
        }
    }
}
