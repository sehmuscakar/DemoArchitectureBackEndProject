using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Validation
{
    public class ValidationTool // buraya controllerda yapacağımız kodları burada yazacaz buna tool deniliyor validasyon işlemleri burada da olacağı için burayada ekle fluentvalidationu
    {
        public static void Validate(IValidator validator, object entity)
        {

            var context = new ValidationContext<object>(entity);//burda ilegili validasyon hatalarına gidecek
            var result= validator.Validate(context); //eğer bi sorun yoksa direk bunu döndürecek 
            if (!result.IsValid)//eğer bi sorun varsa zaten bu hataları yakalayacak
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}
