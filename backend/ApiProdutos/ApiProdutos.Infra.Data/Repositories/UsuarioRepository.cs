using ApiProdutos.Domain.Abstractions.Repositories;
using ApiProdutos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiProdutos.Infra.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly DistribuidoraContext context;

        public UsuarioRepository(DistribuidoraContext context)
        {
            this.context = context;
        }

        public async Task<Usuario> CreateAsync(Usuario entity)
        {
            var result = await this.context.Usuarios.AddAsync(entity);
            return result.Entity;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetAsync(id);
            this.context.Remove(entity);
        }


        public async Task<IEnumerable<Usuario>> GetAllAsync()
        {
            return await this.context.Usuarios.AsNoTracking().ToListAsync();

        }

        public async Task<Usuario> GetAsync(int id)
        {
            return await this.context.Usuarios.FirstOrDefaultAsync(s => s.Id == id);

        }

        public async Task<Usuario> UpdateAsync(Usuario entity)
        {
            var dbEntity = await context.Usuarios.FirstAsync(f => f.Id == entity.Id);
            dbEntity.Nome = entity.Nome;
            return dbEntity;
        }
    }
}
