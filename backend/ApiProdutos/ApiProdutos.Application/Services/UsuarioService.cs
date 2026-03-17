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
    public class UsuarioService : ApplicationService<IUsuarioRepository, Usuario, UsuarioValidator>, IUsuarioService
    {
        public UsuarioService(IUsuarioRepository repository) : base(repository)
        {
        }
    }
}
