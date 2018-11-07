using SuperoTasks.WebAPICore.Domain;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperoTasks.WebAPICore.Services.Validator
{
    public class BoardValidator : AbstractValidator<Board>
    {

        public BoardValidator()
        {
            //RuleFor(c => c.Name)
            //    .Length(1, 100)
            //    .NotEmpty().WithMessage("É necessário informar o nome.")
            //    .NotNull().WithMessage("É necessário informar o nome");
        }

    }
}
