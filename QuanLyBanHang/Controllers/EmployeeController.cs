using ConnectDataBase;
using QuanLyBanHang.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyBanHang.Controllers
{
    public class EmployeeController : CommandBaseController
    {
        // GET: Employee
        public ActionResult EmployeeList(EmployeeListAction CommandAction,bool isPopup = false)
        {
            this.ViewBag.isPopup = isPopup;
            this.ViewBag.Result = CommandAction.Execute();
            return View();
        }
        public ActionResult EmployeeInput(EmployeeInputAction CommandAction)
        {
            this.ViewBag.Result = CommandAction.Execute();
            return View();
        }
        [HttpPost]
        public ActionResult EmployeeExecuteSave(EmployeeExecuteSaveAction CommandAction)
        {
            try
            {
                return JsonExpando(Success(CommandAction.Execute()));

            }
            catch (Exception ex)
            {

                return JsonExpando(Success(false,ex.Message));

            }
        }
        [HttpPost]
        public ActionResult EmployeeExecuteDeleteById(EmployeeExecuteDeleteByIdAction CommandAction)
        {
            try
            {
                return JsonExpando(Success(CommandAction.Execute(),"Xóa thành công!"));

            }
            catch (Exception ex)
            {

                return JsonExpando(Success(false, ex.Message));

            }
        }
    }
}