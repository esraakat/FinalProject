﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Validation
{
    public static class ValidationTool //bu tür araçlar static oluşturulur, tek bir instance oluşturulur, uygulama belleği sadece onu kullanır
    {
        public static void Validate(IValidator validator, object entity)//IValidator - ProductValidator - doğrulama kuralları burada ---- entity - product - doğrulanacak
        {
            var context = new ValidationContext<object>(entity); //entity için doğrulama yapıcam diyorum
            var result = validator.Validate(context);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}
