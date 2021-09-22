using System;

namespace Loja.API.Models {
    public class Marca {
        public int? Id { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataCadastro { get; set; }

        public Marca() {
            DataCadastro = DateTime.Now;
        }
        public Marca(string nome, bool ativo) {
            this.Id = null;
            this.Nome = nome;
            this.Ativo = true;
            this.DataCadastro = DateTime.Now;
        }
        public void AtualizarMarca(string nome, bool ativo) {
            Nome = nome;
            Ativo = ativo;
        }
    }
}