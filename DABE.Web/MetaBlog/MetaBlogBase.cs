using System.Xml.Linq;

namespace DABE.Web.MetaBlog
{
    public abstract class MetaBlogBase
    {
        public abstract void Load(XDocument data);
    }
}