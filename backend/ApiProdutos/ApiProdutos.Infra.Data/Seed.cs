using ApiProdutos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiProdutos.Infra.Data
{
    public static class Seed
    {
        public static void Initilize(DistribuidoraContext context)
        {
            List<Produto> produtos = new List<Produto>();
            produtos.Add(new Produto(1, "Cerveja", 10, 250));
            produtos.Add(new Produto(id: 2, "Suco", 5, 20));
            produtos.Add(new Produto(id: 3, "Agua Tonica", 3, 100));
            produtos.Add(new Produto(id: 4, "Agua Mineral", 3, 40));

            context.Produtos.AddRange(produtos);

            context.SaveChanges();
        }
    }
}
