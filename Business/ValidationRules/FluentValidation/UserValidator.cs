using Enitities.Dtos;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<RegisterAuthDto>
    {
        public UserValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("kullanıcı adı boş olamaz");
            RuleFor(p => p.Email).NotEmpty().WithMessage("Mail adresi boş olamaz");
            RuleFor(p => p.ImageUrl).NotEmpty().WithMessage("Kullanıcı resmi boş olamaz");
            RuleFor(p => p.Password).NotEmpty().WithMessage("Şifre boş olamaz");
            RuleFor(p => p.Password).MinimumLength(6).WithMessage("Şifre en az 6 karekter olmalıdır.");
        }

    }
}
