using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using SecurityDevelopment.DTO;

namespace SecurityDevelopment.Validators
{
    public class DebetCardValidator : AbstractValidator<DebetCardDTO>
    {
        public DebetCardValidator()
        {
            var msg = "Ошибка в поле {PropertyName}: значение {PropertyValue}";

            RuleFor(c => c.Number)
            .Must(c => c.All(Char.IsDigit)).WithMessage(msg);

            RuleFor(c => c.CVC)
            .Must(c => c.All(Char.IsDigit)).WithMessage(msg);

            RuleFor(c => c.Balance)
             .GreaterThan(0).WithMessage(msg);

            RuleFor(c => c.DateFrom)
            .Must(BeAValidDate).WithMessage(msg);

            RuleFor(c => c.DateTo)
            .Must(BeAValidDate).WithMessage(msg);

        }

        private bool BeAValidDate(DateTime date)
        {
            return !date.Equals(default(DateTime));
        }
    }
}

