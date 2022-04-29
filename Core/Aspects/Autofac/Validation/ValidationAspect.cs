using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception//aspect - ben bir methodinterceptionım, ezmemi istediğin bir method var mı?
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType) //Bana validatortype ver demek
        {
            //defensive coding 
            //ValidatorType bir ValidatorType mı?
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception("Bu bir validator class değil");
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)//sadece onbefore çalışır
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType); //reflection - çalışma anında bir şeyleri çalıştırabilmemizi sağlıyor - productvalidator'un bir instance oluştur/şu an elimizde ProductValidator instance var, newledi.
            var entityType = _validatorType.BaseType.GetGenericArguments()[0]; //productvalidator'un çalıma tipini bul - Product
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);///methodun argümanlarını gez, ordaki biri veya birileri benim tipime eşitse validate et
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
