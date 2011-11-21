using System;

namespace Nvx.Fields.MapInfrastructure {
    [Serializable]
    public class Location
    {
        public string Name { get; set; }
        public double Lattitude { get; set; }
        public double Longitude { get; set; }
    }
}