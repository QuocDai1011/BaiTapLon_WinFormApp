using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BaiTapLon_WinFormApp.Models;

[Table("receipt")]
[Index("StudentId", "CourseId", Name = "IX_receipt_student_id_course_id", IsUnique = true)]
public partial class Receipt
{
    [Key]
    [Column("receipt_id")]
    public int ReceiptId { get; set; }

    [Column(TypeName = "decimal(18, 3)")]
    public decimal Amount { get; set; }

    [Column("payment_date")]
    public DateTime? PaymentDate { get; set; }

    [Column("payment_method")]
    [StringLength(10)]
    [Unicode(false)]
    public string PaymentMethod { get; set; } = null!;

    [Column("status")]
    [StringLength(20)]
    [Unicode(false)]
    public string Status { get; set; } = null!;

    [Column("student_id")]
    public int StudentId { get; set; }

    [Column("course_id")]
    public int CourseId { get; set; }

    [ForeignKey("StudentId, CourseId")]
    [InverseProperty("Receipt")]
    public virtual StudentCourse StudentCourse { get; set; } = null!;
}
