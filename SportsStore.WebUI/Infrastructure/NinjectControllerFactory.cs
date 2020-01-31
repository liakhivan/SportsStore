using System;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;
namespace SportsStore.WebUI.Infrastructure
{
    // реалізація користувальницької фобрики контроллерів,
    // наслідуючись від фабрики, яка використовується за замовчуванням
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel ninjectKernel;
        public NinjectControllerFactory()
        {
            // створення контроллера
            ninjectKernel = new StandardKernel();
            AddBindings();
        }
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            // отримання об'єкта контроллера з контейнера
            // використовуючи його тип
            return controllerType == null
                ? null
                : (IController)ninjectKernel.Get(controllerType);
        }
        private void AddBindings()
        {
            // конфігурування контейнера
        }
    }
}