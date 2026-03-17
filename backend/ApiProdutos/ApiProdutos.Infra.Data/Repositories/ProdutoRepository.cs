using ApiProdutos.Domain;
using ApiProdutos.Domain.Abstractions.Repositories;
using ApiProdutos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiProdutos.Infra.Data.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly DistribuidoraContext context;

        public ProdutoRepository(DistribuidoraContext context)
        {
            this.context = context;
        }

        public async Task<Produto> CreateAsync(Produto entity)
        {
            var result = await this.context.Produtos.AddAsync(entity);
            await context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetAsync(id);
            this.context.Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Produto>> GetAllAsync()
        {
            return await this.context.Produtos.OrderBy(o=> o.Id).AsNoTracking().ToListAsync();
        }

        public async Task<Produto> GetAsync(int id)
        {
            return await context.Produtos.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Produto> UpdateAsync(Produto entity)
        {
            var dbEntity = await context.Produtos.FirstAsync(f => f.Id == entity.Id);
            dbEntity.Nome = entity.Nome;
            dbEntity.Quantidade = entity.Quantidade;
            dbEntity.Preco = entity.Preco;
            await context.SaveChangesAsync();

            return dbEntity;
        }
    }
}
