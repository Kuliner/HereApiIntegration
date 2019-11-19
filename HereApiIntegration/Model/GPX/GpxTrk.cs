using System.Collections.Generic;
using System.Xml.Serialization;

namespace HereApiIntegration.Model.GPX
{
    /// <remarks/>
    [System.Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.topografix.com/GPX/1/0")]
    public partial class GpxTrk
    {

        [XmlArray("trkseg")]
        [XmlArrayItem(ElementName = "trkpt")]
        public List<GpxTrkTrkpt> Trkseg { get; set; }
    }


}
