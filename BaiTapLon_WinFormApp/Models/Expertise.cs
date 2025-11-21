using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BaiTapLon_WinFormApp.Models;

[Table("expertise")]
public partial class Expertise
{
    [Key]
    public int ExpertiseId { get; set; }

    [Column("expertise_name")]
    [StringLength(255)]
    public string ExpertiseName { get; set; } = null!;

    [ForeignKey("ExpertiseId")]
    [InverseProperty("Expertises")]
    public virtual ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
}
