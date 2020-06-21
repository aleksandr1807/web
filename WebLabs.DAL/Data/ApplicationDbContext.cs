using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebLabs.DAL.Entities;

namespace WebLabs.DAL.Data
{
   public class ApplicationDbContext:IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options)
        {

        }
      public  DbSet<Tehnika> Tehniks { get; set; }
        public DbSet<TehnikaGroup> TehnikaGroups { get; set; }
    }
}
