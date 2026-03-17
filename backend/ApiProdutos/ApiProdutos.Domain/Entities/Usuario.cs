using ApiProdutos.Domain.Abstractions.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiProdutos.Domain.Entities
{
    public class Usuario : EntityBase
    {
        public Usuario(int id, string nome) : base(id, nome)
        {

        }
    }
}
