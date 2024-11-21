using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoHome.EnergyInsights.Domain.Dtos
{
    public class ReportDto
    {
        public int Id { get; set; }
        public string ReportType { get; set; }
        public string Data { get; set; }
        public DateTime GeneratedAt { get; set; }

        public class Validator : AbstractValidator<ReportDto>
        {
            public Validator()
            {
                RuleFor(x => x.ReportType)
                    .NotEmpty().WithMessage("O tipo do relatório é obrigatório.")
                    .MaximumLength(50).WithMessage("O tipo do relatório deve ter no máximo 50 caracteres.");

                RuleFor(x => x.Data)
                    .NotEmpty().WithMessage("Os dados do relatório são obrigatórios.");

                RuleFor(x => x.GeneratedAt)
                    .NotEmpty().WithMessage("A data de geração é obrigatória.");
            }
        }
    }
}
