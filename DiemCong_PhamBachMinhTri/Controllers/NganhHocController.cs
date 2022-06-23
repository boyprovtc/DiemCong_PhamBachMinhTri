using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DiemCong_PhamBachMinhTri.Models;
namespace DiemCong_PhamBachMinhTri.Controllers
{
    public class NganhHocController : Controller
    {
        // GET: NganhHoc

        MyDataClassesDataContext data = new MyDataClassesDataContext();

        public ActionResult Index()
        {
            var all_NganhHoc = from nh in data.NganhHocs select nh;
            return View(all_NganhHoc);
        }
    }
}