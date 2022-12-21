using CovidDailyCases.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CovidDailyCases.Infrastructure.Data.Mappings;

public class CovidCasesMapping : IEntityTypeConfiguration<CovidCases>
{
    public void Configure(EntityTypeBuilder<CovidCases> builder)
    {
        builder.HasKey(p => p.Id);

        builder.HasIndex(x => x.Id)
               .IsUnique();

        builder.Property(x => x.Id)
               .HasColumnType("uuid")
               .HasDefaultValueSql("uuid_generate_v4()")
               .IsRequired();

        builder.Property(p => p.Location)
            .HasColumnType("varchar(25)");

        builder.Property(p => p.Date)
            .HasColumnType("date");

        builder.Property(p => p.Variant)
            .HasColumnType("varchar(15)");

        builder.Property(p => p.NumSequences)
            .HasColumnType("integer");

        builder.Property(p => p.PercSequences)
            .HasColumnType("numeric(5,2)");

        builder.Property(p => p.NumSequencesTotal)
            .HasColumnType("integer");

        builder.ToTable("CovidDailyCases");
    }
}