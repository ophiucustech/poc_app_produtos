using ApiProdutos.Domain.Abstractions.Services;
using ApiProdutos.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProdutos.Auth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUsuarioService usuario;

        public AuthController(IUsuarioService usuario)
        {
            this.usuario = usuario;
        }
        public async Task Login(Usuario usuario)
        {
        }
    }
}
