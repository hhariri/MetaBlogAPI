using System;
using System.Collections.Generic;
using DABE.Core.Entities;

namespace DABE.Core.Repositories
{
    public class BlogRepository : Repository<Blog, long>, IBlogRepository { }
}