using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoHome.EnergyInsights.Domain.Dtos
{
    public class EnergySavingTipDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; }

        public class Validator : AbstractValidator<EnergySavingTipDto>
        {
            public Validator()
            {
                RuleFor(x => x.Title)
                    .NotEmpty().WithMessage("O título da dica é obrigatório.")
                    .MaximumLength(100).WithMessage("O título deve ter no máximo 100 caracteres.");

                RuleFor(x => x.Description)
                    .NotEmpty().WithMessage("A descrição é obrigatória.")
                    .MaximumLength(500).WithMessage("A descrição deve ter no máximo 500 caracteres.");
            }
        }
    }
}
