using ApiProdutos.Domain.Abstractions.Entities;
using ApiProdutos.Domain.Abstractions.Repositories;
using ApiProdutos.Domain.Abstractions.Services;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiProdutos.Application.Services
{
    public abstract class ApplicationService<TRepository, TEntity, TValidator> : IService<TEntity>
        where TRepository : IRepository<TEntity>
        where TEntity : EntityBase
        where TValidator : AbstractValidator<TEntity>, new()
    {
        private readonly TRepository repository;

        protected ApplicationService(TRepository repository)
        {
            this.repository = repository;
        }

        #region [CRUD OPERATIONS]
        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            return await repository.CreateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await repository.GetAllAsync();
        }

        public async Task<TEntity> GetAsync(int id)
        {
            return await repository.GetAsync(id);
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            return await repository.UpdateAsync(entity);
        }
        #endregion

        #region [ VALIDATIONS ]

        public ValidationResult Validate(TEntity entity)
        {
            TValidator validator = new TValidator();
            var result = validator.Validate(entity);
            return result;
        }
        #endregion
    }
}
