using System;
using System.Collections.Generic;
using diplom.Models;
using Microsoft.EntityFrameworkCore;

namespace diplom.Data;

public partial class DiplomDbContext : DbContext
{
    public DiplomDbContext()
    {
    }

    public DiplomDbContext(DbContextOptions<DiplomDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Group> Groups { get; set; }

    public virtual DbSet<Load> Loads { get; set; }

    public virtual DbSet<Specialization> Specializations { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    public virtual DbSet<SubjectSpecialization> SubjectSpecializations { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    public virtual DbSet<TeacherSubject> TeacherSubjects { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=DiplomDB;Username=postgres;Password=1234");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Group>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("group_pkey");

            entity.ToTable("group");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Course).HasColumnName("course");
            entity.Property(e => e.SpecializationId).HasColumnName("specialization_id");
            entity.Property(e => e.Year).HasColumnName("year");

            entity.HasOne(d => d.Specialization).WithMany(p => p.Groups)
                .HasForeignKey(d => d.SpecializationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("group_specialization_id_fkey");
        });

        modelBuilder.Entity<Load>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Load_pkey");

            entity.ToTable("load");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.AllHoursInFirstSemester).HasColumnName("all_hours_in_first_semester");
            entity.Property(e => e.AllHoursInSecondSemester).HasColumnName("all_hours_in_second_semester");
            entity.Property(e => e.ConsultationTime).HasColumnName("consultation_time");
            entity.Property(e => e.CourseProjectTime).HasColumnName("course_project_time");
            entity.Property(e => e.FirstSemesterTime).HasColumnName("first_semester_time");
            entity.Property(e => e.GroupId).HasColumnName("group_id");
            entity.Property(e => e.LpzOneTime).HasColumnName("lpz_one_time");
            entity.Property(e => e.LpzTwoTime).HasColumnName("lpz_two_time");
            entity.Property(e => e.PracticalTime).HasColumnName("practical_time");
            entity.Property(e => e.SecondSemesterTime).HasColumnName("second_semester_time");
            entity.Property(e => e.SubjectId).HasColumnName("subject_id");
            entity.Property(e => e.TeacherId).HasColumnName("teacher_id");
            entity.Property(e => e.TheoryTime).HasColumnName("theory_time");
            entity.Property(e => e.Total).HasColumnName("total");

            entity.HasOne(d => d.Group).WithMany(p => p.Loads)
                .HasForeignKey(d => d.GroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("load_group_id_fkey");

            entity.HasOne(d => d.Subject).WithMany(p => p.Loads)
                .HasForeignKey(d => d.SubjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("load_subject_id_fkey");

            entity.HasOne(d => d.Teacher).WithMany(p => p.Loads)
                .HasForeignKey(d => d.TeacherId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("load_teacher_id_fkey");
        });

        modelBuilder.Entity<Specialization>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("specialization_pkey");

            entity.ToTable("specialization");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Qualification).HasColumnName("qualification");
            entity.Property(e => e.SpecializationName).HasColumnName("specialization_name");
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("subject_pkey");

            entity.ToTable("subject");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.SubjectName).HasColumnName("subject_name");
        });

        modelBuilder.Entity<SubjectSpecialization>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("subject_specialization_pkey");

            entity.ToTable("subject_specialization");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.SpecializationId).HasColumnName("specialization_id");
            entity.Property(e => e.SubjectId).HasColumnName("subject_id");

            entity.HasOne(d => d.Specialization).WithMany(p => p.SubjectSpecializations)
                .HasForeignKey(d => d.SpecializationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("subject_specialization_specialization_id_fkey");

            entity.HasOne(d => d.Subject).WithMany(p => p.SubjectSpecializations)
                .HasForeignKey(d => d.SubjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("subject_specialization_subject_id_fkey");
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("teacher_pkey");

            entity.ToTable("teacher");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Category).HasColumnName("category");
            entity.Property(e => e.FullName).HasColumnName("full_name");
        });

        modelBuilder.Entity<TeacherSubject>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("teacher_subject_pkey");

            entity.ToTable("teacher_subject");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.SubjectId).HasColumnName("subject_id");
            entity.Property(e => e.TeacherId).HasColumnName("teacher_id");

            entity.HasOne(d => d.Subject).WithMany(p => p.TeacherSubjects)
                .HasForeignKey(d => d.SubjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("teacher_subject_subject_id_fkey");

            entity.HasOne(d => d.Teacher).WithMany(p => p.TeacherSubjects)
                .HasForeignKey(d => d.TeacherId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("teacher_subject_teacher_id_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
