using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KendoWeb.Model;
using KendoWeb.Model.DTO;

namespace KendoWeb.BL.Abstract
{
    public interface ISystemService
    {
        List<SysUserDTO> Get_SysUser();
        bool Update_SysUser(SysUserDTO dto);
        bool Create_SysUser(SysUserDTO dto);

        List<RoleDTO> Get_Role();
        bool Update_Role(RoleDTO dto);
        bool Create_Role(RoleDTO dto);

        List<MenuGroupDTO> Get_MenuGroup();
        bool Update_MenuGroup(MenuGroupDTO dto);
        bool Create_MenuGroup(MenuGroupDTO dto);

        List<MenuDTO> Get_Menu();
        bool Update_Menu(MenuDTO dto);
        bool Create_Menu(MenuDTO dto);
        List<MenuDTO> Get_MenuBySysUserId(int SysUserId);
        int Login(string Name, string Password);
    }
}
