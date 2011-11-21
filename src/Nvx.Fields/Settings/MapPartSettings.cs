using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nvx.Fields.Settings
{
    public enum MapEngineType
    {
        Yandex,Google
    }

    public class MapPartSettings
    {
        public IEnumerable<dynamic> EngineTypes { get; set; }
        public MapEngineType Engine { get; set; }        
    }
}
