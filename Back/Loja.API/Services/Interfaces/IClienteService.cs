using System.Collections.Generic;
using Loja.API.Models;
namespace Loja.API.Services {
    public interface IClienteService {
        IEnumerable<Cliente> Buscar();
        Cliente BuscarPorId(int id);
        IEnumerable<Cliente> BuscarPorNome(string nome);
        IEnumerable<Cliente> OrdenarClientes(string ordenarPor, string crescenteOuDescrescente);
        IEnumerable<Cliente> BuscarLiberados();
        IEnumerable<Cliente> BuscarBloqueados();
        IEnumerable<Cliente> BuscarCredito(double credito);
        Cliente Adicionar(Cliente novoCliente);
        Cliente Atualizar(int id, Cliente clienteAtualizado);
        bool Remover(int id);

    }
}