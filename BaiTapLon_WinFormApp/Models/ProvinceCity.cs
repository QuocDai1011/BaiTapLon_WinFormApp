using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BaiTapLon_WinFormApp.Models;

[Table("province_city")]
public partial class ProvinceCity
{
    [Key]
    [Column("province_city_id")]
    public int ProvinceCityId { get; set; }

    [Column("province_city_name")]
    [StringLength(255)]
    public string ProvinceCityName { get; set; } = null!;

    [InverseProperty("ProvinceCity")]
    public virtual ICollection<CommuneDistrict> CommuneDistricts { get; set; } = new List<CommuneDistrict>();
}
