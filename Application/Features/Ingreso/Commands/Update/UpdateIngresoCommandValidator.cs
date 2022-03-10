using FluentValidation;

namespace Application.Features.Ingreso.Commands.Update
{
    public class UpdateIngresoCommandValidator :AbstractValidator<UpdateIngresoCommand>
    {
        public UpdateIngresoCommandValidator()
        {
            RuleFor(p => p.Nombre)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacio")
                .MaximumLength(80).WithMessage("{PropertyName} no debe de exceder de {MaxLength}");

            RuleFor(p => p.FechaNacimiento)
                .NotEmpty().WithMessage("{No puede ser vacio");

        }
    }
}
