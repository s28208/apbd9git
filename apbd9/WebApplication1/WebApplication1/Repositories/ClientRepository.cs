using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Repositors;

public class ClientRepository : IClientRepository
{
    private Apbd901Context _context;

    public ClientRepository(Apbd901Context context)
    {
        _context = context;
    }
    public async Task<Client> GetClient(int id)
    {
        var client = await _context.Clients.Where(x => x.IdClient == id).Include(x => x.ClientTrips).SingleAsync();
        return client;
    }
    public async Task DeleteClient(Client client)
    {
        _context.Clients.Remove(client);
        await _context.SaveChangesAsync();
    }
}