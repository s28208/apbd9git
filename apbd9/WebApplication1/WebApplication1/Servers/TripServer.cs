using WebApplication1.Models;
using WebApplication1.Repositors;

namespace WebApplication1.Servers;

public class TripServer : ITripServer
{
    private readonly ITripRepository _tripRepository;

    public TripServer(ITripRepository tripRepository)
    {
        _tripRepository = tripRepository ?? throw new ArgumentNullException(nameof(tripRepository));
    }
    public async Task<WithPageDTO> GetTrips(int page , int pageSize)
    {
        if (pageSize <= 0)
        {
            pageSize = 10;
        }

        if (page <= 0)
        {
            page = 1;
        }

        var res = new WithPage()
        {
            PageSize = pageSize, PageNum = page
        };
        var collection = await _tripRepository.GetTrips(res);
        var resDTO = new WithPageDTO()
        {
            AllPages = collection.AllPages,
            PageNum = collection.PageNum,
            PageSize = collection.PageSize,
            Trip = collection.trip.Select(x =>
            {
                return new TripDTO()
                {
                    Name = x.Name,
                    Description = x.Description,
                    DateFrom = x.DateFrom,
                    DateTo = x.DateTo,
                    MaxPeople = x.MaxPeople,
                    Countries = x.IdCountries.Select(x => new CountryDTO() { Name = x.Name }).ToList(),
                    ClientTrips = x.ClientTrips.Select(x => new ClientDTO()
                            { FirstName = x.IdClientNavigation.FirstName, LastName = x.IdClientNavigation.LastName })
                        .ToList()
                };
            }).ToList()
        };
        return resDTO;
    }
}