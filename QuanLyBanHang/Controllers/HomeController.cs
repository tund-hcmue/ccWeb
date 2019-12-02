using QuanLyBanHang.Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyBanHang.Controllers
{
    public class HomeController : CommandBaseController
    {
        public ActionResult Index()
        {
            using(var cmd = new SaleSearchRepository())
            {
                this.ViewBag.Sale = cmd.Execute();
            }
            using (var cmd = new ProductSearchRepository())
            {
                this.ViewBag.Product = cmd.Execute();
            }
            using (var cmd = new CustomerSearchRepository())
            {
                this.ViewBag.Customer = cmd.Execute();
            }
            using (var cmd = new EmployeeSearchRepository())
            {
                this.ViewBag.Employee = cmd.Execute();
            }
            return View();
        }
        
    }
}