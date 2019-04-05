namespace VanTaiDuongBo.Modules.VanTaiDuongBo.Models.SoLieuXe
{
    public class DanhSachXeModel
    {
        public string BienSoXe { get; set; }
        public string TenLoaiHinhXe { get; set; }
        public long? DonViVanTaiID { get; set; }
        public string TenDonVi { get; set; }
        public int? SoGhe { get; set; }
        public double? TaiTrong { get; set; }
        public int? TrongTai { get; set; }
        public int? LoaiXe { get; set; }
        public int? SoGiuong { get; set; }
        public bool? GiuongNam { get; set; }
        public bool? GheNam { get; set; }
        public int? SoChoDung { get; set; }
        public bool? DaThayDoi { get; set; }
    }
}