using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KendoWeb.Model.DTO
{
    public class MenuDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public int SortOrder { get; set; }

        public int MenuGroupId { get; set; }
        public string MenuGroupName { get; set; }

        public MenuGroupDTO MenuGroupDTO { get; set; }
    }

    public class MenuGroupDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class RoleDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<MenuDTO> MenuList { get; set; }

        public RoleDTO()
        {
            MenuList = new List<MenuDTO>();
        }
    }

    public class SysUserDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Password { get; set; }

        public List<RoleDTO> RoleList { get; set; }

        public SysUserDTO()
        {
            RoleList = new List<RoleDTO>();
        }
    }

    public static class DTODo
    {
        public static MenuDTO AsDto(this Menu entity)
        {
            var res = new MenuDTO();
            res.Id = entity.Id;
            res.Name = entity.Name;
            res.Controller = entity.Controller;
            res.Action = entity.Action;
            res.SortOrder = entity.SortOrder;
            res.MenuGroupId = entity.MenuGroupId;
            res.MenuGroupName = entity.MenuGroup.Name;
            return res;
        }

        public static MenuGroupDTO AsDto(this MenuGroup entity)
        {
            var res = new MenuGroupDTO();
            res.Id = entity.Id;
            res.Name = entity.Name;
            return res;
        }

        public static RoleDTO AsDto(this Role entity)
        {
            var res = new RoleDTO();
            res.Id = entity.Id;
            res.Name = entity.Name;
            res.Description = entity.Description;
            foreach (var menu in entity.Menus)
            {
                res.MenuList.Add(menu.AsDto());
            }
            return res;
        }

        public static SysUserDTO AsDto(this SysUser entity)
        {
            var res = new SysUserDTO();
            res.Id = entity.Id;
            res.Name = entity.Name;
            res.Description = entity.Description;
            res.Password = entity.Password;
            foreach (var menu in entity.Roles)
            {
                res.RoleList.Add(menu.AsDto());
            }
            return res;
        }
    }
}
