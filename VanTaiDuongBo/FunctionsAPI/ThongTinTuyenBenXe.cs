using System.Collections.Generic;
using VanTaiDuongBo.Modules.VanTaiDuongBo.CallAPIProvider;
using VanTaiDuongBo.Modules.VanTaiDuongBo.Models;
using VanTaiDuongBo.Modules.VanTaiDuongBo.Models.Tuyen_BenXe;

namespace VanTaiDuongBo.Modules.VanTaiDuongBo.FunctionsAPI
{
    public class ThongTinTuyenBenXe
    {
        GetResponseFromAPI callAPI = new GetResponseFromAPI();
        APIUrl apiUrl = new APIUrl();
        //Hàm Get List Tuyến xe theo Khối bến xe
        public List<TuyenBenXePartialModel> ThongTinChiTietTuyen(long DonViVanTaiID)
        {
            List<TuyenBenXePartialModel> listTuyenBenXePartialModel = new List<TuyenBenXePartialModel>();

            var urlCallListBenXe = apiUrl.urlAPI + "KhoiBenXe/Get_ByDonViVanTaiID?donvivantaiID=" + DonViVanTaiID;
            List<KhoiBenXeModel> resultKhoiBenXe = callAPI.CallAPIKhoiBenXe(urlCallListBenXe);

            if (resultKhoiBenXe.Count == 0)
            {
                listTuyenBenXePartialModel = null;
            }
            else
            {
                foreach (var item in resultKhoiBenXe)
                {
                    TuyenBenXePartialModel tuyenBenXePartialModel = new TuyenBenXePartialModel();
                    tuyenBenXePartialModel.TenBenXe = item.TenBenXe;
                    tuyenBenXePartialModel.SoXeBenXe = item.TongSoXe.Value;

                    //Phần này mình call API lấy danh sách Tuyến theo Bến xe ID
                    tuyenBenXePartialModel.ListTuyen_ByBenXe = GetTuyen_ByBenXeID(DonViVanTaiID, item.BenXeID.Value);

                    listTuyenBenXePartialModel.Add(tuyenBenXePartialModel);
                }
                return listTuyenBenXePartialModel;
            }
            return listTuyenBenXePartialModel;
        }

        //Get Danh sách Tuyến theo Khối bến xe
        public List<ListTuyen_ByBenXeModel> GetTuyen_ByBenXeID(long DonViVanTaiID, long BenXeID)
        {
            var urlCallTuyenByBenXe = apiUrl.urlAPI + "KhoiBenXe/Get_ListTuyen_ByBenXeID?donvivantaiID=" + DonViVanTaiID + "&benxeID=" + BenXeID;
            List<ListTuyen_ByBenXeModel> listTuyen_ByBenXeModels = callAPI.CallAPITuyenByBenXe(urlCallTuyenByBenXe);

            return listTuyen_ByBenXeModels;
        }
    }
}