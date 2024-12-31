using CF.EF.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CF.EF.API.Configs
{
    public class AuthorModelDbConfig : IEntityTypeConfiguration<AuthorModel>
    {
        public void Configure(EntityTypeBuilder<AuthorModel> builder)
        {
            builder.ToTable("Author");

            builder.HasKey(x => x.AuthorId);

            builder.Property(x => x.AuthorId)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.AuthorName)
                .IsRequired()
                .HasMaxLength(250);

            builder.Property(x => x.AuthorEmail)
                .HasMaxLength(250);

            builder.Property(x => x.Remarks)
                .HasMaxLength(500);

            builder.HasData(
                new AuthorModel
                {
                    AuthorId = 1,
                    AuthorName = "Aijaz",
                    AuthorEmail = "aijaz.ali@hotmail.com"
                }
            );
        }
    }
}
