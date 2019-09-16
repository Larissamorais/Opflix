using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.Interface;
using Senai.OpFlix.WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Controllers
{
    public class CategoriasController: ControllerBase
    {
        private ICategoriaRepository CategoriaRepository { get; set; }

        public CategoriasController()
        {
            CategoriaRepository = new CategoriaRepository();
        }
    [Authorize(Roles = "Administrador")]
    [HttpPost]
    public IActionResult Cadastrar(Categoria categoria)
    {
        try
        {
            int IdCategoria = Convert.ToInt32(HttpContext.User.Claims.First(x => x.Type == JwtRegisteredClaimNames.Jti).Value);
            categoria.IdCategoria = IdCategoria;
            CategoriaRepository.Cadastrar(categoria);
            return Ok();
        }
        catch (System.Exception ex)
        {
            return BadRequest(new { mensagem = ex.Message });
        }
    } 
    }

}

