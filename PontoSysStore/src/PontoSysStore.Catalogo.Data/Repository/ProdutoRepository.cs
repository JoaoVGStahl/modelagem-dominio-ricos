using Microsoft.EntityFrameworkCore;
using PontoSysStore.Catalogo.Domain;
using PontoSysStore.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PontoSysStore.Catalogo.Data.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly CatalogoContext _context;

        public IUnitOfWork UnitOfWork => _context;

        public ProdutoRepository(CatalogoContext context)
        {
            _context = context;
        }

        public void Adicionar(Produto produto)
        {
            _context.Add(produto);
        }

        public void Adicionar(Categoria categoria)
        {
            _context.Add(categoria);
        }

        public void Atualizar(Produto produto)
        {
            _context.Update(produto);
        }

        public void Atualizar(Categoria categoria)
        {
            _context.Update(categoria);
        }

        public async Task<IEnumerable<Categoria>> ObterCategorias()
        {
            return await _context.Categorias.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<Produto>> ObterPorCatgeoria(int codigo)
        {
            return await _context.Produtos.AsNoTracking().Include(p => p.Categoria).Where(c => c.Categoria.Codigo == codigo).ToListAsync();
        }

        public async Task<Produto> ObterPorId(Guid id)
        {
            return await _context.Produtos.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Produto>> ObterTodos()
        {
            return await _context.Produtos.AsNoTracking().ToListAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
