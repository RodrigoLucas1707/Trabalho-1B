using System.Collections.Generic;
using System.Linq;
using Loja.API.Models;
using Loja.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Loja.API.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase {

        // declara um objeto da interface 
         private readonly IProdutoService _produtoService;

        // Lista estática de produtos
        //public static List<Produto> produtos = new List<Produto>();

        public ProdutoController(IProdutoService produtoService){
            _produtoService = produtoService;
            // if (produtos.Count <= 0){
            //     Produto produto = new Produto() { 
            //         Id = 1, Nome = "Tênis", Estoque = 10, Valor = 159.99 
            //     };
            //     produtos.Add(produto);
                
            //     produto = new Produto(){
            //         Id= 2, Nome = "Camiseta", Estoque = 15, Valor = 89.78
            //     };
            //     produtos.Add(produto);

            //     produto = new Produto(){
            //         Id= 3, Nome = "Boné", Estoque = 7, Valor = 55.45
            //     };
            //     produtos.Add(produto);
            // }
         }

        // Método Get
        [HttpGet]
        public IActionResult Get(){    
            var produtos = _produtoService.Buscar();        
            if (produtos == null)
                return NotFound();
            return Ok(produtos); // Retorna um resultado correto
        }

        // Método Get com filtro (ID)
        [HttpGet("{id}")]
        public IActionResult Get(int id){
            var produtoSelecionado = _produtoService.BuscarPorId(id);
            if (produtoSelecionado == null)
                return NotFound();
            return Ok(produtoSelecionado);
        }

        [HttpGet("buscar/{nome}")]
        public IActionResult GetByName(string nome){
            var produtos = _produtoService.BuscarPorNome(nome);
            if (produtos == null) { 
                return NotFound(); 
            } else { 
                return Ok(produtos); 
            }
        }

        // Método Post
        [HttpPost]
        public IActionResult Post([FromBody] Produto novoProduto){
            // Adicionar o produto na tabela do BD
            Produto produtoAdicionado = _produtoService.Adicionar(novoProduto);
            // Retornar para o cliente o produto adicionado na lista
            return Created("", produtoAdicionado);
        }

        // Método Put
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Produto produtoAtual) {
            produtoAtual = _produtoService.Atualizar(id, produtoAtual);
            if (produtoAtual == null) {
                return NotFound();
            }
            return Ok(produtoAtual);
        }

        // Método Delete
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {
            bool remocaoOk = _produtoService.Remover(id);
            // Verificar se o produto foi excluido
            if (remocaoOk == false) {
                return NotFound();
            }
            return NoContent();
        }

        [HttpGet("ordenar/{ordenarPor}")]
        public IActionResult GetByOrder(string ordenarPor, string crescenteOuDescrescente){
            var produtosOrdenados = _produtoService.OrdenarProdutos(ordenarPor, crescenteOuDescrescente);
            if (produtosOrdenados == null){
                return NotFound();
            }
            return Ok(produtosOrdenados);
        }

    }
}