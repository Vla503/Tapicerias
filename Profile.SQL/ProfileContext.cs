
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Profile.Core.Model;
using Profile.SQL.Mapping;

namespace Profile.SQL
{
    public class ProfileContext: DbContext
    {
        public ProfileContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Usuario> Usuario { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.ApplyConfiguration(new UserMappging());

            base.OnModelCreating(modelBuilder);
        }
    }
}
