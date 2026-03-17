using System;
using System.Collections.Generic;
using System.Text;

namespace ApiProdutos.Domain.Abstractions.Entities
{
    public abstract class EntityBase
    {
        public virtual int Id { get; set; }
        public virtual string Nome { get; set; }
        public EntityBase(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }
    }
}
