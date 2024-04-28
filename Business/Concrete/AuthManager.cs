using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Hashing;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using Enitities.Dtos;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AuthManager : IAuthService // bunu Kayıt işlemi için kullanacaz 
    {
        private readonly IUserService _UserService;

        public AuthManager(IUserService userService)
        {
            _UserService = userService;
        }

        public string Login(LoginAuthDto loginDto)
        {
           var user=_UserService.GetByEmail(loginDto.Email);
            var result=HashingHelper.VerifyPasswordHash(loginDto.Password,user.PasswordHash,user.PasswordSalt);
            if (result)
            {
                return "Kullanıcı girişi başarılı";
            }
            return "Kullanıcı bilgileri hatalı";
        }

        public IResult Register(RegisterAuthDto registerDto)
        {

          int imgSize = 2;
            UserValidator userValidator = new UserValidator();
            ValidationTool.Validate(userValidator, registerDto); // toolda yazdığımız kodları buraya getirmiş gibi olduk

            IResult result = BusinessRules.Run(
                CheckIfEmailExists(registerDto.Email),
                CheckIfImageSizeIsLessThanOneMb(imgSize)
                );



            IResult resultEmail=CheckIfEmailExists(registerDto.Email);
           // Result result = new Result(true, "Kullanıcı kaydı başarıyla tamamalandı."); // burda result classında constractır kullanıdğımız için burda paremetre gönderebildik.
            if (resultEmail.Success)
            {
                IResult resultImage = CheckIfImageSizeIsLessThanOneMb(imgSize); // resim boyutunu kontrol ediyor.
                if (resultImage.Success)
                {
                    _UserService.Add(registerDto);
                    return new SuccessResult("Kullanıcı kaydı başarıyla tamamlandı");
                }
                else
                {
                    return resultImage;
                }
            }
            return resultEmail;
        }

        private IResult CheckIfEmailExists(string email) // girilen mail adresi daha önce girilmiş mi yoksa girilmemişmi onu kontrol edecek bu metot
        {
            var list=_UserService.GetByEmail(email);
            if (list!=null)//eğer bunun içinde bir kullanıcı ulduysa bana null dönsün
            {
                return new ErrorResult("Bu mail adresi daha önce kullanılmış");
            }
            return new SuccessResult();
        }


        private IResult CheckIfImageSizeIsLessThanOneMb(int imgSize)
        {
            if (imgSize>1)
            {
                return new ErrorResult("Yüklediğiniz resmin boyutu en fazla 1mb olmalıdır.");
            }
            return new SuccessResult();
        }
    }
}
