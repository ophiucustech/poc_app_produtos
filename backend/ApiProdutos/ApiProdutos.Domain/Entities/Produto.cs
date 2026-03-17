using ApiProdutos.Domain.Abstractions.Entities;

namespace ApiProdutos.Domain.Entities
{
    /// <summary>
    /// 
    /// </summary>
    public class Produto : EntityBase
    {
        /// <summary>
        /// Preço do produto, que deve ser maior que zero
        /// </summary>
        public decimal Preco { get; set; }
        /// <summary>
        /// quantidade do produto, que deve ser maior que zero
        /// </summary>
        public int Quantidade { get; set; }

        public Produto(int id, string nome, decimal preco, int quantidade):base(id,nome)
        {
            
            Preco = preco;
            Quantidade = quantidade;
        }

    }
}
