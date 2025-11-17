using AACalc.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AACalc.Infrastructure.Context;

public sealed class CoreContext(DbContextOptions<CoreContext> options) : DbContext(options)
{
    public DbSet<Item> Items { get; set; }
    public DbSet<Quality> Qualities { get; set; }
    public DbSet<AttributeKeyValue> AttributesKeyValue { get; set; }
    public DbSet<SynthesisPool> SynthesisPools { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Item>(ConfigureItem);
        modelBuilder.Entity<Quality>(ConfigureQuality);
        modelBuilder.Entity<AttributeKeyValue>(ConfigureAttributeKeyValue);
        modelBuilder.Entity<SynthesisPool>(ConfigureSynthesisPool);
    }
    
    private static void ConfigureItem(EntityTypeBuilder<Item> b)
    {
        b.ToTable("items");
        b.HasKey(x => x.Id);

        b.Property(x => x.ItemGroup).IsRequired();
        b.Property(x => x.ItemType).IsRequired();

        b.Property(x => x.Name)
            .HasMaxLength(200)
            .IsRequired();
        
        b.Property(x => x.Icon)
            .HasMaxLength(200)
            .IsRequired();
        
        b.HasMany(i => i.Qualities)
            .WithOne(q => q.Item)
            .HasForeignKey(q => q.ItemId)
            .OnDelete(DeleteBehavior.Cascade);

        b.HasIndex(x => new { x.ItemCategory, x.ItemType, x.ItemGroup });
    }

    private static void ConfigureQuality(EntityTypeBuilder<Quality> b)
    {
        b.ToTable("qualities");
        b.HasKey(x => x.Id);

        b.HasIndex(x => new { x.ItemId });
        b.HasIndex(x => new { x.ItemId, x.QualityType }).IsUnique();
    }

    private static void ConfigureAttributeKeyValue(EntityTypeBuilder<AttributeKeyValue> b)
    {
        b.ToTable("attributes_key_value");
        b.HasKey(x => x.Id);
        
        b.HasOne(s => s.Quality)
            .WithMany(q => q.AttributesKeyValue)
            .HasForeignKey(s => s.QualityId)
            .OnDelete(DeleteBehavior.Cascade);

        b.HasIndex(x => x.QualityId);
        b.HasIndex(x => new { x.QualityId, x.Key }).IsUnique();
    }

    private static void ConfigureSynthesisPool(EntityTypeBuilder<SynthesisPool> b)
    {
        b.ToTable("synthesis_pools");
        b.HasKey(x => x.Id);
        
        b.HasOne(s => s.Quality)
            .WithMany(q => q.SynthesisPools)
            .HasForeignKey(s => s.QualityId)
            .OnDelete(DeleteBehavior.Cascade);

        b.HasIndex(x => x.QualityId);
        b.HasIndex(x => new { x.QualityId, x.Key }).IsUnique();
    }
}