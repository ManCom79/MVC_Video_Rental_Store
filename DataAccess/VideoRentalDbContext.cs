using DomainModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class VideoRentalDbContext : DbContext
    {
        public VideoRentalDbContext(DbContextOptions<VideoRentalDbContext> options) : base(options) { }
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<Rental> Rentals { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}
