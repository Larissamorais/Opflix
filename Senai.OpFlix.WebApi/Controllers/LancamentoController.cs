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
    public class LancamentoController:ControllerBase
    {
        private ILancamentoRepository LancamentoRepository { get; set; }

        public LancamentoController()
        {
            LancamentoRepository = new LancamentoRepository();
        }
        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public IActionResult Cadastrar(Lancamento lancamento)
        {
            try
            {
                int IdLancamento = Convert.ToInt32(HttpContext.User.Claims.First(x => x.Type == JwtRegisteredClaimNames.Jti).Value);
                lancamento.IdLancamento = IdLancamento;
                LancamentoRepository.Cadastrar(lancamento);
                return Ok();
            }
            catch (System.Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }
        [Authorize(Roles = "Administrador")]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(LancamentoRepository.Listar());
        }

        

        }
    } 


}
