using Microsoft.EntityFrameworkCore;
using nextia_challenge.Data;
using nextia_challenge.Models;
using nextia_challenge.Repository.Interface;

namespace nextia_challenge.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly DataContext _context;

        public ProdutoRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Produto>> GetAllProdutosAsync()
        {
            return await _context.MVC_Produtos.ToListAsync();
        }

        public async Task<Produto> GetProdutoByIdAsync(int id)
        {
            return await _context.MVC_Produtos.FindAsync(id);
        }

        public async Task<Produto> AddProdutoAsync(Produto produto)
        {
            _context.MVC_Produtos.Add(produto);
            await _context.SaveChangesAsync();
            return produto;
        }

        public async Task UpdateProdutoAsync(Produto produto)
        {
            _context.Entry(produto).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProdutoAsync(int id)
        {
            var produto = await _context.MVC_Produtos.FindAsync(id);
            if (produto != null)
            {
                _context.MVC_Produtos.Remove(produto);
                await _context.SaveChangesAsync();
            }
        }
    }
}
