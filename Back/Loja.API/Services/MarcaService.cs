using System.Collections.Generic;
using System.Linq;
using Loja.API.Data;
using Loja.API.Models;

namespace Loja.API.Services {
    public class MarcaService : IMarcaService {
        private readonly DataContext _context;
        public MarcaService(DataContext context) {
            this._context = context;            
        }
        public IEnumerable<Marca> Buscar(){
            var marcas = _context.Marcas;
            if (marcas == null || marcas.ToList().Count == 0)
                return null;
                return marcas;
        }
        public Marca BuscarPorId(int id){
            var marca = _context.Marcas.FirstOrDefault(
                m => m.Id == id
            );
            return marca;
        }
        public IEnumerable<Marca> BuscarPorNome(string nome){
            var marcas = _context.Marcas.Where(
                m => m.Nome.ToLower().Contains(nome.ToLower())
            );
            if (marcas == null || marcas.ToList().Count == 0)
                return null;
            return marcas;
        }

        public Marca Adicionar(Marca novaMarca){
            var marca = new Marca(novaMarca.Nome, novaMarca.Ativo);
            _context.Add(marca);
            _context.SaveChanges();
            return marca;
        }
        public Marca Atualizar(int id, Marca marcaAtualizada){
            var marca = _context.Marcas.FirstOrDefault(
                ma => ma.Id == id
            );
            if (marca == null)
                return null;
            marca.AtualizarMarca(marcaAtualizada.Nome, marcaAtualizada.Ativo);
            _context.Update(marca);
            _context.SaveChanges();
            return marca;
        }
        public bool Remover(int id){
            var marca = _context.Marcas.FirstOrDefault(
                m => m.Id == id
            );
            if (marca == null) 
                return false;
            _context.Remove(marca);
            _context.SaveChanges();
            return true;
        }

        public IEnumerable<Marca> OrdenarMarcas(string ordenarPor, string crescenteOuDescrescente){
            char ordem = (string.IsNullOrEmpty(crescenteOuDescrescente) ? 'C' : 
            crescenteOuDescrescente.ToUpper()[0]);
            switch (ordenarPor) {
                case "nome":
                    return (ordem == 'D' ? _context.Marcas.OrderByDescending(m => m.DataCadastro) : _context.Marcas.OrderBy(m => m.Nome));
                default:
                    return (ordem == 'D' ? _context.Marcas.OrderByDescending(m => m.DataCadastro) : _context.Marcas.OrderBy(m => m.DataCadastro));
            }
        }

    }
}