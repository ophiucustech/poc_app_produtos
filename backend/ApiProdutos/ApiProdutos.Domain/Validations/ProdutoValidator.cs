using ApiProdutos.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiProdutos.Domain.Validations
{
    public class ProdutoValidator : AbstractValidator<Produto>
    {
        public ProdutoValidator()
        {
            RuleFor(r => r.Nome)
               .NotNull().WithMessage("Nome é obrigatório")
               .MaximumLength(30).WithMessage("Campo nome tem tamanho máximo de 30 caracteres");

            RuleFor(r => r.Quantidade)
              .NotNull().WithMessage("Quantidade é obrigatório")
             .GreaterThan(0).WithMessage("Quantidade precisa ser maior que zero");

            RuleFor(r => r.Preco)
             .NotNull().WithMessage("Valor é obrigatório")
             .GreaterThan(0).WithMessage("Valor precisa ser maior que zero");

        }
    }
}
