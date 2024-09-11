using Microsoft.EntityFrameworkCore;
using nextia_challenge.Data;
using nextia_challenge.Models;
using nextia_challenge.Repository.Interface;

namespace nextia_challenge.Repository
{
    public class PromocaoRepository : IPromocaoRepository
    {
        private readonly DataContext _context;

        public PromocaoRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Promocao>> GetAllPromocoesAsync()
        {
            return await _context.MVC_Promocoes.ToListAsync();
        }

        public async Task<Promocao> GetPromocaoByIdAsync(int id)
        {
            return await _context.MVC_Promocoes.FindAsync(id);
        }

        public async Task<Promocao> AddPromocaoAsync(Promocao promocao)
        {
            _context.MVC_Promocoes.Add(promocao);
            await _context.SaveChangesAsync();
            return promocao;
        }

        public async Task UpdatePromocaoAsync(Promocao promocao)
        {
            _context.Entry(promocao).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeletePromocaoAsync(int id)
        {
            var promocao = await _context.MVC_Promocoes.FindAsync(id);
            if (promocao != null)
            {
                _context.MVC_Promocoes.Remove(promocao);
                await _context.SaveChangesAsync();
            }
        }
    }
}
