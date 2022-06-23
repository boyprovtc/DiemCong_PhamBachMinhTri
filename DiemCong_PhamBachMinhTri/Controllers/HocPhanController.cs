using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DiemCong_PhamBachMinhTri.Models;
namespace DiemCong_PhamBachMinhTri.Controllers
{
    public class HocPhanController : Controller
    {
        // GET: HocPhan
        MyDataClassesDataContext data = new MyDataClassesDataContext();
        public ActionResult ListHP()
        {
            var all_HocPhan = from hp in data.HocPhans select hp;
            return View(all_HocPhan);
        }
    }
}