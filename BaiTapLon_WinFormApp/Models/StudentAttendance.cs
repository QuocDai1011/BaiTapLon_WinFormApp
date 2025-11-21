using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BaiTapLon_WinFormApp.Models;

[Table("student_attendance")]
[Index("ClassId", Name = "IX_student_attendance_class_id")]
[Index("StudentId", Name = "IX_student_attendance_student_id")]
public partial class StudentAttendance
{
    [Key]
    [Column("student_attendance_id")]
    public int StudentAttendanceId { get; set; }

    [Column("student_id")]
    public int StudentId { get; set; }

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
    [InverseProperty("StudentAttendances")]
    public virtual Class Class { get; set; } = null!;

    [ForeignKey("StudentId")]
    [InverseProperty("StudentAttendances")]
    public virtual Student Student { get; set; } = null!;
}
