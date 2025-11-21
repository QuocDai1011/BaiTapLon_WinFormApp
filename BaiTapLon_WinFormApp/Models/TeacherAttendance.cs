using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BaiTapLon_WinFormApp.Models;

[Table("teacher_attendance")]
[Index("ClassId", Name = "IX_teacher_attendance_class_id")]
[Index("TeacherId", Name = "IX_teacher_attendance_teacher_id")]
public partial class TeacherAttendance
{
    [Key]
    [Column("teacher_attendance_id")]
    public int TeacherAttendanceId { get; set; }

    [Column("teacher_id")]
    public int TeacherId { get; set; }

    [Column("class_id")]
    public int ClassId { get; set; }

    [Column("attendance_date")]
    public DateOnly AttendanceDate { get; set; }

    [Column("check_in_time")]
    public TimeOnly? CheckInTime { get; set; }

    [Column("create_at")]
    public DateOnly? CreateAt { get; set; }

    [Column("update_at")]
    public DateOnly? UpdateAt { get; set; }

    [Column("note", TypeName = "text")]
    public string? Note { get; set; }

    [ForeignKey("ClassId")]
    [InverseProperty("TeacherAttendances")]
    public virtual Class Class { get; set; } = null!;

    [ForeignKey("TeacherId")]
    [InverseProperty("TeacherAttendances")]
    public virtual Teacher Teacher { get; set; } = null!;
}
