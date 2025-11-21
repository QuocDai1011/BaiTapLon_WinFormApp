using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BaiTapLon_WinFormApp.Models;

[Table("commune_district")]
[Index("ProvinceCityId", Name = "IX_commune_district_province_city_id")]
public partial class CommuneDistrict
{
    [Key]
    [Column("commune_district_id")]
    public int CommuneDistrictId { get; set; }

    [Column("commune_district")]
    [StringLength(255)]
    public string CommuneDistrict1 { get; set; } = null!;

    [Column("province_city_id")]
    public int ProvinceCityId { get; set; }

    [ForeignKey("ProvinceCityId")]
    [InverseProperty("CommuneDistricts")]
    public virtual ProvinceCity ProvinceCity { get; set; } = null!;
}
