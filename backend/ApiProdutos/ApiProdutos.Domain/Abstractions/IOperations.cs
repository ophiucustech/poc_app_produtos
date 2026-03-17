using ApiProdutos.Domain.Abstractions.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiProdutos.Domain.Abstractions
{
    public interface IOperations<TEntity> where TEntity : EntityBase
    {
        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetAsync(int id);
        Task DeleteAsync(int id);
    }
}
