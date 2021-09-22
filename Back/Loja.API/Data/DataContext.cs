using Loja.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Loja.API.Data {
    public class DataContext : DbContext {
        // Método construtor em que ocorre a injeção de dependência (Configuração da conexão com o BD)
        public DataContext(DbContextOptions<DataContext> options) : 
        base(options) { }
        // Definir as Entidades do BD
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Marca> Marcas { get; set; }

    }
}