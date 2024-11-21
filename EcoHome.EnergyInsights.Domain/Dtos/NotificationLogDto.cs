using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace EcoHome.EnergyInsights.Domain.Dtos
{
    public class NotificationLogDto
    {
        public int Id { get; set; }
        public string NotificationType { get; set; }
        public string Message { get; set; }
        public DateTime SentAt { get; set; }
        public bool IsRead { get; set; }

        public class Validator : AbstractValidator<NotificationLogDto>
        {
            public Validator()
            {
                RuleFor(x => x.NotificationType)
                    .NotEmpty().WithMessage("O tipo de notificação é obrigatório.")
                    .MaximumLength(50).WithMessage("O tipo de notificação deve ter no máximo 50 caracteres.");

                RuleFor(x => x.Message)
                    .NotEmpty().WithMessage("A mensagem é obrigatória.")
                    .MaximumLength(500).WithMessage("A mensagem deve ter no máximo 500 caracteres.");
            }
        }
    }

}
