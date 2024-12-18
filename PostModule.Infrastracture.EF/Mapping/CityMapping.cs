using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PostModule.Domain.CityEntity;
using PostModule.Domain.StateEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostModule.Infrastracture.EF.Mapping
{
    public class CityMapping : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.ToTable("cities");
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Title).IsRequired(true).HasMaxLength(150);
            builder.Property(b => b.Statuse).IsRequired(true);


            builder.HasOne(b=>b.state).WithMany(s=>s.cities).HasForeignKey(c => c.StateId);
        }
    }
}
