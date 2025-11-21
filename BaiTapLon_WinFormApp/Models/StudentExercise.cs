using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BaiTapLon_WinFormApp.Models;

[PrimaryKey("StudentId", "ExerciseId")]
[Table("student_exercise")]
[Index("ExerciseId", Name = "IX_student_exercise_ExerciseId")]
public partial class StudentExercise
{
    [Key]
    public int StudentId { get; set; }

    [Key]
    public int ExerciseId { get; set; }

    [Column("answer_link", TypeName = "text")]
    public string? AnswerLink { get; set; }

    [Column("description", TypeName = "text")]
    public string? Description { get; set; }

    [Column("score")]
    public double? Score { get; set; }

    [Column("comment_of_teacher", TypeName = "text")]
    public string? CommentOfTeacher { get; set; }

    [Column("comment_private_of_student", TypeName = "text")]
    public string? CommentPrivateOfStudent { get; set; }

    [Column("note", TypeName = "text")]
    public string? Note { get; set; }

    [ForeignKey("ExerciseId")]
    [InverseProperty("StudentExercises")]
    public virtual Exercise Exercise { get; set; } = null!;

    [ForeignKey("StudentId")]
    [InverseProperty("StudentExercises")]
    public virtual Student Student { get; set; } = null!;
}
