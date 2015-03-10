using KendoWeb.BL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KendoWeb.DAL.Abstract;
using KendoWeb.Model;
using KendoWeb.Model.DTO;
using KendoWeb.BL.Helper;

namespace KendoWeb.BL.Concrete
{
    public class SystemService : ISystemService
    {
        public IKendoWebRepository repository { get; set; }

        public SystemService(IKendoWebRepository repo)
        {
            repository = repo;
        }

        #region SysUser
        public int Login(string Name, string Password)
        {
            var SysUser = repository.SysUsers.Where(w => w.Name == Name && w.Password == Utils.PasswordMD5(Password)).FirstOrDefault();
            if (SysUser == null)
            {
                return -1;
            }
            return SysUser.Id;
        }

        public List<SysUserDTO> Get_SysUser()
        {
            List<SysUserDTO> dtoList = new List<SysUserDTO>();
            var entList = repository.SysUsers.OrderByDescending(o => o.Id);
            foreach (var ent in entList)
            {
                dtoList.Add(ent.AsDto());
            }
            return dtoList;
        }

        public bool Update_SysUser(SysUserDTO dto)
        {
            var ent = repository.SysUsers.Where(w => w.Id == dto.Id).FirstOrDefault();
            if (ent != null)
            {
                ent.Name = dto.Name;
                ent.Description = dto.Description;
                ent.Password = Utils.PasswordMD5(dto.Password);
            }
            repository.SaveChanges();

            var SysUserRoles = repository.SysUserRoles.Where(w => w.SysUserId == dto.Id);
            foreach (var SysUserRole in SysUserRoles)
            {
                repository.Remove(SysUserRole);
            }
            repository.SaveChanges();

            foreach (var Role in dto.RoleList)
            {
                SysUserRole entSysUserRole = new SysUserRole();
                entSysUserRole.SysUserId = dto.Id;
                entSysUserRole.RoleId = Role.Id;
                repository.Insert(entSysUserRole);
            }
            repository.SaveChanges();

            return true;
        }

        public bool Create_SysUser(SysUserDTO dto)
        {
            SysUser ent = new SysUser();
            ent.Name = dto.Name;
            ent.Description = dto.Description;
            ent.Password = Utils.PasswordMD5(dto.Password);
            repository.Insert(ent);
            repository.SaveChanges();

            foreach (var Role in dto.RoleList)
            {
                SysUserRole entSysUserRole = new SysUserRole();
                entSysUserRole.SysUserId = ent.Id;
                entSysUserRole.RoleId = Role.Id;
                repository.Insert(entSysUserRole);
            }
            repository.SaveChanges();

            return true;
        }
        #endregion

        #region Role
        public List<RoleDTO> Get_Role()
        {
            List<RoleDTO> dtoList = new List<RoleDTO>();
            var entList = repository.Roles.OrderByDescending(o => o.Id);
            foreach (var ent in entList)
            {
                dtoList.Add(ent.AsDto());
            }
            return dtoList;
        }

        public bool Update_Role(RoleDTO dto)
        {
            var ent = repository.Roles.Where(w => w.Id == dto.Id).FirstOrDefault();
            if (ent != null)
            {
                ent.Name = dto.Name;
                ent.Description = dto.Description;
            }
            repository.SaveChanges();

            var RoleMenus = repository.RoleMenus.Where(w => w.RoleId == dto.Id);
            foreach (var RoleMenu in RoleMenus)
            {
                repository.Remove(RoleMenu);
            }
            repository.SaveChanges();

            foreach (var Menu in dto.MenuList)
            {
                RoleMenu entRoleMenu = new RoleMenu();
                entRoleMenu.RoleId = dto.Id;
                entRoleMenu.MenuId = Menu.Id;
                repository.Insert(entRoleMenu);
            }
            repository.SaveChanges();

            return true;
        }

        public bool Create_Role(RoleDTO dto)
        {
            Role ent = new Role();
            ent.Name = dto.Name;
            ent.Description = dto.Description;
            repository.Insert(ent);
            repository.SaveChanges();

            foreach (var Menu in dto.MenuList)
            {
                RoleMenu entRoleMenu = new RoleMenu();
                entRoleMenu.RoleId = ent.Id;
                entRoleMenu.MenuId = Menu.Id;
                repository.Insert(entRoleMenu);
            }
            repository.SaveChanges();

            return true;
        }
        #endregion

        #region MenuGroup
        public List<MenuGroupDTO> Get_MenuGroup()
        {
            List<MenuGroupDTO> dtoList = new List<MenuGroupDTO>();
            var entList = repository.MenuGroups.OrderByDescending(o => o.Id);
            foreach (var ent in entList)
            {
                dtoList.Add(ent.AsDto());
            }
            return dtoList;
        }

        public bool Update_MenuGroup(MenuGroupDTO dto)
        {
            var ent = repository.MenuGroups.Where(w => w.Id == dto.Id).FirstOrDefault();
            if (ent != null)
            {
                ent.Name = dto.Name;
            }
            repository.SaveChanges();
            return true;
        }

        public bool Create_MenuGroup(MenuGroupDTO dto)
        {
            MenuGroup ent = new MenuGroup();
            ent.Name = dto.Name;
            repository.Insert(ent);
            repository.SaveChanges();
            return true;
        }
        #endregion

        #region Menu
        public List<MenuDTO> Get_MenuBySysUserId(int SysUserId)
        {
            List<MenuDTO> dtoList = new List<MenuDTO>();
            var SysUser = repository.SysUsers.Where(w => w.Id == SysUserId).FirstOrDefault();
            var Roles = SysUser.Roles;
            foreach (var Role in Roles)
            {
                foreach (var ent in Role.Menus)
                {
                    dtoList.Add(ent.AsDto());
                }
            }
            return dtoList.OrderBy(o => o.SortOrder).ToList();
        }

        public List<MenuDTO> Get_Menu()
        {
            List<MenuDTO> dtoList = new List<MenuDTO>();
            var entList = repository.Menus.OrderByDescending(o => o.Id);
            foreach (var ent in entList)
            {
                dtoList.Add(ent.AsDto());
            }
            return dtoList;
        }

        public bool Update_Menu(MenuDTO dto)
        {
            var ent = repository.Menus.Where(w => w.Id == dto.Id).FirstOrDefault();
            if (ent != null)
            {
                ent.Name = dto.Name;
                ent.Controller = dto.Controller;
                ent.Action = dto.Action;
                ent.MenuGroupId = dto.MenuGroupId;
                ent.SortOrder = dto.SortOrder;
            }
            repository.SaveChanges();
            return true;
        }

        public bool Create_Menu(MenuDTO dto)
        {
            Menu ent = new Menu();
            ent.Name = dto.Name;
            ent.Controller = dto.Controller;
            ent.Action = dto.Action;
            ent.MenuGroupId = dto.MenuGroupId;
            ent.SortOrder = dto.SortOrder;
            repository.Insert(ent);
            repository.SaveChanges();
            return true;
        }
        #endregion
    }
}
