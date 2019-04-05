using System;

namespace VanTaiDuongBo.Modules.VanTaiDuongBo.Models
{
    public class DonViVanTaiModel
    {
        public int? TotalCount { get; set; }
        public long? RowNumber { get; set; }
        public long ID { get; set; }
        public string SoGiayPhep { get; set; }
        public int? CapLan { get; set; }
        public string NgayCap { get; set; }
        public string NgayHetHan { get; set; }
        public bool? ThuHoiGiayPhep { get; set; }
        public bool? DaThayDoi { get; set; }
        public DateTime? NgayBatDauThuHoi { get; set; }
        public Nullable<long> DonViVanTaiID { get; set; }
        public string TenDonVi { get; set; }
    }
}