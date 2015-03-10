using KendoWeb.DAL.Abstract;
using LightSpeed.Repository.Base.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KendoWeb.Model;
using Mindscape.LightSpeed;

namespace KendoWeb.DAL.Concrete
{
    public class KendoWebRepository : DbRepositoryBase<KendoWebUnitOfWork>, IKendoWebRepository
    {
        private KendoWebUnitOfWork UnitOfWork;
        public KendoWebRepository(UnitOfWorkScopeBase<KendoWebUnitOfWork> unitOfWorkScope)
            : base(unitOfWorkScope)
        {
            UnitOfWork = unitOfWorkScope.Current;
        }

        public KendoWebUnitOfWork GetUnitOfWork
        {
            get { return UnitOfWork; }
        }

        public IQueryable<SysUser> SysUsers
        {
            get { return UnitOfWork.SysUsers; }
        }

        public IQueryable<Role> Roles
        {
            get { return UnitOfWork.Roles; }
        }

        public IQueryable<RoleMenu> RoleMenus
        {
            get { return UnitOfWork.RoleMenus; }
        }

        public IQueryable<SysUserRole> SysUserRoles
        {
            get { return UnitOfWork.SysUserRoles; }
        }

        public IQueryable<MenuGroup> MenuGroups
        {
            get { return UnitOfWork.MenuGroups; }
        }

        public IQueryable<Menu> Menus
        {
            get { return UnitOfWork.Menus; }
        }

        public void Insert<T>(T entity) where T : Entity
        {
            UnitOfWork.Add(entity);
        }

        public void Update<T>(T entity) where T : Entity
        {
            UnitOfWork.Attach(entity);
        }

        public void Remove<T>(T entity) where T : Entity
        {
            UnitOfWork.Remove(entity);
        }
    }
}
