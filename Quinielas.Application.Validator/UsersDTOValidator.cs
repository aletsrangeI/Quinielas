using FluentValidation;
using Quinielas.Application.DTO;

namespace Quinielas.Application.Validator
{
    public class UsersDTOValidator : AbstractValidator<UserDTO>
    {
        public UsersDTOValidator() 
        {
            RuleFor(x => x.UserName).NotNull().NotEmpty();
            RuleFor(x => x.Password).NotNull().NotEmpty();
        }
    }
}
