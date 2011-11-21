using System.ComponentModel.DataAnnotations;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Records;

namespace Nvx.Fields.Models
{
    public class MapRecord : ContentPartRecord
    {
        public virtual double Latitude { get; set; }
        public virtual double Longitude { get; set; }
        public virtual string Address { get; set; }
    }

    public class MapPart : ContentPart<MapRecord>
    {
        public string Address
        {
            get { return Record.Address; }
            set { Record.Address = value ?? string.Empty; }
        }
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
    }
}