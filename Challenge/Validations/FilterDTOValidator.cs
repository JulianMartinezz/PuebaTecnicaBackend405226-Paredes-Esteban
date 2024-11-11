using Challenge.DTO;
using FluentValidation;

namespace Challenge.Validations
{
    public class FilterDTOValidator : AbstractValidator<FilterDTO>
    {
        public FilterDTOValidator() 
        {
            RuleFor(x => x.Page)
                .NotEmpty()
                .WithMessage("El numero de pagina es obligatorio")
                .NotNull()
                .WithMessage("El numero de pagina no puede ser nulo");
            RuleFor(x => x.PageSize)
                .NotEmpty()
                .WithMessage("El tamaño de pagina es obligatorio")
                .NotNull()
                .WithMessage("El tamaño de pagina no puede ser nulo");
        }
    }
}
