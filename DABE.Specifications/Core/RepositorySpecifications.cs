using System;
using System.Collections.Generic;
using System.Linq;
using DABE.Core.Entities;
using DABE.Core.Repositories;
using DABE.Specifications.Helpers;
using Machine.Specifications;

namespace DABE.Specifications.Core
{
    public class when_retrieving_a_blog_with_valid_id: with_predefined_blogs 
    {
        Establish context = () =>
        {
            blogRepository = new BlogRepository(); 
        };

        Because of = () =>
        {
            blog = blogRepository.GetById(blog1_id);                               
        };

        It should_return_correct_blog_entry = () =>
        {
            blog.Id.ShouldEqual(blog1_id);
            blog.Name.ShouldEqual(blog1_name);
        };

        static Blog blog;
        static IBlogRepository blogRepository;
    }

    public class when_retrieving_a_blog_with_invalid_id: with_predefined_blogs
    {
        Establish context = () =>
        {

            blogRepository = new BlogRepository();
        };

        Because of = () =>
        {
            blog = blogRepository.GetById(2);
        };

        It should_return_null = () =>
        {
            blog.ShouldBeNull();
        };

        static Blog blog;
        static IBlogRepository blogRepository;
        
    }

    public class when_retrieving_a_list_of_blogs: with_predefined_blogs
    {
        Establish context = () =>
        {
            blogRepository = new BlogRepository();
        };

        Because of = () =>
        {
            blogs = blogRepository.GetAll().ToList();
        };

        It should_return_list_of_blogs = () =>
        {
	        blogs.Count().ShouldEqual(3);
        };

        static IList<Blog> blogs;
        static IBlogRepository blogRepository;

    }

    public class when_retrieving_a_list_of_blogs_of_a_specific_user: with_predefined_blogs
    {
        Establish context = () =>
        {
            blogRepository = new BlogRepository();
        };

        Because of = () =>
        {
            blogs = blogRepository.GetAll(x => x.User.Username == blog1_username).ToList();
        };

        It should_return_all_blogs_of_that_user = () =>
        {
            blogs.Count().ShouldEqual(2);
            blogs[0].Name.ShouldEqual(blog1_name);
        };

        static IList<Blog> blogs;
        static IBlogRepository blogRepository;

    }

    public class when_retrieving_posts_by_blog_name: with_x_predefined_blogs_and_posts
    {
        Establish context = () =>
        {

            postRepository = new PostRepository();
        };

        Because of = () =>
        {
            posts = postRepository.GetAll().Where(x => x.Blog.Name == String.Format("Blog{0}", 5)).ToList();
        };

        It should_retrieve_blog_posts = () =>
        {
            posts.Count.ShouldEqual(1000);
        };

        static IList<Post> posts;
        static IPostRepository postRepository;
        
    }

    public class when_retrieving_categories_of_a_blog: with_predefined_blogs
    {
        Establish context = () =>
        {
            blogRepository = new BlogRepository();
        };

        Because of = () =>
        {
            blogs = blogRepository.GetAll(x => x.Name == blog1_name).ToList();
        };

        It should_return_all_categories_for_the_blog = () =>
        {
            blogs[0].Categories.Count.ShouldEqual(3);
        };

        static IList<Blog> blogs;
        static IBlogRepository blogRepository;

        
    }
}
