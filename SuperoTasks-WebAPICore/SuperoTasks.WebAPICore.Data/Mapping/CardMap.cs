using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SuperoTasks.WebAPICore.Domain;

namespace SuperoTasks.WebAPICore.Data.Mapping
{
    class CardMap : IEntityTypeConfiguration<Card>
    {
        public void Configure(EntityTypeBuilder<Card> builder)
        {
            builder.ToTable("ST_CARD");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
            .IsRequired()
            .HasColumnName("Id");

            builder.Property(c => c.BoardId)
                .IsRequired()
                .HasColumnName("Board_Id");

            builder.Property(c => c.Title)
                .IsRequired()
                .HasColumnName("Title");
            
            builder.Property(c => c.Description)
              .IsRequired()
              .HasColumnName("Description");

            builder.Property(c => c.CreationDate)
            .IsRequired()
            .HasColumnName("CreationDate");

            builder.Property(c => c.StartedDate)
           .IsRequired()
           .HasColumnName("StartedDate");

            builder.Property(c => c.FinishedDate)
           .IsRequired()
           .HasColumnName("FinishedDate");

            builder.Property(c => c.DeletedDate)
           .IsRequired()
           .HasColumnName("DeletedDate");

            #region FOREIGN KEYS
            builder.HasOne(x => x.Board)
             .WithMany(x => x.Cards)
                 .HasForeignKey(z => z.BoardId);
            //.OnDelete(DeleteBehavior.Cascade);
            #endregion
        }
    }
}
