using Nvx.Fields.Models;
using Orchard.ContentManagement.Handlers;
using Orchard.Data;

namespace Nvx.Fields.Handlers
{
    public class MapHandler : ContentHandler
    {
        public MapHandler(IRepository<MapRecord> repository)
        {
            Filters.Add(StorageFilter.For(repository));
        }
    }
}
