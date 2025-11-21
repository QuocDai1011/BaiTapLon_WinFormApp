using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BaiTapLon_WinFormApp.Models;

[PrimaryKey("StudentId", "CourseId")]
[Table("student_course")]
[Index("CourseId", Name = "IX_student_course_course_id")]
public partial class StudentCourse
{
    [Key]
    [Column("student_id")]
    public int StudentId { get; set; }

    [Key]
    [Column("course_id")]
    public int CourseId { get; set; }

    [Column("discount_type")]
    [StringLength(20)]
    [Unicode(false)]
    public string DiscountType { get; set; } = null!;

    [Column("discount_value", TypeName = "decimal(10, 3)")]
    public decimal DiscountValue { get; set; }

    public DateTime? CreateAt { get; set; }

    public DateTime? UpdateAt { get; set; }

    [ForeignKey("CourseId")]
    [InverseProperty("StudentCourses")]
    public virtual Course Course { get; set; } = null!;

    [InverseProperty("StudentCourse")]
    public virtual Receipt? Receipt { get; set; }

    [ForeignKey("StudentId")]
    [InverseProperty("StudentCourses")]
    public virtual Student Student { get; set; } = null!;
}
