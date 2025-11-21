using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BaiTapLon_WinFormApp.Models;

[Table("result_exam")]
[Index("ExamTypeId", Name = "IX_result_exam_ExamTypeId")]
[Index("StudentId", Name = "IX_result_exam_student_id")]
public partial class ResultExam
{
    [Key]
    [Column("result_exam_id")]
    public int ResultExamId { get; set; }

    [Column("result_listening")]
    public double ResultListening { get; set; }

    [Column("result_reading")]
    public double ResultReading { get; set; }

    [Column("result_writing")]
    public double ResultWriting { get; set; }

    [Column("result_speaking")]
    public double ResultSpeaking { get; set; }

    [Column("student_id")]
    public int StudentId { get; set; }

    public int ExamTypeId { get; set; }

    [ForeignKey("ExamTypeId")]
    [InverseProperty("ResultExams")]
    public virtual ExamType ExamType { get; set; } = null!;

    [ForeignKey("StudentId")]
    [InverseProperty("ResultExams")]
    public virtual Student Student { get; set; } = null!;
}
