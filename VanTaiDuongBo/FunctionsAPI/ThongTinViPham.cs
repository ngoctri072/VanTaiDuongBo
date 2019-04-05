using System.Collections.Generic;
using VanTaiDuongBo.Modules.VanTaiDuongBo.CallAPIProvider;
using VanTaiDuongBo.Modules.VanTaiDuongBo.Models;
using VanTaiDuongBo.Modules.VanTaiDuongBo.Models.ThongTinViPham;

namespace VanTaiDuongBo.Modules.VanTaiDuongBo.FunctionsAPI
{
    public class ThongTinViPham
    {
        GetResponseFromAPI callAPI = new GetResponseFromAPI();
        APIUrl apiUrl = new APIUrl();
        public List<ThongTinViPhamPartialModel> GetByDonViVanTai(long DonViVanTaiID)
        {
            List<ThongTinViPhamPartialModel> listthongTinViPhamPartialModels = new List<ThongTinViPhamPartialModel>();

            //Lấy Danh sách hành vi vi phạm
            var urlCallViPhamChung = apiUrl.urlAPI + "ThongTinViPham/Get_ByDonViVanTai?donvivantaiID=" + DonViVanTaiID;
            List<ThongTinChungModel> listThongTinChungViPham = callAPI.CallAPIViPhamByDonViVanTai(urlCallViPhamChung);
            if (listThongTinChungViPham.Count == 0)
            {
                listthongTinViPhamPartialModels = null;
            }
            else
            {
                foreach (var chitiet in listThongTinChungViPham)
                {
                    ThongTinViPhamPartialModel thongTinViPhamPartialModel = new ThongTinViPhamPartialModel();

                    //Kiểm tra dữ liệu NULL
                    thongTinViPhamPartialModel.ViPhamID = chitiet.ViPhamID;
                    thongTinViPhamPartialModel.TenViPham = chitiet.TenViPham;
                    thongTinViPhamPartialModel.SoLanViPham = chitiet.SoLanViPham;
                    thongTinViPhamPartialModel.TongLanViPham = chitiet.TongLanViPham;

                    //Lấy thông tin chi tiết loại xử lý từng Hành vi
                    thongTinViPhamPartialModel.HanhViXuLyViPham = GetChiTietHanhViXuLy(DonViVanTaiID, chitiet.ViPhamID.Value);

                    listthongTinViPhamPartialModels.Add(thongTinViPhamPartialModel);
                }
                return listthongTinViPhamPartialModels;
            }

            return listthongTinViPhamPartialModels;
        }

        //Get Thông tin chung vi phạm chi tiết: Bao gồm thông tin vi phạm theo Loại hình --> Danh sách xe theo Loại hình.
        public List<ChiTietViPhamPartialModel> GetThongTinViPhamChiTiet(long DonViVanTaiID)
        {
            List<ChiTietViPhamPartialModel> listChiTietViPhamPartialModels = new List<ChiTietViPhamPartialModel>();
            //Lấy thông tin vi phạm theo Loại hình
            var urlCallViPhamByLoaiHinhVanTai = apiUrl.urlAPI + "ThongTinViPham/Get_ByLoaiHinhVanTai?donvivantaiID=" + DonViVanTaiID;
            List<ViPhamByLoaiHinhModel> listViPhamByLoaiHinhVanTai = callAPI.CallAPIViPhamByLoaiHinhVanTai(urlCallViPhamByLoaiHinhVanTai);
            if (listViPhamByLoaiHinhVanTai.Count == 0)
            {
                listChiTietViPhamPartialModels = null;
            }
            else
            {
                foreach (var loaihinh in listViPhamByLoaiHinhVanTai)
                {
                    ChiTietViPhamPartialModel chiTietViPhamPartialModel = new ChiTietViPhamPartialModel();

                    chiTietViPhamPartialModel.LoaiHinhXeID = loaihinh.LoaiHinhXeID;
                    chiTietViPhamPartialModel.TenLoaiHinhXe = loaihinh.TenLoaiHinhXe;
                    chiTietViPhamPartialModel.ViPhamID = loaihinh.ViPhamID;
                    chiTietViPhamPartialModel.TenViPham = loaihinh.TenViPham;
                    chiTietViPhamPartialModel.SoLanViPham = loaihinh.SoLanViPham;
                    chiTietViPhamPartialModel.TongLanViPham = loaihinh.TongLanViPham;

                    //Lấy danh sách xe theo loại hình xe
                    chiTietViPhamPartialModel.listPhuongTienModels = GetByPhuongTien(DonViVanTaiID, loaihinh.LoaiHinhXeID.Value, loaihinh.ViPhamID.Value);

                    //Lấy danh sách chi tiết Hành vi xử lý
                    chiTietViPhamPartialModel.hanhViXuLyViPhamModels = GetChiTietHanhViXuLyDetail(DonViVanTaiID, loaihinh.ViPhamID.Value, loaihinh.LoaiHinhXeID.Value);

                    listChiTietViPhamPartialModels.Add(chiTietViPhamPartialModel);
                }
                return listChiTietViPhamPartialModels;
            }
            return listChiTietViPhamPartialModels;
        }

        //Get danh sách xe vi phạm theo Loại hình vận tải
        public List<ListPhuongTienPartialModel> GetByPhuongTien(long DonViVanTaiID, long LoaiHinhVanTaiID, long ViPhamID)
        {
            List<ListPhuongTienPartialModel> listPhuongTienModelPartialModels = new List<ListPhuongTienPartialModel>();
            var urlCallViPhamPhuongTien = apiUrl.urlAPI + "ThongTinViPham/Get_ByPhuongTienVanTai?donvivantaiID=" + DonViVanTaiID + "&loaihinhxeID=" + LoaiHinhVanTaiID + "&viphamID=" + ViPhamID;
            List<ListPhuongTienModel> listPhuongTienViPham = callAPI.CallAPIViPhamByPhuongTien(urlCallViPhamPhuongTien);

            if (listPhuongTienViPham.Count == 0)
            {
                listPhuongTienViPham = null;
            }
            else
            {
                foreach (var phuongtien in listPhuongTienViPham)
                {
                    ListPhuongTienPartialModel listPhuongTienPartialModel = new ListPhuongTienPartialModel();

                    listPhuongTienPartialModel.SoLanViPham = phuongtien.SoLanViPham;
                    listPhuongTienPartialModel.TenViPham = phuongtien.TenViPham;
                    listPhuongTienPartialModel.ViPhamID = phuongtien.ViPhamID;
                    listPhuongTienPartialModel.XeID = phuongtien.XeID;
                    listPhuongTienPartialModel.BienSoXe = phuongtien.BienSoXe;

                    //Lấy thông tin chi tiết số lần từng hành vi xử lý
                    listPhuongTienPartialModel.listHanhViXuLyByXeModels = GetChiTietHanhViXuLyByXe(DonViVanTaiID, LoaiHinhVanTaiID, ViPhamID, phuongtien.XeID.Value);

                    //Lấy danh sách văn bản xử lý theo xe
                    listPhuongTienPartialModel.listVanBanXuLyViPhamModels = GetVanBanXuLyByXe(DonViVanTaiID, LoaiHinhVanTaiID, ViPhamID, phuongtien.XeID.Value);

                    listPhuongTienModelPartialModels.Add(listPhuongTienPartialModel);
                }
                return listPhuongTienModelPartialModels;
            }
            return listPhuongTienModelPartialModels;
        }

        //Get chi tiết Hành vi xử lý từng Hành vi
        public List<HanhViXuLyViPhamModel> GetChiTietHanhViXuLy(long DonViVanTaiID, long ViPhamID)
        {
            var urlCallChiTietHanhChi = apiUrl.urlAPI + "ThongTinViPham/Get_ChiTietHanhViXuLy?donvivantaiID=" + DonViVanTaiID + "&viphamID=" + ViPhamID;
            List<HanhViXuLyViPhamModel> listHanhViXuLyViPham = callAPI.CallAPIVChiTietHanhViXuLy(urlCallChiTietHanhChi);

            return listHanhViXuLyViPham;
        }

        //Get chi tiết Hành vi xử lý từng Hành vi
        public List<HanhViXuLyViPhamDetailModel> GetChiTietHanhViXuLyDetail(long DonViVanTaiID, long ViPhamID, long LoaiHinhXeID)
        {
            var urlCallChiTietHanhVi = apiUrl.urlAPI + "ThongTinViPham/Get_ChiTietHanhViXuLyDetail?donvivantaiID=" + DonViVanTaiID + "&viphamID=" + ViPhamID + "&loaihinhxeID=" + LoaiHinhXeID;
            List<HanhViXuLyViPhamDetailModel> listHanhViXuLyViPhamDetail = callAPI.CallAPIChiTietHanhViXuLyDetail(urlCallChiTietHanhVi);

            return listHanhViXuLyViPhamDetail;
        }

        #region Phần load các thông tin vi phạm chi tiết theo xe
        //================Get chi tiết Hành vi xử lý theo từng xe cụ thể
        public List<HanhViXuLyViPhamByXeModel> GetChiTietHanhViXuLyByXe(long DonViVanTaiID, long LoaiHinhXeID, long ViPhamID, long XeID)
        {
            var urlCallHanhViByXe = apiUrl.urlAPI + "ThongTinViPham/Get_HanhViXuLyViPhamByXe?donvivantaiID=" + DonViVanTaiID + "&loaihinhxeID=" + LoaiHinhXeID + "&viphamID=" + ViPhamID + "&xeID=" + XeID;
            List<HanhViXuLyViPhamByXeModel> listHanhViXuLyViPhamDetail = callAPI.CallAPIChiTietHanhViXuLyByXe(urlCallHanhViByXe);

            return listHanhViXuLyViPhamDetail;
        }

        //Get chi tiết các văn bản xử lý vi phạm theo từng xe
        public List<VanBanXuLyViPhamByXeModel> GetVanBanXuLyByXe(long DonViVanTaiID, long LoaiHinhXeID, long ViPhamID, long XeID)
        {
            var urlCallVanBanXuLyByXe = apiUrl.urlAPI + "ThongTinViPham/Get_VanBanXuLyViPhamByXe?donvivantaiID=" + DonViVanTaiID + "&loaihinhxeID=" + LoaiHinhXeID + "&viphamID=" + ViPhamID + "&xeID=" + XeID;
            List<VanBanXuLyViPhamByXeModel> listHanhViXuLyViPhamDetail = callAPI.CallAPIVanBanXuLyByXe(urlCallVanBanXuLyByXe);

            return listHanhViXuLyViPhamDetail;
        }
        #endregion
    }
}
