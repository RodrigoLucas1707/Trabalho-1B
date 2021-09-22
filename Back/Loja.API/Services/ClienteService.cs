using System.Collections.Generic;
using System.Linq;
using Loja.API.Data;
using Loja.API.Models;

namespace Loja.API.Services {
    public class ClienteService : IClienteService {
        private readonly DataContext _context;
        public ClienteService(DataContext context) {
            this._context = context;            
        }
        public IEnumerable<Cliente> Buscar(){
            var clientes = _context.Clientes;
            if (clientes == null || clientes.ToList().Count == 0)
                return null;
                return clientes;
        }
        public Cliente BuscarPorId(int id){
            var cliente = _context.Clientes.FirstOrDefault(
                c => c.Id == id
            );
            return cliente;
        }
        public IEnumerable<Cliente> BuscarPorNome(string nome){
            var clientes = _context.Clientes.Where(
                c => c.Nome.ToLower().Contains(nome.ToLower())
            );
            if (clientes == null || clientes.ToList().Count == 0)
                return null;
            return clientes;
        }

        public IEnumerable<Cliente> BuscarLiberados() {
            var clienteSelecionado = _context.Clientes.Where(
                cli => cli.Liberado == true);
            if (clienteSelecionado == null || clienteSelecionado.ToList().Count == 0)
                return null;
            return clienteSelecionado;
        }

         public IEnumerable<Cliente> BuscarBloqueados() {
             var clienteSelecionado = _context.Clientes.Where(
                 cli => cli.Liberado == false);
             if (clienteSelecionado == null || clienteSelecionado.ToList().Count == 0)
                 return null;
             return clienteSelecionado;
        }

        public IEnumerable<Cliente> BuscarCredito(double credito) {
             var clienteSelecionado = _context.Clientes.Where(
                 cli => cli.Credito >= credito);
             if (clienteSelecionado == null || clienteSelecionado.ToList().Count == 0)
                 return null;
             return clienteSelecionado;
        }

        public Cliente Adicionar(Cliente novoCliente){
            var cliente = new Cliente(novoCliente.Nome, novoCliente.Liberado, novoCliente.Credito, novoCliente.DataNascimento);
            _context.Add(cliente);
            _context.SaveChanges();
            return cliente;
        }
        public Cliente Atualizar(int id, Cliente clienteAtualizado){
            var cliente = _context.Clientes.FirstOrDefault(
                cli => cli.Id == id
            );
            if (cliente == null)
                return null;
            cliente.AtualizarCliente(clienteAtualizado.Nome, clienteAtualizado.Liberado, clienteAtualizado.Credito, clienteAtualizado.DataNascimento);
            _context.Update(cliente);
            _context.SaveChanges();
            return cliente;
        }
        public bool Remover(int id){
            var cliente = _context.Clientes.FirstOrDefault(
                c => c.Id == id
            );
            if (cliente == null) 
                return false;
            _context.Remove(cliente);
            _context.SaveChanges();
            return true;
        }

        public IEnumerable<Cliente> OrdenarClientes(string ordenarPor, string crescenteOuDescrescente){
            char ordem = (string.IsNullOrEmpty(crescenteOuDescrescente) ? 'C' : 
            crescenteOuDescrescente.ToUpper()[0]);
            switch (ordenarPor) {
                case "nome":
                    return (ordem == 'D' ? _context.Clientes.OrderByDescending(c => c.Nome) : _context.Clientes.OrderBy(c => c.Nome) );
                default:
                    return (ordem == 'D' ? _context.Clientes.OrderByDescending(c => c.DataCadastro) : _context.Clientes.OrderBy(c => c.DataCadastro));
            }
        }

    }
}