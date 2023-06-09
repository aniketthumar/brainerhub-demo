using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BrainerHubDemoModel.POcSampleDB;

public partial class POCSampleContext : DbContext
{
    public POCSampleContext(DbContextOptions<POCSampleContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ContContact> ContContacts { get; set; }

    public virtual DbSet<ConttContactType> ConttContactTypes { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<StatStatus> StatStatuses { get; set; }

    public virtual DbSet<StlogStatusLog> StlogStatusLogs { get; set; }

    public virtual DbSet<StudStudent> StudStudents { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ContContact>(entity =>
        {
            entity.HasKey(e => e.ContContactId).HasName("CONT_PK_ContID");

            entity.ToTable("CONT_Contact", tb => tb.HasComment("CONT_Contact_Student"));

            entity.Property(e => e.ContActive).HasDefaultValueSql("((1))");
            entity.Property(e => e.ContCreateDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.ContCreateUser).HasDefaultValueSql("(suser_sname())");
            entity.Property(e => e.ContFullName).HasComputedColumnSql("((isnull(ltrim(rtrim([CONT_TitlePrefix]))+' ','')+isnull(ltrim(rtrim([CONT_FirstName])),''))+isnull(' '+ltrim(rtrim([CONT_LastName])),''))", true);
            entity.Property(e => e.ContTypeId).HasDefaultValueSql("((1))");
            entity.Property(e => e.ContUpdateDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.ContUpdateUser).HasDefaultValueSql("(suser_sname())");
            entity.Property(e => e.ContVisible).HasDefaultValueSql("((1))");

            entity.HasOne(d => d.ContType).WithMany(p => p.ContContacts)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CONT_Contact_CONTT_ContactType");
        });

        modelBuilder.Entity<ConttContactType>(entity =>
        {
            entity.HasKey(e => e.ConttTypeId).HasName("PK_CONTT");

            entity.Property(e => e.ConttActive).HasDefaultValueSql("((1))");
            entity.Property(e => e.ConttCreateDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.ConttCreateUser).HasDefaultValueSql("(suser_name())");
            entity.Property(e => e.ConttUpdateDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.ConttUpdateUser).HasDefaultValueSql("(suser_name())");
            entity.Property(e => e.ConttVisible).HasDefaultValueSql("((1))");
        });

        modelBuilder.Entity<StatStatus>(entity =>
        {
            entity.HasKey(e => e.StatStatusId).HasName("PK_STAT");

            entity.Property(e => e.StatActive).HasDefaultValueSql("((1))");
            entity.Property(e => e.StatCreateDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.StatCreateUser).HasDefaultValueSql("(suser_name())");
            entity.Property(e => e.StatObjectCode).HasDefaultValueSql("('')");
            entity.Property(e => e.StatStatusCode).HasDefaultValueSql("('')");
            entity.Property(e => e.StatStatusName).HasDefaultValueSql("('')");
            entity.Property(e => e.StatUpdateDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.StatUpdateUser).HasDefaultValueSql("(suser_name())");
        });

        modelBuilder.Entity<StlogStatusLog>(entity =>
        {
            entity.Property(e => e.StlogCreateDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.StlogCreateUser).HasDefaultValueSql("(suser_name())");
            entity.Property(e => e.StlogObjectCode).HasDefaultValueSql("('')");
            entity.Property(e => e.StlogStartDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.StlogUpdateDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.StlogUpdateUser).HasDefaultValueSql("(suser_name())");

            entity.HasOne(d => d.StlogStatus).WithMany(p => p.StlogStatusLogs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_STLOG_StatusLog_STAT_Status");
        });

        modelBuilder.Entity<StudStudent>(entity =>
        {
            entity.HasKey(e => e.StudStudentId).HasName("PK_STUD_Student_1");

            entity.Property(e => e.StudActive).HasDefaultValueSql("((1))");
            entity.Property(e => e.StudCreateDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.StudCreateUser).HasDefaultValueSql("(suser_name())");
            entity.Property(e => e.StudStatusDays).HasComputedColumnSql("(datediff(day,[STUD_StatusDate],getdate()))", false);
            entity.Property(e => e.StudUpdateDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.StudUpdateUser).HasDefaultValueSql("(suser_name())");
            entity.Property(e => e.StudVisible).HasDefaultValueSql("((1))");

            entity.HasOne(d => d.StudContact).WithMany(p => p.StudStudents)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_STUD_Student_CONT_Contact");

            entity.HasOne(d => d.StudStatus).WithMany(p => p.StudStudents).HasConstraintName("FK_STUD_Student_STAT_Status");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
