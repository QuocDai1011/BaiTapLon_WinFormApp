using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BaiTapLon_WinFormApp.Models;

[Table("admins")]
[Index("UserName", Name = "IX_admins_user_name", IsUnique = true)]
public partial class Admin
{
    [Key]
    [Column("admin_id")]
    public int AdminId { get; set; }

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

    [Column("salary", TypeName = "decimal(18, 3)")]
    public decimal Salary { get; set; }

    [Column("create_at")]
    public DateOnly? CreateAt { get; set; }

    [Column("update_at")]
    public DateOnly? UpdateAt { get; set; }

    [Column("is_active")]
    public bool IsActive { get; set; }

    [Column("is_super")]
    public bool IsSuper { get; set; }

    [Column("is_student_manager")]
    public bool IsStudentManager { get; set; }

    [Column("is_teacher_manager")]
    public bool IsTeacherManager { get; set; }

    [InverseProperty("Admin")]
    public virtual ICollection<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();
}
