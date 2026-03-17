using ApiProdutos.Domain.Abstractions.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiProdutos.Domain.Abstractions.Repositories
{
    public interface IRepository<TEntity> : IOperations<TEntity> where TEntity : EntityBase
    {
      
    }
}
