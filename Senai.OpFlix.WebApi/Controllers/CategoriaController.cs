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
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]

    public class CategoriaController: ControllerBase
    {
        private ICategoriaRepository CategoriaRepository { get; set; }

        public CategoriaController()
        {
            CategoriaRepository = new CategoriaRepository();
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(CategoriaRepository.Listar());
        }

        [Authorize(Roles = "Administrador")]
    [HttpPost]
    public IActionResult Cadastrar(Categoria categoria)
    {
        try
        {
                CategoriaRepository.Cadastrar(categoria);

                 return Ok();
        }
        catch (System.Exception ex)
        {
            return BadRequest(new { mensagem = ex.Message });
        }

    }
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            Categoria Categoria = CategoriaRepository.BuscarPorId(id);
            if (Categoria == null)
                return NotFound();
            return Ok(Categoria);
        }

    }
    

}





