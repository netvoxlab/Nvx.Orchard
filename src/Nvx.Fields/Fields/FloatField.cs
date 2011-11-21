using System;
using System.Globalization;
using Orchard.ContentManagement;
using Orchard.ContentManagement.FieldStorage;
using Orchard.Environment.Extensions;

namespace Nvx.Fields {
    [OrchardFeature("FloatField")]
    public class FloatField : ContentField
    {
        public float FloatValue {
            get {
                return Storage.Get<float>();               
            }

            set {
                Storage.Set(value);
            }
        }
    }
}