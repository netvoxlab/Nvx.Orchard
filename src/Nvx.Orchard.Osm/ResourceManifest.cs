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

            manifest.DefineScript("jQuery_Jump").SetUrl("jump.min.js", "jump.min.js").SetVersion("0.0.2").SetDependencies("jQuery");
        }
    }
}
