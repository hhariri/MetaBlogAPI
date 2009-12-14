using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace DABE.Web.MetaBlog
{
    public class MetaBlogUserInfoRequest: MetaBlogRequestCommon
    {
        public MetaBlogUserInfoRequest(IList<XElement> paramNodes) : base(paramNodes)
        {
        }
    }
}