using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using KendoWeb.BL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KendoWeb.Model.DTO;

namespace KendoWeb.Controllers
{
    public class SystemController : Controller
    {
        public ISystemService SystemService { get; set; }

        // GET: System

        #region Menu
        public ActionResult Menu()
        {
            return View();
        }

        public ActionResult Menu_Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(SystemService.Get_Menu().ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Menu_Create([DataSourceRequest] DataSourceRequest request, MenuDTO dto)
        {
            var res = new List<MenuDTO>();
            if (dto != null && ModelState.IsValid)
            {
                SystemService.Create_Menu(dto);
                res.Add(dto);
            }
            return Json(res.ToDataSourceResult(request, ModelState));
        }

        public ActionResult Menu_Update([DataSourceRequest] DataSourceRequest request, MenuDTO dto)
        {
            var res = new List<MenuDTO>();
            if (dto != null && ModelState.IsValid)
            {
                SystemService.Update_Menu(dto);
                res.Add(dto);
            }
            return Json(res.ToDataSourceResult(request, ModelState));
        }

        public ActionResult MyMenu()
        {
            var SysUserId = Session["SysUserId"];
            if (SysUserId == null)
            {
                return Redirect("/System/Login");
            }
            ViewBag.ListMenu = SystemService.Get_MenuBySysUserId(int.Parse(SysUserId.ToString()));
            return View();
        }

        public ActionResult MyMenu2()
        {
            //var SysUserId = Session["SysUserId"];
            int SysUserId = 1;
            if (SysUserId == null)
            {
                return Redirect("/System/Login");
            }
            ViewBag.ListMenu = SystemService.Get_MenuBySysUserId(int.Parse(SysUserId.ToString()));
            return View();
        }

        public ActionResult Menu_List()
        {
            return Json(SystemService.Get_Menu(), JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region MenuGroup
        public ActionResult MenuGroup()
        {
            return View();
        }

        public ActionResult MenuGroup_Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(SystemService.Get_MenuGroup().ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public ActionResult MenuGroup_Create([DataSourceRequest] DataSourceRequest request, MenuGroupDTO dto)
        {
            var res = new List<MenuGroupDTO>();
            if (dto != null && ModelState.IsValid)
            {
                SystemService.Create_MenuGroup(dto);
                res.Add(dto);
            }
            return Json(res.ToDataSourceResult(request, ModelState));
        }

        public ActionResult MenuGroup_Update([DataSourceRequest] DataSourceRequest request, MenuGroupDTO dto)
        {
            var res = new List<MenuGroupDTO>();
            if (dto != null && ModelState.IsValid)
            {
                SystemService.Update_MenuGroup(dto);
                res.Add(dto);
            }
            return Json(res.ToDataSourceResult(request, ModelState));
        }

        public ActionResult MenuGroup_List()
        {
            return Json(SystemService.Get_MenuGroup(), JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Role
        public ActionResult Role()
        {
            return View();
        }

        public ActionResult Role_Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(SystemService.Get_Role().ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Role_Create([DataSourceRequest] DataSourceRequest request, RoleDTO dto)
        {
            var res = new List<RoleDTO>();
            if (dto != null && ModelState.IsValid)
            {
                SystemService.Create_Role(dto);
                res.Add(dto);
            }
            return Json(res.ToDataSourceResult(request, ModelState));
        }

        public ActionResult Role_Update([DataSourceRequest] DataSourceRequest request, RoleDTO dto)
        {
            var res = new List<RoleDTO>();
            if (dto != null && ModelState.IsValid)
            {
                SystemService.Update_Role(dto);
                res.Add(dto);
            }
            return Json(res.ToDataSourceResult(request, ModelState));
        }

        public ActionResult Role_List()
        {
            return Json(SystemService.Get_Role(), JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region SysUser
        public ActionResult Login()
        {
            var SysUserId = Session["SysUserId"];
            if (SysUserId != null)
            {
                return Redirect("/Home/Index");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Login(string Name, string Password)
        {
            var SysUserId = SystemService.Login(Name, Password);
            if (SysUserId <= 0)
            {
                ViewBag.Error = "登录失败，请检查用户名/密码！";
                return View();
            }
            Session["SysUserId"] = SysUserId;
            return Redirect("/Home/Index");
        }

        public ActionResult SysUser()
        {
            return View();
        }

        public ActionResult SysUser_Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(SystemService.Get_SysUser().ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public ActionResult SysUser_Create([DataSourceRequest] DataSourceRequest request, SysUserDTO dto)
        {
            var res = new List<SysUserDTO>();
            if (dto != null && ModelState.IsValid)
            {
                SystemService.Create_SysUser(dto);
                res.Add(dto);
            }
            return Json(res.ToDataSourceResult(request, ModelState));
        }

        public ActionResult SysUser_Update([DataSourceRequest] DataSourceRequest request, SysUserDTO dto)
        {
            var res = new List<SysUserDTO>();
            if (dto != null && ModelState.IsValid)
            {
                SystemService.Update_SysUser(dto);
                res.Add(dto);
            }
            return Json(res.ToDataSourceResult(request, ModelState));
        }
        #endregion
    }
}