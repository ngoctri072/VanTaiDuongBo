using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using VanTaiDuongBo.Modules.VanTaiDuongBo.Models;
using VanTaiDuongBo.Modules.VanTaiDuongBo.Models.SoLieuXe;
using VanTaiDuongBo.Modules.VanTaiDuongBo.Models.ThongTinViPham;
using VanTaiDuongBo.Modules.VanTaiDuongBo.Models.Tuyen_BenXe;

namespace VanTaiDuongBo.Modules.VanTaiDuongBo.CallAPIProvider
{
    public class GetResponseFromAPI
    {
        List<LoaiHinhKinhDoanhModel> loaihinhKinhDoanh;
        List<DoanhNghiepVanTaiModel> doanhnghiepVanTai;
        List<LoaiHinhDoanhNghiepModel> loaihinhDoanhNghiep;
        List<DonViVanTaiModel> donviResult;
        List<QuanHuyenModel> quanhuyen;
        List<ThongTinGiayPhepVanTaiModel> thongtinGiayPhepVanTai;
        List<LoaiHinhKinhDoanhVanTaiPartialModel> loaihinhkinhdoanhvantai;
        List<LoaiHinhXe> loaihinhxe;
        List<DanhSachXeModel> danhsachxe;
        List<KhoiBenXeModel> khoibenxe;
        List<ListTuyen_ByBenXeModel> listTuyen_ByBenXeModels;
        List<ListXe_LoaiHinhXeModel> listXe_LoaiHinhXeModels;
        List<ThongTinChungModel> listThongTinChungModels;
        List<ViPhamByLoaiHinhModel> listViPhamByLoaiHinhModels;
        List<ListPhuongTienModel> listPhuongTienModels;
        List<HanhViXuLyViPhamModel> hanhViXuLyViPhamModels;
        List<HanhViXuLyViPhamDetailModel> hanhViXuLyViPhamDetailModels;
        List<HanhViXuLyViPhamByXeModel> hanhViXuLyViPhamByXeModels;
        List<VanBanXuLyViPhamByXeModel> vanVanXuLyViPhamByXeModels;

        public List<DonViVanTaiModel> CallAPIVanTai(string url)
        {
            HttpClient client = new HttpClient();
            try
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = new HttpResponseMessage();

                response = client.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    var responseData = response.Content.ReadAsAsync<List<DonViVanTaiModel>>();
                    responseData.Wait();

                    donviResult = responseData.Result;
                    return donviResult;
                }
            }
            catch (Exception ex)
            {
                return donviResult;
            }
            return donviResult;
        }

        public List<DonViVanTaiModel> CallAPIChiTiet(string url)
        {
            HttpClient client = new HttpClient();
            try
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = new HttpResponseMessage();

                response = client.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    var responseData = response.Content.ReadAsAsync<List<DonViVanTaiModel>>();
                    responseData.Wait();

                    donviResult = responseData.Result;
                    return donviResult;
                }
            }
            catch (Exception ex)
            {
                return donviResult;
            }
            return donviResult;
        }

        public List<LoaiHinhKinhDoanhModel> CallAPILoaiHinhKinhDoanh(string url)
        {
            HttpClient client = new HttpClient();
            try
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = new HttpResponseMessage();

                response = client.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    var responseData = response.Content.ReadAsAsync<List<LoaiHinhKinhDoanhModel>>();
                    responseData.Wait();

                    loaihinhKinhDoanh = responseData.Result;
                    return loaihinhKinhDoanh;
                }
            }
            catch (Exception ex)
            {
                return loaihinhKinhDoanh;
            }
            return loaihinhKinhDoanh;
        }

        public List<DoanhNghiepVanTaiModel> CallAPIDoanhNghiepVanTai(string url)
        {
            HttpClient client = new HttpClient();
            try
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = new HttpResponseMessage();

                response = client.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    var responseData = response.Content.ReadAsAsync<List<DoanhNghiepVanTaiModel>>();
                    responseData.Wait();

                    doanhnghiepVanTai = responseData.Result;
                    return doanhnghiepVanTai;
                }
            }
            catch (Exception ex)
            {
                return doanhnghiepVanTai;
            }
            return doanhnghiepVanTai;
        }

        public List<LoaiHinhDoanhNghiepModel> CallAPILoaiHinhDoanhNghiep(string url)
        {
            HttpClient client = new HttpClient();
            try
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = new HttpResponseMessage();

                response = client.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    var responseData = response.Content.ReadAsAsync<List<LoaiHinhDoanhNghiepModel>>();
                    responseData.Wait();

                    loaihinhDoanhNghiep = responseData.Result;
                    return loaihinhDoanhNghiep;
                }
            }
            catch (Exception ex)
            {
                return loaihinhDoanhNghiep;
            }
            return loaihinhDoanhNghiep;
        }

        public List<QuanHuyenModel> CallAPIQuanHuyen(string url)
        {
            HttpClient client = new HttpClient();
            try
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = new HttpResponseMessage();

                response = client.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    var responseData = response.Content.ReadAsAsync<List<QuanHuyenModel>>();
                    responseData.Wait();

                    quanhuyen = responseData.Result;
                    return quanhuyen;
                }
            }
            catch (Exception ex)
            {
                return quanhuyen;
            }
            return quanhuyen;
        }

        public List<ThongTinGiayPhepVanTaiModel> CallAPIThongTinGiayPhep(string url)
        {
            HttpClient client = new HttpClient();
            try
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = new HttpResponseMessage();

                response = client.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    var responseData = response.Content.ReadAsAsync<List<ThongTinGiayPhepVanTaiModel>>();
                    responseData.Wait();

                    thongtinGiayPhepVanTai = responseData.Result;
                    return thongtinGiayPhepVanTai;
                }
            }
            catch (Exception ex)
            {
                return thongtinGiayPhepVanTai;
            }
            return thongtinGiayPhepVanTai;
        }

        public List<LoaiHinhKinhDoanhVanTaiPartialModel> CallAPILoaiHinhVanTai(string url)
        {
            HttpClient client = new HttpClient();
            try
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = new HttpResponseMessage();

                response = client.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    var responseData = response.Content.ReadAsAsync<List<LoaiHinhKinhDoanhVanTaiPartialModel>>();
                    responseData.Wait();

                    loaihinhkinhdoanhvantai = responseData.Result;
                    return loaihinhkinhdoanhvantai;
                }
            }
            catch (Exception ex)
            {
                return loaihinhkinhdoanhvantai;
            }
            return loaihinhkinhdoanhvantai;
        }

        public List<LoaiHinhXe> CallAPILoaiHinhXe(string url)
        {
            HttpClient client = new HttpClient();
            try
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = new HttpResponseMessage();

                response = client.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    var responseData = response.Content.ReadAsAsync<List<LoaiHinhXe>>();
                    responseData.Wait();

                    loaihinhxe = responseData.Result;
                    return loaihinhxe;
                }
            }
            catch (Exception ex)
            {
                return loaihinhxe;
            }
            return loaihinhxe;
        }

        public List<DanhSachXeModel> CallAPIXeByDonViLoaiHinhXeID(string url)
        {
            HttpClient client = new HttpClient();
            try
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = new HttpResponseMessage();

                response = client.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    var responseData = response.Content.ReadAsAsync<List<DanhSachXeModel>>();
                    responseData.Wait();

                    danhsachxe = responseData.Result;
                    return danhsachxe;
                }
            }
            catch (Exception ex)
            {
                return danhsachxe;
            }
            return danhsachxe;
        }

        //Hàm get danh sách khối bến xe
        public List<KhoiBenXeModel> CallAPIKhoiBenXe(string url)
        {
            HttpClient client = new HttpClient();
            try
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = new HttpResponseMessage();

                response = client.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    var responseData = response.Content.ReadAsAsync<List<KhoiBenXeModel>>();
                    responseData.Wait();

                    khoibenxe = responseData.Result;
                    return khoibenxe;
                }
            }
            catch (Exception ex)
            {
                return khoibenxe;
            }
            return khoibenxe;
        }
        //Hàm Get danh sách 
        public List<ListTuyen_ByBenXeModel> CallAPITuyenByBenXe(string url)
        {
            HttpClient client = new HttpClient();
            try
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = new HttpResponseMessage();

                response = client.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    var responseData = response.Content.ReadAsAsync<List<ListTuyen_ByBenXeModel>>();
                    responseData.Wait();

                    listTuyen_ByBenXeModels = responseData.Result;
                    return listTuyen_ByBenXeModels;
                }
            }
            catch (Exception ex)
            {
                return listTuyen_ByBenXeModels;
            }
            return listTuyen_ByBenXeModels;
        }

        public List<ListXe_LoaiHinhXeModel> CallAPIListXe(string url)
        {
            HttpClient client = new HttpClient();
            try
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = new HttpResponseMessage();

                response = client.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    var responseData = response.Content.ReadAsAsync<List<ListXe_LoaiHinhXeModel>>();
                    responseData.Wait();

                    listXe_LoaiHinhXeModels = responseData.Result;
                    return listXe_LoaiHinhXeModels;
                }
            }
            catch (Exception ex)
            {
                return listXe_LoaiHinhXeModels;
            }
            return listXe_LoaiHinhXeModels;
        }

        //Hàm Get thông tin vi phạm theo đơn vi vận tải ID
        public List<ThongTinChungModel> CallAPIViPhamByDonViVanTai(string url)
        {
            HttpClient client = new HttpClient();
            try
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = new HttpResponseMessage();

                response = client.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    var responseData = response.Content.ReadAsAsync<List<ThongTinChungModel>>();
                    responseData.Wait();

                    listThongTinChungModels = responseData.Result;
                    return listThongTinChungModels;
                }
            }
            catch (Exception ex)
            {
                return listThongTinChungModels;
            }
            return listThongTinChungModels;
        }

        //Hàm Get chi tiết thông tin vi phạm theo Loại hình vận tải và Danh sách xe theo Loại hình
        public List<ViPhamByLoaiHinhModel> CallAPIViPhamByLoaiHinhVanTai(string url)
        {
            HttpClient client = new HttpClient();
            try
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = new HttpResponseMessage();

                response = client.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    var responseData = response.Content.ReadAsAsync<List<ViPhamByLoaiHinhModel>>();
                    responseData.Wait();

                    listViPhamByLoaiHinhModels = responseData.Result;
                    return listViPhamByLoaiHinhModels;
                }
            }
            catch (Exception ex)
            {
                return listViPhamByLoaiHinhModels;
            }
            return listViPhamByLoaiHinhModels;
        }

        //Get danh sách xe vi phạm theo Loại hình vận tải
        public List<ListPhuongTienModel> CallAPIViPhamByPhuongTien(string url)
        {
            HttpClient client = new HttpClient();
            try
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = new HttpResponseMessage();

                response = client.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    var responseData = response.Content.ReadAsAsync<List<ListPhuongTienModel>>();
                    responseData.Wait();

                    listPhuongTienModels = responseData.Result;
                    return listPhuongTienModels;
                }
            }
            catch (Exception ex)
            {
                return listPhuongTienModels;
            }
            return listPhuongTienModels;
        }

        //Get danh sách xe vi phạm theo Loại hình vận tải
        public List<HanhViXuLyViPhamModel> CallAPIVChiTietHanhViXuLy(string url)
        {
            HttpClient client = new HttpClient();
            try
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = new HttpResponseMessage();

                response = client.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    var responseData = response.Content.ReadAsAsync<List<HanhViXuLyViPhamModel>>();
                    responseData.Wait();

                    hanhViXuLyViPhamModels = responseData.Result;
                    return hanhViXuLyViPhamModels;
                }
            }
            catch (Exception ex)
            {
                return hanhViXuLyViPhamModels;
            }
            return hanhViXuLyViPhamModels;
        }

        public List<HanhViXuLyViPhamDetailModel> CallAPIChiTietHanhViXuLyDetail(string url)
        {
            HttpClient client = new HttpClient();
            try
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = new HttpResponseMessage();

                response = client.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    var responseData = response.Content.ReadAsAsync<List<HanhViXuLyViPhamDetailModel>>();
                    responseData.Wait();

                    hanhViXuLyViPhamDetailModels = responseData.Result;
                    return hanhViXuLyViPhamDetailModels;
                }
            }
            catch (Exception ex)
            {
                return hanhViXuLyViPhamDetailModels;
            }
            return hanhViXuLyViPhamDetailModels;
        }

        public List<HanhViXuLyViPhamByXeModel> CallAPIChiTietHanhViXuLyByXe(string url)
        {
            HttpClient client = new HttpClient();
            try
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = new HttpResponseMessage();

                response = client.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    var responseData = response.Content.ReadAsAsync<List<HanhViXuLyViPhamByXeModel>>();
                    responseData.Wait();

                    hanhViXuLyViPhamByXeModels = responseData.Result;
                    return hanhViXuLyViPhamByXeModels;
                }
            }
            catch (Exception ex)
            {
                return hanhViXuLyViPhamByXeModels;
            }
            return hanhViXuLyViPhamByXeModels;
        }

        public List<VanBanXuLyViPhamByXeModel> CallAPIVanBanXuLyByXe(string url)
        {
            HttpClient client = new HttpClient();
            try
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = new HttpResponseMessage();

                response = client.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    var responseData = response.Content.ReadAsAsync<List<VanBanXuLyViPhamByXeModel>>();
                    responseData.Wait();

                    vanVanXuLyViPhamByXeModels = responseData.Result;
                    return vanVanXuLyViPhamByXeModels;
                }
            }
            catch (Exception ex)
            {
                return vanVanXuLyViPhamByXeModels;
            }
            return vanVanXuLyViPhamByXeModels;
        }
    }
}