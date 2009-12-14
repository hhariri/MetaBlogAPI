using System;
using System.Collections.Generic;
using Iesi.Collections.Generic;

namespace DABE.Core.Entities
{
    public class Blog
    {
        ISet<Post> _posts = new HashedSet<Post>();
        ISet<Category> _categories = new HashedSet<Category>();

        public virtual long Id { get; private set; }
        public virtual string Name { get; set; }
        public virtual string Url { get; set; }
        public virtual User User { get; set; }
        
        public virtual ISet<Post> Posts
        {
            get { return _posts; 
                 }
            set { _posts = value;  }
        }

        public virtual ISet<Category> Categories
        {
            get { return _categories; }
            set { _categories = value;}
        }

        public virtual void AddPost(Post post)
        {
            _posts.Add(post);
        }

        public virtual void RemovePost(Post post)
        {
            _posts.Remove(post);
        }

        public virtual void AddCategory(Category category)
        {
            _categories.Add(category);
        }

        public virtual void RemoveCategory(Category category)
        {
            _categories.Remove(category);
        }
    }
}