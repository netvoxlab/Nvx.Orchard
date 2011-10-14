using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Orchard.UI.Resources;

namespace Nvx.Orchard.Osm
{
    public class ResourceManifest : IResourceManifestProvider
    {
        public void BuildManifests(ResourceManifestBuilder builder) {
            var manifest = builder.Add();

            manifest.DefineScript("Nvx_Orchard_Osm").SetUrl("nvx.orchard.osm.js", "nvx.orchard.osm.js").SetVersion("0.0.1").SetDependencies("jQuery");
        }
    }
}
