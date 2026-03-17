using ApiProdutos.Domain.Abstractions.Entities;
using ApiProdutos.Domain.Abstractions.Repositories;
using ApiProdutos.Domain.Abstractions.Services;
using ApiProdutos.Domain.Entities;
using ApiProdutos.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiProdutos.Application.Services
{
    public class ProdutoService : ApplicationService<IProdutoRepository, Produto, ProdutoValidator>, IProdutoService
    {
        public ProdutoService(IProdutoRepository repository) : base(repository)
        {
        }
    }
}
