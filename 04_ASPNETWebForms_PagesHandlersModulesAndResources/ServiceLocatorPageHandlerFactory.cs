using System;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using TodoList.WithIoC.IoC;

namespace _04_ASPNETWebForms_PagesHandlersModulesAndResources
{
    //Taken from: http://www.cuttingedge.it/blogs/steven/pivot/entry.php?id=81
    public class ServiceLocatorPageHandlerFactory : PageHandlerFactory
    {
        private static object GetInstance(Type type)
        {
            return ServiceLocator.GetInstance(type);
        }

        public override IHttpHandler GetHandler(HttpContext context, string requestType, string virtualPath, string path)
        {
            var handler = base.GetHandler(context, requestType, virtualPath, path);

            if (handler != null)
            {
                InitializeInstance(handler);
                HookChildControlInitialization(handler);
            }

            return handler;
        }

        private void HookChildControlInitialization(object handler)
        {
            Page page = handler as Page;

            if (page != null)
            {
                // Child controls are not created at this point.
                // They will be when PreInit fires.
                page.PreInit += (s, e) => InitializeChildControls(page);
            }
        }

        private static void InitializeChildControls(Control contrl)
        {
            var childControls = GetChildControls(contrl);

            foreach (var childControl in childControls)
            {
                InitializeInstance(childControl);
                InitializeChildControls(childControl);
            }
        }

        private static Control[] GetChildControls(Control ctrl)
        {
            var flags = BindingFlags.Instance | BindingFlags.NonPublic;

            return (
                from field in ctrl.GetType().GetFields(flags)
                let type = field.FieldType
                where typeof(UserControl).IsAssignableFrom(type)
                let userControl = field.GetValue(ctrl) as Control
                where userControl != null
                select userControl).ToArray();
        }

        private static void InitializeInstance(object instance)
        {
            Type pageType = instance.GetType().BaseType;

            var ctor = GetInjectableConstructor(pageType);

            if (ctor != null)
            {
                try
                {
                    var args = GetMethodArguments(ctor);

                    ctor.Invoke(instance, args);
                }
                catch (Exception ex)
                {
                    var msg = string.Format("The type {0} " +
                        "could not be initialized. {1}", pageType,
                        ex.Message);

                    throw new InvalidOperationException(msg, ex);
                }
            }
        }

        private static ConstructorInfo GetInjectableConstructor(Type type)
        {
            var overloadedPublicConstructors = (
                from ctor in type.GetConstructors()
                where ctor.GetParameters().Length > 0
                select ctor).ToArray();

            if (overloadedPublicConstructors.Length == 0)
            {
                return null;
            }

            if (overloadedPublicConstructors.Length == 1)
            {
                return overloadedPublicConstructors[0];
            }

            throw new Exception(string.Format(
                "The type {0} has multiple public overloaded " +
                "constructors and can't be initialized.", type));
        }

        private static object[] GetMethodArguments(MethodBase method)
        {
            return (
                from parameter in method.GetParameters()
                let parameterType = parameter.ParameterType
                select GetInstance(parameterType)).ToArray();
        }
    }
}