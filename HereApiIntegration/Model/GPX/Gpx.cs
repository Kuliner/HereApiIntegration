using System;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HereApiIntegration.Model.GPX
{

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.topografix.com/GPX/1/0")]
    [System.Xml.Serialization.XmlRoot(Namespace = "http://www.topografix.com/GPX/1/0", IsNullable = false)]
    public partial class Gpx
    {

        /// <remarks/>
        [XmlElement(ElementName = "trk")]
        public GpxTrk Trk { get; set; }

        /// <remarks/>
        [XmlElement(ElementName = "version")]
        public decimal Version { get; set; }
    }
}
