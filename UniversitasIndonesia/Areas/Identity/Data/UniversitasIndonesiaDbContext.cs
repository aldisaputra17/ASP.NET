using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UniversitasIndonesia.Areas.Identity.Data;
using UniversitasIndonesia.Models;

namespace UniversitasIndonesia.Data
{
    public class UniversitasIndonesiaDbContext : IdentityDbContext<UniversitasIndonesiaUser>
    {
        public UniversitasIndonesiaDbContext(DbContextOptions<UniversitasIndonesiaDbContext> options)
            : base(options)
        {
        }

        public DbSet<Mahasiswa> Mahasiswa { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
