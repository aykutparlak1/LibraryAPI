using Castle.DynamicProxy;
using LibraryAPI.Core.Utilities.Interceptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace LibraryAPI.Core.Aspects.Autofac.Transaction
{
    public class TransactionAspect : MethodInterception
    {
        public override void Intercept(IInvocation invocation)
        {
            using TransactionScope transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);

            
            try
            {
                invocation.Proceed();
                transactionScope.Complete();
            }
            catch (System.Exception e)
            {
                transactionScope.Dispose();
               
                throw;
            
            } 
        } 
    } 
}

            
