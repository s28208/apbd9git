using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Repositors;

public class TripRepository : ITripRepository
{
    private Apbd901Context _context;

    public TripRepository(Apbd901Context context)
    {
        _context = context;
    }
    
    //R
    public async Task<WithPage> GetTrips(WithPage withPage)
    {
        
        var elementsSkip = withPage.PageSize * (withPage.PageNum - 1);
        var tripsQuery = _context.Trips
            .Include(t => t.IdCountries)
            .Include(t => t.ClientTrips)
            .ThenInclude(ct => ct.IdClientNavigation)
            .OrderByDescending(t => t.DateFrom)  
            .Skip(elementsSkip)
            .Take(withPage.PageSize);

        var trips = await tripsQuery.ToListAsync();

        var totalTripsCount = await _context.Trips.CountAsync();
        var totalPages = (int)Math.Ceiling((double)totalTripsCount / withPage.PageSize);

        withPage.trip = trips;
        withPage.AllPages = totalPages;

        return withPage;
    }
    
    
}