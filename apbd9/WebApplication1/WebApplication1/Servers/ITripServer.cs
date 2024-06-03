using WebApplication1.Models;

namespace WebApplication1.Servers;

public interface ITripServer
{ 
    Task<WithPageDTO> GetTrips(int page, int pageSize);

}