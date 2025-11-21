using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BaiTapLon_WinFormApp.Models;

[Table("class")]
public partial class Class
{
    [Key]
    [Column("class_id")]
    public int ClassId { get; set; }

    [Column("class_code")]
    [StringLength(20)]
    [Unicode(false)]
    public string ClassCode { get; set; } = null!;

    [Column("class_name")]
    [StringLength(255)]
    public string ClassName { get; set; } = null!;

    [Column("max_student")]
    public int MaxStudent { get; set; }

    [Column("current_student")]
    public int CurrentStudent { get; set; }

    [Column("start_date")]
    public DateOnly StartDate { get; set; }

    [Column("end_date")]
    public DateOnly EndDate { get; set; }

    [Column("shift")]
    public int Shift { get; set; }

    [Column("status")]
    public bool Status { get; set; }

    [Column("note")]
    [StringLength(255)]
    public string? Note { get; set; }

    [Column("create_at")]
    public DateOnly CreateAt { get; set; }

    [Column("update_at")]
    public DateOnly UpdateAt { get; set; }

    [Column("online_meeting_link", TypeName = "text")]
    public string? OnlineMeetingLink { get; set; }

    [InverseProperty("Class")]
    public virtual ICollection<StudentAttendance> StudentAttendances { get; set; } = new List<StudentAttendance>();

    [InverseProperty("Class")]
    public virtual ICollection<TeacherAttendance> TeacherAttendances { get; set; } = new List<TeacherAttendance>();

    [ForeignKey("ClassId")]
    [InverseProperty("Classes")]
    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();

    [ForeignKey("ClassId")]
    [InverseProperty("Classes")]
    public virtual ICollection<Student> Students { get; set; } = new List<Student>();

    [ForeignKey("ClassId")]
    [InverseProperty("Classes")]
    public virtual ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
}
