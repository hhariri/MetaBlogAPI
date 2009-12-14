using System.Collections.Generic;
using Iesi.Collections.Generic;

namespace DABE.Core.Entities
{
    public class Category
    {
        public virtual long Id { get; private set; }
        public virtual string Description { get; set; }
        public virtual string HtmlUrl { get; set; }
        public virtual string RssUrl { get; set; }
        public virtual Blog Blog { get; set; }

        public virtual bool Equals(Category other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other.Description == Description;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (Category)) return false;
            return Equals((Category) obj);
        }

        public override int GetHashCode()
        {
            return Description.GetHashCode();
        }
    }
}