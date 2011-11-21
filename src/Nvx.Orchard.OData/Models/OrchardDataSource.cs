using Orchard.ContentManagement;

namespace Nvx.Orchard.OData.Models {
    public class OrchardDataSource
    {
        public IContentManager ContentManager { get; set; }

        public OrchardDataSource(IContentManager manager) {
            ContentManager = manager;
        }
    }
}