using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Repositors;
using WebApplication1.Servers;

namespace WebApplication1.Controllers;

[ApiController]
[Route("/api/clients")]
public class ClientController : ControllerBase
{
    private readonly IClientServer _clientServer;

    public ClientController(IClientServer clientServer)
    {
        _clientServer = clientServer;
    }

    
    [HttpDelete("{idClient:int}")]
    
    public async Task<IActionResult> DeleteClient(int idClient)
    {
        _clientServer.DeleteClient(idClient);
        return Ok();
    }
}