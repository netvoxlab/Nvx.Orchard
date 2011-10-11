using Orchard.ContentManagement;

namespace Nvx.Orchard.OData.Models {
    public class DataSource
    {
        public IContentManager ContentManager { get; set; }

        public DataSource(IContentManager manager) {
            ContentManager = manager;
        }
    }
}