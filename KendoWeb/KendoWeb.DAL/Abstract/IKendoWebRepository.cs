using LightSpeed.Repository.Base.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KendoWeb.Model;
using Mindscape.LightSpeed;

namespace KendoWeb.DAL.Abstract
{
    public interface IKendoWebRepository : IDbRepository<KendoWebUnitOfWork>
    {
        IQueryable<SysUser> SysUsers { get; }
        IQueryable<Role> Roles { get; }
        IQueryable<RoleMenu> RoleMenus { get; }
        IQueryable<SysUserRole> SysUserRoles { get; }

        IQueryable<MenuGroup> MenuGroups { get; }
        IQueryable<Menu> Menus { get; }

        void Insert<T>(T entity) where T : Entity;
        void Update<T>(T entity) where T : Entity;
        void Remove<T>(T entity) where T : Entity;
    }
}
