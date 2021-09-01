using CadstrarTarefasWebAPI.Models;
using CadstrarTarefasWebAPI.Repositories;
using CadstrarTarefasWebAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadstrarTarefasWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IRepository _repository;

        public UsuarioController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Autenticacao([FromBody] Usuario model)
        {
            Usuario user = model;

            if (user != null)
            {
                var token = TokenService.GenerateToken(user);

                return new
                {
                    user = user,
                    token = token
                };
            }

            return NotFound(new { mensage = "Usuário Inválido" });
            
        }

        // GET: api/usuario
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetUsuarios()
        {
            try
            {
                var listUsuarios = await _repository.BuscarUsuarios();

                return Ok(listUsuarios);
            }
            catch (Exception ex)
            {

                return BadRequest($"Erro: {ex}");
            }

        }

        // GET api/usuario/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetUsuarioById(int id)
        {
            try
            {
                var listUruariosId = await _repository.BuscarUsuarioId(id);

                return Ok(listUruariosId);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }

        // POST api/usuario
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> PostUsuario(Usuario usuario)
        {
            try
            {

                _repository.Add(usuario);

                if (await _repository.SaveChangeAsync())
                {
                    return Ok("Usuário cadastrado com sucesso!");
                }

            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }

            return BadRequest("Usuário não cadastrado!");
        }

        // PUT api/usuario/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutUsuario(int id, Usuario usuario)
        {
            try
            {
                var selectUsuario = await _repository.BuscarUsuarioId(id);

                if (selectUsuario != null)
                {
                    _repository.Update(usuario);

                    if (await _repository.SaveChangeAsync())
                    {
                        return Ok("Usuário Atualizado com sucesso!");
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }

            return Ok("Usuário não atualizado!");
        }

        // DELETE api/usuario/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            try
            {
                var usuario = await _repository.BuscarUsuarioId(id);

                if (usuario != null)
                {
                    _repository.Delete(usuario);

                    if (await _repository.SaveChangeAsync())
                    {
                        return Ok("Usuário deletado com sucesso!");
                    }

                }

            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }

            return BadRequest("Usuário não deletado!");
        }
    }
}
