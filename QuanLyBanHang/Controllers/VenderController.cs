using QuanLyBanHang.Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyBanHang.Controllers
{
    public class VenderController : CommandBaseController
    {
        // GET: Vender
        public ActionResult VenderList(VenderListAction CommandAction)
        {
            this.ViewBag.Result = CommandAction.Execute();
            return View();
        }
        public ActionResult VenderInput(VenderInputAction CommandAction)
        {
            this.ViewBag.Result = new List<dynamic>();
            if(CommandAction.CustomerId != null)
            {
                this.ViewBag.Result = CommandAction.Execute();
                this.ViewBag.EditFlag = "M";
            }
            return View();
        }
    }
}