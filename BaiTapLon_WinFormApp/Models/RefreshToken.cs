using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BaiTapLon_WinFormApp.Models;

[Table("refresh_token")]
public partial class RefreshToken
{
    [Key]
    [Column("refresh_token_id")]
    public long RefreshTokenId { get; set; }

    [Column("refresh_token_content", TypeName = "text")]
    public string RefreshTokenContent { get; set; } = null!;

    [Column("end_date", TypeName = "datetime")]
    public DateTime? EndDate { get; set; }

    [Column("create_at", TypeName = "datetime")]
    public DateTime? CreateAt { get; set; }

    [Column("revoked", TypeName = "datetime")]
    public DateTime? Revoked { get; set; }

    [Column("student_id")]
    public int? StudentId { get; set; }

    [Column("teacher_id")]
    public int? TeacherId { get; set; }

    [Column("admin_id")]
    public int? AdminId { get; set; }

    [ForeignKey("AdminId")]
    [InverseProperty("RefreshTokens")]
    public virtual Admin? Admin { get; set; }

    [ForeignKey("StudentId")]
    [InverseProperty("RefreshTokens")]
    public virtual Student? Student { get; set; }

    [ForeignKey("TeacherId")]
    [InverseProperty("RefreshTokens")]
    public virtual Teacher? Teacher { get; set; }
}
