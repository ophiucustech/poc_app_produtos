using ApiProdutos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiProdutos.Domain.Abstractions.Repositories
{
    public interface IProdutoRepository : IRepository<Produto>
    {
    }
}
