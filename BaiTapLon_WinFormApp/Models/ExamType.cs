using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BaiTapLon_WinFormApp.Models;

[Table("exam_type")]
public partial class ExamType
{
    [Key]
    public int ExamTypeId { get; set; }

    [Column("exam_result_name")]
    [StringLength(255)]
    public string ExamResultName { get; set; } = null!;

    [Column("exam_result_code")]
    [StringLength(10)]
    [Unicode(false)]
    public string ExamResultCode { get; set; } = null!;

    [InverseProperty("ExamType")]
    public virtual ICollection<ResultExam> ResultExams { get; set; } = new List<ResultExam>();
}
