using nextia_challenge.Models;

namespace nextia_challenge.Repository.Interface
{
    public interface IPromocaoRepository
    {
        Task<IEnumerable<Promocao>> GetAllPromocoesAsync();
        Task<Promocao> GetPromocaoByIdAsync(int id);
        Task<Promocao> AddPromocaoAsync(Promocao promocao);
        Task UpdatePromocaoAsync(Promocao promocao);
        Task DeletePromocaoAsync(int id);
    }
}
