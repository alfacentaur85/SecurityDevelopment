using System;
using System.Linq;
using FluentValidation;
using SecurityDevelopment.DTO;

namespace SecurityDevelopment.Validators
{

    public class PersonValidator : AbstractValidator<PersonDTO>
    {
        public PersonValidator()
        {
            var msg = "Ошибка в поле {PropertyName}: значение {PropertyValue}";

            RuleFor(c => c.FirstName)
            .Must(c => c.All(Char.IsLetter)).WithMessage(msg);

            RuleFor(c => c.Surname)
            .Must(c => c.All(Char.IsLetter)).WithMessage(msg);

            RuleFor(c => c.Birthday)
            .Must(BeAValidDate).WithMessage(msg);

        }

        private bool BeAValidDate(DateTime date)
        {
            return !date.Equals(default(DateTime));
        }
    }
}
