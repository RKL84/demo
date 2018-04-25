using Microsoft.EntityFrameworkCore;

namespace Acme.RemoteFlights.Data
{
    public class AcmeObjectContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public AcmeObjectContext(DbContextOptions<AcmeObjectContext> options) : base(options)
        {
        }
    }
}