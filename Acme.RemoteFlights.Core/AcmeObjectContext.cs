using Acme.RemoteFlights.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Acme.RemoteFlights.Core
{
    public class AcmeObjectContext : DbContext
    {
        public AcmeObjectContext(DbContextOptions<AcmeObjectContext> options) : base(options)
        {
        }

        public DbSet<Flight> Flight { get; set; }
        public DbSet<FlightSchedule> FlightSchedule { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Booking> Booking { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}