using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PostModule.Domain.StateEntity;
using System.Reflection.Emit;

namespace PostModule.Infrastracture.EF.Mapping
{
    public class StateMapping : IEntityTypeConfiguration<State>
    {
        public void Configure(EntityTypeBuilder<State> builder)
        {
            
            
            builder.ToTable("states");
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Title).IsRequired(true).HasMaxLength(150);
            builder.Property(b => b.CloseStates).IsRequired(false).HasMaxLength(100);
            builder.Property(b => b.CreateDate).IsRequired(true);


            builder.HasMany(b => b.cities).WithOne(c => c.state).HasForeignKey(c=>c.StateId);

        }
    }
}
