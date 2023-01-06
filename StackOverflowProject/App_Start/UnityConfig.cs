using System.Web.Http;
using Unity;
using Unity.WebApi;
using Unity.Mvc5;
using StackOverflowProject.ServiceLayer;
using System.Web.Mvc;

namespace StackOverflowProject
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterType<IQuestionService, QuestionService>();
            container.RegisterType<IUsersService, UsersService>();
            DependencyResolver.SetResolver(new Unity.Mvc5.UnityDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
        }
    }
}