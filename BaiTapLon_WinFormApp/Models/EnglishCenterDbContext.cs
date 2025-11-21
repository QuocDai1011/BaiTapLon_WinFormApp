using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BaiTapLon_WinFormApp.Models;

public partial class EnglishCenterDbContext : DbContext
{
    public EnglishCenterDbContext()
    {
    }

    public EnglishCenterDbContext(DbContextOptions<EnglishCenterDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Class> Classes { get; set; }

    public virtual DbSet<CommuneDistrict> CommuneDistricts { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<ExamType> ExamTypes { get; set; }

    public virtual DbSet<Exercise> Exercises { get; set; }

    public virtual DbSet<Expertise> Expertises { get; set; }

    public virtual DbSet<ProvinceCity> ProvinceCities { get; set; }

    public virtual DbSet<Receipt> Receipts { get; set; }

    public virtual DbSet<RefreshToken> RefreshTokens { get; set; }

    public virtual DbSet<ResultExam> ResultExams { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<StudentAttendance> StudentAttendances { get; set; }

    public virtual DbSet<StudentCourse> StudentCourses { get; set; }

    public virtual DbSet<StudentExercise> StudentExercises { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    public virtual DbSet<TeacherAttendance> TeacherAttendances { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost,1444;Database=english_center_management_dev;User Id=english_center_manager;Password=Abc1234@;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Class>(entity =>
        {
            entity.HasMany(d => d.Courses).WithMany(p => p.Classes)
                .UsingEntity<Dictionary<string, object>>(
                    "ClassCourse",
                    r => r.HasOne<Course>().WithMany().HasForeignKey("CourseId"),
                    l => l.HasOne<Class>().WithMany().HasForeignKey("ClassId"),
                    j =>
                    {
                        j.HasKey("ClassId", "CourseId");
                        j.ToTable("class_course");
                        j.HasIndex(new[] { "CourseId" }, "IX_class_course_course_id");
                        j.IndexerProperty<int>("ClassId").HasColumnName("class_id");
                        j.IndexerProperty<int>("CourseId").HasColumnName("course_id");
                    });
        });

        modelBuilder.Entity<RefreshToken>(entity =>
        {
            entity.HasKey(e => e.RefreshTokenId).HasName("PK__refresh___B0A1F7C7FD1AE70B");

            entity.HasOne(d => d.Admin).WithMany(p => p.RefreshTokens).HasConstraintName("FK__refresh_t__admin__1AD3FDA4");

            entity.HasOne(d => d.Student).WithMany(p => p.RefreshTokens).HasConstraintName("FK__refresh_t__stude__18EBB532");

            entity.HasOne(d => d.Teacher).WithMany(p => p.RefreshTokens).HasConstraintName("FK__refresh_t__teach__19DFD96B");
        });

        modelBuilder.Entity<ResultExam>(entity =>
        {
            entity.HasOne(d => d.ExamType).WithMany(p => p.ResultExams).OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasMany(d => d.Classes).WithMany(p => p.Students)
                .UsingEntity<Dictionary<string, object>>(
                    "StudentClass",
                    r => r.HasOne<Class>().WithMany().HasForeignKey("ClassId"),
                    l => l.HasOne<Student>().WithMany().HasForeignKey("StudentId"),
                    j =>
                    {
                        j.HasKey("StudentId", "ClassId");
                        j.ToTable("student_class");
                        j.HasIndex(new[] { "ClassId" }, "IX_student_class_class_id");
                        j.IndexerProperty<int>("StudentId").HasColumnName("student_id");
                        j.IndexerProperty<int>("ClassId").HasColumnName("class_id");
                    });
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasMany(d => d.Classes).WithMany(p => p.Teachers)
                .UsingEntity<Dictionary<string, object>>(
                    "TeacherClass",
                    r => r.HasOne<Class>().WithMany().HasForeignKey("ClassId"),
                    l => l.HasOne<Teacher>().WithMany().HasForeignKey("TeacherId"),
                    j =>
                    {
                        j.HasKey("TeacherId", "ClassId");
                        j.ToTable("teacher_class");
                        j.HasIndex(new[] { "ClassId" }, "IX_teacher_class_class_id");
                        j.IndexerProperty<int>("TeacherId").HasColumnName("teacher_id");
                        j.IndexerProperty<int>("ClassId").HasColumnName("class_id");
                    });

            entity.HasMany(d => d.Courses).WithMany(p => p.Teachers)
                .UsingEntity<Dictionary<string, object>>(
                    "TeacherCourse",
                    r => r.HasOne<Course>().WithMany().HasForeignKey("CourseId"),
                    l => l.HasOne<Teacher>().WithMany().HasForeignKey("TeacherId"),
                    j =>
                    {
                        j.HasKey("TeacherId", "CourseId");
                        j.ToTable("teacher_course");
                        j.HasIndex(new[] { "CourseId" }, "IX_teacher_course_course_id");
                        j.IndexerProperty<int>("TeacherId").HasColumnName("teacher_id");
                        j.IndexerProperty<int>("CourseId").HasColumnName("course_id");
                    });

            entity.HasMany(d => d.Expertises).WithMany(p => p.Teachers)
                .UsingEntity<Dictionary<string, object>>(
                    "ExpertiseTeacher",
                    r => r.HasOne<Expertise>().WithMany().HasForeignKey("ExpertiseId"),
                    l => l.HasOne<Teacher>().WithMany().HasForeignKey("TeacherId"),
                    j =>
                    {
                        j.HasKey("TeacherId", "ExpertiseId");
                        j.ToTable("expertise_teacher");
                        j.HasIndex(new[] { "ExpertiseId" }, "IX_expertise_teacher_expertise_id");
                        j.IndexerProperty<int>("TeacherId").HasColumnName("teacher_id");
                        j.IndexerProperty<int>("ExpertiseId").HasColumnName("expertise_id");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
