using WebApplication1.Models;

namespace WebApplication1.Repositors;

public interface IClientRepository
{
    Task DeleteClient(Client client);

     Task<Client> GetClient(int id);
}