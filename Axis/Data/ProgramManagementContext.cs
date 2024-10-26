using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgramManagement.Models;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace ProgramManagement.Data;

public class ProgramManagementContext : DbContext
{
    public ProgramManagementContext(DbContextOptions<ProgramManagementContext> options)
        : base(options)
    {
    }

    public DbSet<Project> Projects { get; set; }
    public DbSet<YLine> YLines { get; set; }
    public DbSet<Competitor> Competitors { get; set; }
    public DbSet<ProjectNote> ProjectNotes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Project Configuration
        modelBuilder.Entity<Project>(entity =>
        {
            entity.ToTable("CS_EXP_Project_Translation");
            entity.HasKey(e => e.ProjectId);
            // Other configurations from your existing ConfigureProject method
        });

        // YLine Configuration
        modelBuilder.Entity<YLine>(ConfigureYLine);

        // Competitor Configuration
        modelBuilder.Entity<Competitor>(ConfigureCompetitor);

        // ProjectNote Configuration
        modelBuilder.Entity<ProjectNote>(ConfigureProjectNote);

        // Add any database seeding here if needed
        // SeedData(modelBuilder);
    }

    private void ConfigureYLine(EntityTypeBuilder<YLine> builder)
    {
        builder.ToTable("YLines");

        builder.HasKey(e => e.YLineId);

        builder.Property(e => e.ProjectId)
            .IsRequired()
            .HasMaxLength(50)
            .HasComment("Reference to the parent project");

        builder.Property(e => e.IPANumber)
            .IsRequired()
            .HasMaxLength(50)
            .HasComment("IPA number");

        builder.Property(e => e.MarketNumber)
            .IsRequired()
            .HasMaxLength(50)
            .HasComment("Market number");

        builder.Property(e => e.ProductCode)
            .IsRequired()
            .HasMaxLength(50)
            .HasComment("Product code");

        builder.Property(e => e.IsPreAward)
            .HasDefaultValue(false)
            .HasComment("Indicates if this is a pre-award Y-Line");

        builder.Property(e => e.IsOptional)
            .HasDefaultValue(false)
            .HasComment("Indicates if this is an optional Y-Line");

        // Indexes
        builder.HasIndex(e => e.ProjectId)
            .HasDatabaseName("IX_YLines_ProjectId");

        builder.HasIndex(e => new { e.ProjectId, e.IPANumber })
            .HasDatabaseName("IX_YLines_ProjectId_IPANumber")
            .IsUnique();
    }

    private void ConfigureCompetitor(EntityTypeBuilder<Competitor> builder)
    {
        builder.ToTable("Competitors");

        builder.HasKey(e => e.CompetitorId);

        builder.Property(e => e.ProjectId)
            .IsRequired()
            .HasMaxLength(50)
            .HasComment("Reference to the parent project");

        builder.Property(e => e.PayorName)
            .IsRequired()
            .HasMaxLength(100)
            .HasComment("Name of the payor");

        builder.Property(e => e.Product)
            .IsRequired()
            .HasMaxLength(100)
            .HasComment("Product name");

        builder.Property(e => e.CSPIndicator)
            .HasDefaultValue(false)
            .HasComment("CSP indicator flag");

        builder.Property(e => e.EIIndicator)
            .HasDefaultValue(false)
            .HasComment("EI indicator flag");

        builder.Property(e => e.MRIndicator)
            .HasDefaultValue(false)
            .HasComment("MR indicator flag");

        builder.Property(e => e.SPCIndicator)
            .HasMaxLength(50)
            .HasComment("SPC indicator value");

        // Indexes
        builder.HasIndex(e => e.ProjectId)
            .HasDatabaseName("IX_Competitors_ProjectId");

        builder.HasIndex(e => new { e.ProjectId, e.PayorName, e.Product })
            .HasDatabaseName("IX_Competitors_ProjectId_PayorName_Product")
            .IsUnique();
    }

    private void ConfigureProjectNote(EntityTypeBuilder<ProjectNote> builder)
    {
        builder.ToTable("ProjectNotes");

        builder.HasKey(e => e.NoteId);

        builder.Property(e => e.ProjectId)
            .IsRequired()
            .HasMaxLength(50)
            .HasComment("Reference to the parent project");

        builder.Property(e => e.Category)
            .IsRequired()
            .HasMaxLength(50)
            .HasComment("Note category");

        builder.Property(e => e.Notes)
            .IsRequired()
            .HasColumnType("nvarchar(max)")
            .HasComment("Note content");

        builder.Property(e => e.LoadDate)
            .HasColumnType("datetime2")
            .HasDefaultValueSql("GETUTCDATE()")
            .HasComment("Date when the note was created");

        builder.Property(e => e.EditDate)
            .HasColumnType("datetime2")
            .HasDefaultValueSql("GETUTCDATE()")
            .HasComment("Date when the note was last edited");

        builder.Property(e => e.OriginalMSID)
            .IsRequired()
            .HasMaxLength(100)
            .HasComment("MSID of the user who created the note");

        builder.Property(e => e.LastEditMSID)
            .HasMaxLength(100)
            .HasComment("MSID of the last user to edit the note");

        // Indexes
        builder.HasIndex(e => e.ProjectId)
            .HasDatabaseName("IX_ProjectNotes_ProjectId");

        builder.HasIndex(e => e.Category)
            .HasDatabaseName("IX_ProjectNotes_Category");

        builder.HasIndex(e => e.LoadDate)
            .HasDatabaseName("IX_ProjectNotes_LoadDate");
    }

    // Optional: Add seed data method if needed
    private void SeedData(ModelBuilder modelBuilder)
    {
        // Add any seed data here if needed
        /*
        modelBuilder.Entity<Project>().HasData(
            new Project 
            { 
                ProjectId = "PROJ001",
                ProjectType = "Standard",
                ProjectDescription = "Initial Test Project",
                Status = "Active",
                LastEditDate = DateTime.UtcNow,
                LastEditMSID = "SYSTEM"
            }
        );
        */
    }
}
