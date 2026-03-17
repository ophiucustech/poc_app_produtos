using ApiProdutos.Domain.Abstractions.Services;
using ApiProdutos.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiProdutos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoService produtoService;

        public ProdutosController(IProdutoService produtoService)
        {
            this.produtoService = produtoService;
        }


        // GET: api/<ProdutosController>
        [HttpGet]
        public async Task<IEnumerable<Produto>> Get()
        {
           

            return await produtoService.GetAllAsync();



        }

        // GET api/<ProdutosController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ProdutosController>
        [HttpPost]
        public async Task Post([FromBody] Produto value)
        {
            await this.produtoService.CreateAsync(value);
        }

        // PUT api/<ProdutosController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] Produto value)
        {
            await this.produtoService.UpdateAsync(value);

        }

        // DELETE api/<ProdutosController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await produtoService.DeleteAsync(id);
        }
    }
}
