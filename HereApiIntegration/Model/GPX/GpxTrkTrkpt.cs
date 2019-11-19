namespace HereApiIntegration.Model.GPX
{
    /// <remarks/>
    [System.Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.topografix.com/GPX/1/0")]
    public partial class GpxTrkTrkpt
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute(AttributeName = "lat")]
        public decimal Lat { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute(AttributeName = "lon")]
        public decimal Lon { get; set; }
    }


}
