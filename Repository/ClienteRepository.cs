using Microsoft.EntityFrameworkCore;
using nextia_challenge.Data;
using nextia_challenge.Models;
using nextia_challenge.Repository.Interface;

namespace nextia_challenge.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly DataContext _context;

        public ClienteRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cliente>> GetAllClientesAsync()
        {
            return await _context.MVC_Clientes.ToListAsync();
        }

        public async Task<Cliente> GetClienteByIdAsync(int id)
        {
            return await _context.MVC_Clientes.FindAsync(id);
        }

        public async Task<Cliente> AddClienteAsync(Cliente cliente)
        {
            _context.MVC_Clientes.Add(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }

        public async Task UpdateClienteAsync(Cliente cliente)
        {
            _context.Entry(cliente).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteClienteAsync(int id)
        {
            var cliente = await _context.MVC_Clientes.FindAsync(id);
            if (cliente != null)
            {
                _context.MVC_Clientes.Remove(cliente);
                await _context.SaveChangesAsync();
            }
        }
    }
}
