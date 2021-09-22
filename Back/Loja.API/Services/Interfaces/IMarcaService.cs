using System.Collections.Generic;
using Loja.API.Models;
namespace Loja.API.Services {
    public interface IMarcaService {
        IEnumerable<Marca> Buscar();
        Marca BuscarPorId(int id);
        IEnumerable<Marca> BuscarPorNome(string nome);
        IEnumerable<Marca> OrdenarMarcas(string ordenarPor, string crescenteOuDescrescente);
        Marca Adicionar(Marca novaMarca);
        Marca Atualizar(int id, Marca marcaAtualizada);
        bool Remover(int id);

    }
}