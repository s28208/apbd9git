using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Repositors;
using WebApplication1.Servers;

namespace WebApplication1.Controllers;

[ApiController]
[Route("/api/trips")]
public class TripsController : ControllerBase
{
    private readonly ITripServer _tripServer;

    public TripsController(ITripServer tripServer)
    {
        _tripServer = tripServer;
    }


    [HttpGet]
    public async Task<IActionResult> GetTrips( int pageSize , int page )
    {
        var trip = await _tripServer.GetTrips(page, pageSize);
        return Ok(trip);
    }
    [HttpPost("{idTrip:int}/clients")]
    public async Task<IActionResult> RegistratateClietnToTrip(int idTrip)
    {
        
        return Ok();
    }
}