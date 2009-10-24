using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DABE.Core.Entities;
using DABE.Core.Queries;
using DABE.Core.Repositories;
using DABE.Specifications.Helpers;
using Machine.Specifications;


namespace DABE.Specifications.Core
{
    public class when_requesting_a_list_of_posts: with_predefined_posts
    {
        Establish context = () =>
        {
            postRepository = new PostRepository();
        };

        Because of = () =>
        {
            posts = postRepository.GetPosts().List<Post>();

        };

        It should_return_a_list_of_posts = () =>
        {
            posts.Count.ShouldEqual(2);
        };

        static IList<Post> posts;
        static IPostRepository postRepository;
    }

    public class when_requesting_a_post_by_id: with_predefined_posts
    {
        Establish context = () =>
        {
            postRepository = new PostRepository();
        };

        Because of = () =>
        {
            post = postRepository.GetPostById(post1_id);
        };

        It should_return_correct_post = () =>
        {
            post.ShouldNotBeNull();
        };

        static IPostRepository postRepository;
        static Post post;
    }
}