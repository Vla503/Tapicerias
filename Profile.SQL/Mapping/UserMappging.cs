using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Profile.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Profile.SQL.Mapping
{
    public class UserMappging: IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable(nameof(Usuario));

            builder.HasKey(x =>  x.Codigo);
            builder.Property(x => x.Nombre).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Apellido).IsRequired().HasMaxLength(200);
            builder.Property(x => x.User).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Password).IsRequired().HasMaxLength(200);
        }
    }
}
