//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace KendoWeb2.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Role
    {
        public Role()
        {
            this.RoleMenu = new HashSet<RoleMenu>();
            this.SysUserRole = new HashSet<SysUserRole>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    
        public virtual ICollection<RoleMenu> RoleMenu { get; set; }
        public virtual ICollection<SysUserRole> SysUserRole { get; set; }
    }
}
