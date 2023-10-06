using Castle.DynamicProxy;

namespace LibraryAPI.Core.Utilities.Interceptors
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public abstract class MethodInterceptionBaseAttribute : Attribute, IInterceptor
    {
        public int Priority { get; set; }//öncelikk hangisi önce calıssın

        public virtual void Intercept(IInvocation invocation)
        {

        }
    }
}
