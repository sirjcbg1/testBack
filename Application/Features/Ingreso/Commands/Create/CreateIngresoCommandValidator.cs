using FluentValidation;

namespace Application.Features.Ingreso.Commands.Create
{
    public class CreateIngresoCommandValidator :AbstractValidator<CreateIngresoCommand>
    {
        public CreateIngresoCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacio")
                .MaximumLength(20).WithMessage("{PropertyName} no debe de exceder de {MaxLength}");

            RuleFor(p => p.LastName)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacio")
                .MaximumLength(20).WithMessage("{PropertyName} no debe de exceder de {MaxLength}");

            RuleFor(p => p.Identification)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacio");

            RuleFor(p => p.House)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacio")
                .MaximumLength(30).WithMessage("{PropertyName} no debe de exceder de {MaxLength}");

            RuleFor(p => p.FechaNacimiento)
                .NotEmpty().WithMessage("{No puede ser vacio");

            //RuleFor(p => p.Email)
            //    .NotEmpty().WithMessage("{PropertyName} no puede ser vacio")
            //    .EmailAddress().WithMessage("{PropertyName} debe ser una propiedad de valida")
            //    .MaximumLength(80).WithMessage("{PropertyName} no debe de exceder de {MaxLength}");

            //RuleFor(p => p.Telefono)
            //    .Matches(@"^\d{4}-\d{4}$").WithMessage("{PropertyName} debe cumplir con el formato 0000-0000")
            //    .MaximumLength(9).WithMessage("{PropertyName} no debe de exceder de {MaxLength}");

        }
    }
}
