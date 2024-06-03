using WebApplication1.Models;

namespace WebApplication1.Repositors;

public interface ITripRepository
{ 
    Task<WithPage> GetTrips(WithPage withPage);

}