using System;

namespace DABE.Core.Entities
{
    public class Post
    {
        public virtual long Id { get; private set; }
        public virtual string Title { get; set; }
        public virtual DateTime Date { get; set; }
        
    }
}