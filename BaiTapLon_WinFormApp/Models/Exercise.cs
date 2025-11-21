using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BaiTapLon_WinFormApp.Models;

[Table("exercise")]
[Index("TeacherId", Name = "IX_exercise_teacher_id")]
public partial class Exercise
{
    [Key]
    [Column("exercise_id")]
    public int ExerciseId { get; set; }

    [Column("teacher_id")]
    public int TeacherId { get; set; }

    [Column("topic")]
    [StringLength(255)]
    public string Topic { get; set; } = null!;

    [Column("description")]
    [StringLength(255)]
    public string Description { get; set; } = null!;

    [Column("suggest")]
    [StringLength(255)]
    public string Suggest { get; set; } = null!;

    [Column("image_link")]
    [StringLength(255)]
    [Unicode(false)]
    public string ImageLink { get; set; } = null!;

    [Column("note")]
    [StringLength(255)]
    [Unicode(false)]
    public string Note { get; set; } = null!;

    [InverseProperty("Exercise")]
    public virtual ICollection<StudentExercise> StudentExercises { get; set; } = new List<StudentExercise>();

    [ForeignKey("TeacherId")]
    [InverseProperty("Exercises")]
    public virtual Teacher Teacher { get; set; } = null!;
}
