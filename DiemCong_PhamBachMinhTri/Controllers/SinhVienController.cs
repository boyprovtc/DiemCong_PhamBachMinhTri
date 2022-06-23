using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DiemCong_PhamBachMinhTri.Models;
namespace DiemCong_PhamBachMinhTri.Controllers
{
    public class SinhVienController : Controller
    {
        // GET: SinhVien
        MyDataClassesDataContext data = new MyDataClassesDataContext();
        public ActionResult ListSV()
        {
            var all_sv = from sv in data.SinhViens select sv;
            return View(all_sv);
        }
        public ActionResult Detail(string id)
        {
            var D_sv = data.SinhViens.Where(m => m.MaSV == id).First();
            return View(D_sv);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(FormCollection collection, SinhVien sv)
        {
            var E_MaSinhVien = collection["MaSinhVien"];
            var E_HoTen = collection["HoTen"];
            var E_GioiTinh = collection["GioiTinh"];
            var E_NgaySinh = Convert.ToDateTime(collection["NgaySinh"]);
            var E_Hinh = collection["Hinh"];           
           
            var E_MaNganh = collection["MaNganh"]; 
            if ( string.IsNullOrEmpty(E_HoTen))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
              
                sv.HoTen = E_HoTen.ToString();
                sv.GioiTinh = E_GioiTinh.ToString();
                
                sv.NgaySinh = E_NgaySinh;
                sv.Hinh = E_Hinh.ToString();
                sv.MaNganh = E_MaNganh.ToString();
                data.SinhViens.InsertOnSubmit(sv);
                data.SubmitChanges();
                return RedirectToAction("ListSV");
            }
            return this.Create();
        }
        public ActionResult Edit(string id)
        {
            var E_sv = data.SinhViens.First(m => m.MaSV == id);
            return View(E_sv);
        }
        [HttpPost]
        public ActionResult Edit(string id, FormCollection collection)
        {
            var E_SinhVien = data.SinhViens.First(m => m.MaSV == id);
            var E_HoTen = collection["HoTen"];
            var E_Hinh = collection["Hinh"];
            var E_GioiTinh = collection["GioiTinh"];
            var E_NgaySinh = Convert.ToDateTime(collection["NgaySinh"]); 
           
           
            var E_MaNganh = collection["MaNganh"];
            E_SinhVien.MaSV = id;
            if ( string.IsNullOrEmpty(E_HoTen))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {

                E_SinhVien.HoTen = E_HoTen;
                E_SinhVien.GioiTinh = E_GioiTinh;
                E_SinhVien.Hinh = E_Hinh;
                E_SinhVien.NgaySinh = E_NgaySinh;
                E_SinhVien.MaNganh = E_MaNganh;
                UpdateModel(E_SinhVien);
                data.SubmitChanges();
                return RedirectToAction("ListSV");
            }
            return this.Edit(id);
        }

        //-----------------------------------------
        public ActionResult Delete(string id)
        {
            var D_SinhVien = data.SinhViens.First(m => m.MaSV == id); return View(D_SinhVien);
        }
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            var D_SinhVien = data.SinhViens.Where(m => m.MaSV == id).First();
            data.SinhViens.DeleteOnSubmit(D_SinhVien);
            data.SubmitChanges();
            return RedirectToAction("ListSV");
        }
        public string ProcessUpload(HttpPostedFileBase file)
        {
            if (file == null)
            {
                return "";
            }
            file.SaveAs(Server.MapPath("~/Content/images/" + file.FileName)); return "/Content/images/" + file.FileName;
        }
    }
}