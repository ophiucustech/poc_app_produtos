using ApiProdutos.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiProdutos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        // GET: api/<ProdutosController>
        [HttpGet]
        public IEnumerable<Produto> Get()
        {
            List<Produto> produtos = new List<Produto>();
            produtos.Add(new Produto(1, "Cerveja", 10, 250));
            produtos.Add(new Produto(2, "Suco", 5, 20));
            produtos.Add(new Produto(3, "Agua Tonica", 3, 100));
            produtos.Add(new Produto(4, "Agua Mineral", 3, 40));

            return produtos;



        }

        // GET api/<ProdutosController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ProdutosController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ProdutosController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProdutosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
