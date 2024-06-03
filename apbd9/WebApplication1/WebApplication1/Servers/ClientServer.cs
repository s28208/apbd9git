using WebApplication1.Data;
using WebApplication1.Repositors;

namespace WebApplication1.Servers;

public class ClientServer : IClientServer
{
    private readonly IClientRepository _clientRepository;

    public ClientServer(IClientRepository clientRepository)
    {
        _clientRepository = clientRepository ?? throw new ArgumentNullException(nameof(clientRepository));
    }

    public async Task DeleteClient(int id)
    {
        var client = await _clientRepository.GetClient(id);
        if (client.ClientTrips.Count > 0)
        {
            throw new ArgumentException("Client has trip");
        }

        await _clientRepository.DeleteClient(client);
    }
}