using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Records;

namespace Nvx.Orchard.Osm.Models
{
    public class OpenStreetMapNodeRecord : ContentPartRecord
    {
        public virtual double Latitude { get; set; }
        public virtual double Longitude { get; set; }
        public virtual long NodeId { get; set; }
    }

    public class OpenStreetMapNodePart : ContentPart<OpenStreetMapNodeRecord>
    {
        [Required]
        public double Latitude
        {
            get { return Record.Latitude; }
            set { Record.Latitude = value; }
        }

        [Required]
        public double Longitude
        {
            get { return Record.Longitude; }
            set { Record.Longitude = value; }
        }

        [Required]
        public long NodeId
        {
            get { return Record.NodeId; }
            set { Record.NodeId = value; }
        }

        public int Id { get { return Record.Id; } }
        public string LatitudeJS { get { return string.Format(System.Globalization.CultureInfo.InvariantCulture, "{0}", Latitude); } }
        public string LongitudeJS { get { return string.Format(System.Globalization.CultureInfo.InvariantCulture, "{0}", Longitude); } }
    }
}
