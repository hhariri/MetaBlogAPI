using System;

namespace DABE.Core.Entities
{
    public class Post
    {
        public virtual long Id { get; private set; }
        public virtual string Title { get; set; }
        public virtual DateTime Date { get; set; }
        public virtual Blog Blog { get; set; }

        public virtual bool Equals(Post other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.Title, Title);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (Post)) return false;
            return Equals((Post) obj);
        }

        public override int GetHashCode()
        {
            return (Title != null ? Title.GetHashCode() : 0);
        }
    }
}