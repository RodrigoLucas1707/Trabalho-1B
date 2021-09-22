using System.Collections.Generic;
using System.Linq;
using Loja.API.Models;
using Loja.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Loja.API.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class MarcaController : ControllerBase {
         private readonly IMarcaService _marcaService;

        public MarcaController(IMarcaService marcaService){
            _marcaService = marcaService;
         }

        [HttpGet]
        public IActionResult Get(){    
            var marcas = _marcaService.Buscar();        
            if (marcas == null)
                return NotFound();
            return Ok(marcas);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id){
            var marcaSelecionada = _marcaService.BuscarPorId(id);
            if (marcaSelecionada == null)
                return NotFound();
            return Ok(marcaSelecionada);
        }

        [HttpGet("buscar/{nome}")]
        public IActionResult GetByName(string nome){
            var marcas = _marcaService.BuscarPorNome(nome);
            if (marcas == null) { 
                return NotFound(); 
            } else { 
                return Ok(marcas); 
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Marca novaMarca){
            Marca marcaAdicionada = _marcaService.Adicionar(novaMarca);
            return Created("", marcaAdicionada);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Marca marcaAtual) {
            marcaAtual = _marcaService.Atualizar(id, marcaAtual);
            if (marcaAtual == null) {
                return NotFound();
            }
            return Ok(marcaAtual);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {
            bool remocaoOk = _marcaService.Remover(id);
            if (remocaoOk == false) {
                return NotFound();
            }
            return NoContent();
        }

        [HttpGet("ordenar/{ordenarPor}")]
        public IActionResult GetByOrder(string ordenarPor, string crescenteOuDescrescente){
            var marcasOrdenadas = _marcaService.OrdenarMarcas(ordenarPor, crescenteOuDescrescente);
            if (marcasOrdenadas == null){
                return NotFound();
            }
            return Ok(marcasOrdenadas);
        }

    }
}