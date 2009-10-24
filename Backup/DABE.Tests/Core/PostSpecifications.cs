using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DABE.Core.Queries;
using Machine.Specifications;

namespace DABE.Tests.Core
{
    public class when_requesting_a_list_of_posts
    {
        Establish context = () =>
        {
                        
        };

        Because of = () =>
        {
            var posts = postQuery.Execute(); 
        };

        It should_return_a_list_of_posts;
        
        static PostQuery postQuery;
    }
}