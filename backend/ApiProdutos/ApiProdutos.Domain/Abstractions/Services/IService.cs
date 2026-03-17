using ApiProdutos.Domain.Abstractions.Entities;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace ApiProdutos.Domain.Abstractions.Services
{
    public interface IService<TEntity> : IOperations<TEntity> where TEntity : EntityBase
    {
    }
}
