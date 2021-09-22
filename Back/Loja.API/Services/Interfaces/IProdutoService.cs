using System.Collections.Generic;
using Loja.API.Models;
namespace Loja.API.Services {
    public interface IProdutoService {
        // Declaração dos métodos abstratos
        IEnumerable<Produto> Buscar();
        Produto BuscarPorId(int id);
        IEnumerable<Produto> BuscarPorNome(string nome);
        IEnumerable<Produto> OrdenarProdutos(string ordenarPor, string crescenteOuDescrescente);
        Produto Adicionar(Produto novoProduto);
        Produto Atualizar(int id, Produto produtoAtualizado);
        bool Remover(int id);

    }
}