using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BaiTapLon_WinFormApp.Models;

[Table("course")]
public partial class Course
{
    [Key]
    [Column("course_id")]
    public int CourseId { get; set; }

    [Column("course_code")]
    [StringLength(20)]
    public string CourseCode { get; set; } = null!;

    [Column("course_name")]
    [StringLength(255)]
    public string CourseName { get; set; } = null!;

    [Column("tutition_fee", TypeName = "decimal(18, 3)")]
    public decimal TutitionFee { get; set; }

    [Column("number_sessions")]
    public int NumberSessions { get; set; }

    [Column("description")]
    [StringLength(255)]
    public string Description { get; set; } = null!;

    [Column("level")]
    [StringLength(10)]
    [Unicode(false)]
    public string Level { get; set; } = null!;

    [Column("create_at")]
    public DateTime? CreateAt { get; set; }

    [Column("update_at")]
    public DateTime? UpdateAt { get; set; }

    [Column("avatar_link")]
    [Unicode(false)]
    public string? AvatarLink { get; set; }

    [InverseProperty("Course")]
    public virtual ICollection<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();

    [ForeignKey("CourseId")]
    [InverseProperty("Courses")]
    public virtual ICollection<Class> Classes { get; set; } = new List<Class>();

    [ForeignKey("CourseId")]
    [InverseProperty("Courses")]
    public virtual ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
}
