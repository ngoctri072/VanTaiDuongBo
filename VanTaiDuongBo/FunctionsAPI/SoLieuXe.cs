using System.Collections.Generic;
using VanTaiDuongBo.Modules.VanTaiDuongBo.CallAPIProvider;
using VanTaiDuongBo.Modules.VanTaiDuongBo.Models;
using VanTaiDuongBo.Modules.VanTaiDuongBo.Models.SoLieuXe;

namespace VanTaiDuongBo.Modules.VanTaiDuongBo.FunctionsAPI
{
    public class SoLieuXe
    {
        GetResponseFromAPI callAPI = new GetResponseFromAPI();
        APIUrl apiUrl = new APIUrl();
        //Hàm Get thông tin Partial Số liệu xe
        public List<SoLieuXePartialModel> ThongTinSoLieuXe(long DonViVanTaiID)
        {
            List<SoLieuXePartialModel> listSoLieuXePartialModels = new List<SoLieuXePartialModel>();


            //Lấy Danh sách Loại hình xe theo Đơn vị vận tải ID
            var urlCallLoaiHinhXe = apiUrl.urlAPI + "LoaiHinhXe/Get_ByDonViVanTaiID?donvivantaiID=" + DonViVanTaiID;
            List<LoaiHinhXe> resultLoaiHinhXe = callAPI.CallAPILoaiHinhXe(urlCallLoaiHinhXe);

            if (resultLoaiHinhXe.Count == 0)
            {
                listSoLieuXePartialModels = null;
            }
            else
            {
                foreach (var item in resultLoaiHinhXe)
                {
                    SoLieuXePartialModel solieuxePartialModel = new SoLieuXePartialModel();

                    solieuxePartialModel.LoaiHinhXeID = item.LoaiHinhXeID.Value;
                    solieuxePartialModel.SoXe = item.SoLuongXe.Value;
                    solieuxePartialModel.LoaiHinhXe = item.TenLoaiHinhXe;
                    solieuxePartialModel.TongSoXe = item.TongSoXe.Value;

                    solieuxePartialModel.ListXe = GetListXe_ByLoaiHinh(DonViVanTaiID, item.LoaiHinhXeID.Value);

                    listSoLieuXePartialModels.Add(solieuxePartialModel);
                }
                return listSoLieuXePartialModels;
            }
            return listSoLieuXePartialModels;
        }

        //Get Danh sách Xe theo Loại hình xe
        public List<ListXe_LoaiHinhXeModel> GetListXe_ByLoaiHinh(long DonViVanTaiID, long loaihinhxeID)
        {
            var urlCallListXe = apiUrl.urlAPI + "LoaiHinhXe/Get_DanhSachXe_ByDonViLoaiHinhID?donvivantaiID=" + DonViVanTaiID + "&loaihinhxeID=" + loaihinhxeID;
            List<ListXe_LoaiHinhXeModel> listTuyen_ByBenXeModels = callAPI.CallAPIListXe(urlCallListXe);

            return listTuyen_ByBenXeModels;
        }
    }
}