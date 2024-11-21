using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace EcoHome.EnergyInsights.Domain.Dtos
{

    public class UserConsumptionGoalDto
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public double Goal { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ValidUntil { get; set; }

        public class Validator : AbstractValidator<UserConsumptionGoalDto>
        {
            public Validator()
            {
                RuleFor(x => x.Category)
                    .NotEmpty().WithMessage("A categoria é obrigatória.")
                    .MaximumLength(50).WithMessage("A categoria deve ter no máximo 50 caracteres.");

                RuleFor(x => x.Goal)
                    .GreaterThan(0).WithMessage("A meta deve ser maior que 0.");

                RuleFor(x => x.ValidUntil)
                    .GreaterThanOrEqualTo(DateTime.UtcNow).WithMessage("A validade deve ser uma data futura.");
            }
        }
    }
}


