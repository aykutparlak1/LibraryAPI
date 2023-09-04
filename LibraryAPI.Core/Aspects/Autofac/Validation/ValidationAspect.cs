﻿using Castle.DynamicProxy;
using FluentValidation;
using LibraryAPI.Core.CrossCuttingConcerns.Validation;
using LibraryAPI.Core.Utilities.Intercepters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception("WrongValidationType");
            }
            // (AspectMessages.WrongValidationType)
            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {

            //reflection eğer  cağrılırsa validatorun ınstance olusuturoyr
            //daha sonra validötrün generic typini bul ve ardından parametrelerini bul
            // entitytype olan herbirini tek tek gez ve toolu kulanarak validate et

            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
