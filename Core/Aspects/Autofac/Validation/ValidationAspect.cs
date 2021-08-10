using Core.Utilities.Interceptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using FluentValidation;

namespace Core.Aspects.Autofac.Validation
{

    public class ValidationAspect :  MethodInterception //Manager'daki Attribute(ValidationAspect)'nin attribute olduğunun anlaşılması için MethodInterception' dan inherit ederiz.
    {
        private Type _validatorType;

        public ValidationAspect(Type validatorType) //Attribute'de Type ile geçilir. (Bana bir validator tipi ver)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType)) 
            {
                throw new System.Exception("Bu bir doğrulama sınıfı değildiir"); // bu bir validator değildir.
            }

            _validatorType = validatorType;

        }
        // MethodInterception'ın içerisinde boş OnBefore var oraya gönderdik.
        protected override void OnBefore(IInvocation invocation)
        {
            //Reflection = çalışma anında birşeyleri new'lememize yarar.
            var validator = (IValidator)Activator.CreateInstance(_validatorType); //Aldığın tipdeki validator'un bir instance(örneğini) oluştur.

            var entityType = _validatorType.BaseType.GetGenericArguments()[0]; //Sana gelen validator'un BaseType'nin çalışma tipini bul.

            var entities = invocation.Arguments.Where(t => t.GetType() == entityType); // onun parametrelerini bul.
                                                                                       // invocation = method demektir.

            // herbirini tek tek gez
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity); //ValidationTool'u kullanarak validate et.
            }
        }
    }



}
