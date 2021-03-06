using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace ARMLParsing
{
    public class config
    {
        [XmlElement("tracker")]
        public TrackerLink trackerLink;
    }

    public class TrackerLink {

        [XmlAttribute("href", Namespace = "http://www.w3.org/1999/xlink", Form = XmlSchemaForm.Qualified)]
        public string href;

        [XmlElement("src")]
        public string src;
    }
}
