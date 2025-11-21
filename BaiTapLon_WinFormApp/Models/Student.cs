using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BaiTapLon_WinFormApp.Models;

[Table("students")]
[Index("UserName", Name = "IX_students_user_name", IsUnique = true)]
public partial class Student
{
    [Key]
    [Column("student_id")]
    public int StudentId { get; set; }

    [Column("user_name")]
    [StringLength(100)]
    [Unicode(false)]
    public string UserName { get; set; } = null!;

    [Column("password")]
    [StringLength(255)]
    [Unicode(false)]
    public string Password { get; set; } = null!;

    [Column("full_name")]
    [StringLength(255)]
    public string FullName { get; set; } = null!;

    [Column("email")]
    [StringLength(255)]
    [Unicode(false)]
    public string Email { get; set; } = null!;

    [Column("gender")]
    public bool Gender { get; set; }

    [Column("address")]
    [StringLength(255)]
    public string Address { get; set; } = null!;

    [Column("date_of_birth")]
    public DateOnly? DateOfBirth { get; set; }

    [Column("phone_number")]
    [StringLength(10)]
    [Unicode(false)]
    public string PhoneNumber { get; set; } = null!;

    [Column("phone_number_of_parents")]
    [StringLength(10)]
    [Unicode(false)]
    public string PhoneNumberOfParents { get; set; } = null!;

    [Column("creat_at")]
    public DateOnly? CreatAt { get; set; }

    [Column("update_at")]
    public DateOnly? UpdateAt { get; set; }

    [Column("is_active")]
    public bool IsActive { get; set; }

    [InverseProperty("Student")]
    public virtual ICollection<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();

    [InverseProperty("Student")]
    public virtual ICollection<ResultExam> ResultExams { get; set; } = new List<ResultExam>();

    [InverseProperty("Student")]
    public virtual ICollection<StudentAttendance> StudentAttendances { get; set; } = new List<StudentAttendance>();

    [InverseProperty("Student")]
    public virtual ICollection<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();

    [InverseProperty("Student")]
    public virtual ICollection<StudentExercise> StudentExercises { get; set; } = new List<StudentExercise>();

    [ForeignKey("StudentId")]
    [InverseProperty("Students")]
    public virtual ICollection<Class> Classes { get; set; } = new List<Class>();
}
