using PontoSysStore.Core.DomainObjects;
using System.Collections.Generic;

namespace PontoSysStore.Catalogo.Domain
{
    public class Categoria : Entity
    {
        public string Nome { get; private set; }
        public int Codigo { get; private set; }

        // ! EF Relation
        public ICollection<Produto> Produtos { get; set; }

        protected Categoria()
        {

        }

        public Categoria(string nome, int codigo)
        {
            Nome = nome;
            Codigo = codigo;

            Validar();
        }

        public override string ToString()
        {
            return $"{Nome} - {Codigo}";
        }

        public void Validar()
        {
            Validacoes.ValidarSeVazio(Nome, "O campo Nome da categoria não pode ser vazio");
            Validacoes.ValidarSeIgual(Codigo, 0, "O campo Código não pode ser 0");
        }

    }
}
