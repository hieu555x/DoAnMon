using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using DoAnMon.Models;

namespace DoAnMon.Controllers
{
    public class ShopController : Controller
    {
        dbBanHangOnlineEntities data = new dbBanHangOnlineEntities();
        // GET: Shop
        public ActionResult Index(int ? page)
        {
            int pageSize = 8;
            int pagenum = (page ?? 1);
            return View(data.sanPhams.OrderByDescending(a=>a.ngayDang).ToList().ToPagedList(pagenum,pageSize));
        }

        public ActionResult ChiTiet(string id)
        {
            return View(data.sanPhams.SingleOrDefault(a => a.maSP == id));
        }
    }
}