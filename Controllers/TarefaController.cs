using CadstrarTarefasWebAPI.Data;
using CadstrarTarefasWebAPI.Models;
using CadstrarTarefasWebAPI.Repositories;
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
    public class TarefaController : ControllerBase
    {
        private readonly IRepository _repository;

        public TarefaController(IRepository repository)
        {
            _repository = repository;
        }

        // GET: api/tarefa
        [HttpGet]
        public async Task<IActionResult> GetTarefas()
        {
            try
            {
                var listTarefas = await _repository.BuscarTarefas();

                return Ok(listTarefas);
            }
            catch (Exception ex)
            {

                return BadRequest($"Erro: {ex}");
            }

        }

        // GET api/tarefa/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTarefasById(int id)
        {
            try
            {
                var listTarefasId = await _repository.BuscarTarefaId(id);

                return Ok(listTarefasId);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }

        // POST api/tarefa
        [HttpPost]
        public async Task<IActionResult> PostTarefa(Tarefa tarefa)
        {
            try
            {

                _repository.Add(tarefa);
                
                if (await _repository.SaveChangeAsync()) 
                { 
                    return Ok("Tarefa cadastrada com sucesso!");
                }

            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }

            return BadRequest("Não foi salvo");
        }

        // PUT api/tarefa/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTarefa(int id, Tarefa tarefa)
        {
            try
            {
                var selectTarefa = await _repository.BuscarTarefaId(id);

                if (selectTarefa != null)
                {
                    _repository.Update(tarefa);

                    if (await _repository.SaveChangeAsync()) 
                    { 
                        return Ok("Tarefa Atualizada com sucesso!");
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }

            return Ok("Tarefa não atualizada!");
        }

        // DELETE api/tarefa/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTarefa(int id)
        {
            try
            {
                var tarefa = await _repository.BuscarTarefaId(id);

                if (tarefa != null)
                {
                    _repository.Delete(tarefa);

                    if (await _repository.SaveChangeAsync())
                    {
                        return Ok("Tarefa deletada com sucesso!");
                    }
                        
                }

            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }

            return BadRequest("Tarefa não deletada!");
        }
    }
}
