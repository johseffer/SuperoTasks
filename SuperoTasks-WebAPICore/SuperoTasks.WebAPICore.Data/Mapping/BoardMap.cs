using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SuperoTasks.WebAPICore.Domain;

namespace SuperoTasks.WebAPICore.Data.Mapping
{
    class BoardMap : IEntityTypeConfiguration<Board>
    {
        public void Configure(EntityTypeBuilder<Board> builder)
        {
            builder.ToTable("ST_BOARD");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
               .IsRequired()
               .HasColumnName("Id");

            builder.Property(c => c.Name)
                .IsRequired()
                .HasColumnName("Name");

            #region RELATIONSHIPS
            builder.HasMany(x => x.Cards).WithOne(card => card.Board);
            #endregion

        }
    }
}
