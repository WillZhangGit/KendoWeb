using System;

using Mindscape.LightSpeed;
using Mindscape.LightSpeed.Validation;
using Mindscape.LightSpeed.Linq;

namespace KendoWeb.Model
{
  [Serializable]
  [System.CodeDom.Compiler.GeneratedCode("LightSpeedModelGenerator", "1.0.0.0")]
  [System.ComponentModel.DataObject]
  [Table(IdentityMethod=IdentityMethod.IdentityColumn)]
  public partial class SysUser : Entity<int>
  {
    #region Fields
  
    [ValidateLength(0, 50)]
    private string _name;
    [ValidateLength(0, 200)]
    private string _description;
    [ValidateLength(0, 50)]
    private string _password;

    #endregion
    
    #region Field attribute and view names
    
    /// <summary>Identifies the Name entity attribute.</summary>
    public const string NameField = "Name";
    /// <summary>Identifies the Description entity attribute.</summary>
    public const string DescriptionField = "Description";
    /// <summary>Identifies the Password entity attribute.</summary>
    public const string PasswordField = "Password";


    #endregion
    
    #region Relationships

    [ReverseAssociation("SysUser")]
    private readonly EntityCollection<SysUserRole> _sysUserRoles = new EntityCollection<SysUserRole>();

    private ThroughAssociation<SysUserRole, Role> _roles;

    #endregion
    
    #region Properties

    [System.Diagnostics.DebuggerNonUserCode]
    public EntityCollection<SysUserRole> SysUserRoles
    {
      get { return Get(_sysUserRoles); }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public ThroughAssociation<SysUserRole, Role> Roles
    {
      get
      {
        if (_roles == null)
        {
          _roles = new ThroughAssociation<SysUserRole, Role>(_sysUserRoles);
        }
        return Get(_roles);
      }
    }
    

    [System.Diagnostics.DebuggerNonUserCode]
    public string Name
    {
      get { return Get(ref _name, "Name"); }
      set { Set(ref _name, value, "Name"); }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public string Description
    {
      get { return Get(ref _description, "Description"); }
      set { Set(ref _description, value, "Description"); }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public string Password
    {
      get { return Get(ref _password, "Password"); }
      set { Set(ref _password, value, "Password"); }
    }

    #endregion
  }


  [Serializable]
  [System.CodeDom.Compiler.GeneratedCode("LightSpeedModelGenerator", "1.0.0.0")]
  [System.ComponentModel.DataObject]
  [Table(IdentityMethod=IdentityMethod.IdentityColumn)]
  public partial class Role : Entity<int>
  {
    #region Fields
  
    [ValidateLength(0, 20)]
    private string _name;
    [ValidateLength(0, 200)]
    private string _description;

    #endregion
    
    #region Field attribute and view names
    
    /// <summary>Identifies the Name entity attribute.</summary>
    public const string NameField = "Name";
    /// <summary>Identifies the Description entity attribute.</summary>
    public const string DescriptionField = "Description";


    #endregion
    
    #region Relationships

    [ReverseAssociation("Role")]
    private readonly EntityCollection<SysUserRole> _sysUserRoles = new EntityCollection<SysUserRole>();
    [ReverseAssociation("Role")]
    private readonly EntityCollection<RoleMenu> _roleMenus = new EntityCollection<RoleMenu>();

    private ThroughAssociation<SysUserRole, SysUser> _sysUsers;
    private ThroughAssociation<RoleMenu, Menu> _menus;

    #endregion
    
    #region Properties

    [System.Diagnostics.DebuggerNonUserCode]
    public EntityCollection<SysUserRole> SysUserRoles
    {
      get { return Get(_sysUserRoles); }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public EntityCollection<RoleMenu> RoleMenus
    {
      get { return Get(_roleMenus); }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public ThroughAssociation<SysUserRole, SysUser> SysUsers
    {
      get
      {
        if (_sysUsers == null)
        {
          _sysUsers = new ThroughAssociation<SysUserRole, SysUser>(_sysUserRoles);
        }
        return Get(_sysUsers);
      }
    }
    
    [System.Diagnostics.DebuggerNonUserCode]
    public ThroughAssociation<RoleMenu, Menu> Menus
    {
      get
      {
        if (_menus == null)
        {
          _menus = new ThroughAssociation<RoleMenu, Menu>(_roleMenus);
        }
        return Get(_menus);
      }
    }
    

    [System.Diagnostics.DebuggerNonUserCode]
    public string Name
    {
      get { return Get(ref _name, "Name"); }
      set { Set(ref _name, value, "Name"); }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public string Description
    {
      get { return Get(ref _description, "Description"); }
      set { Set(ref _description, value, "Description"); }
    }

    #endregion
  }


  [Serializable]
  [System.CodeDom.Compiler.GeneratedCode("LightSpeedModelGenerator", "1.0.0.0")]
  [System.ComponentModel.DataObject]
  [Table(IdentityMethod=IdentityMethod.IdentityColumn)]
  public partial class MenuGroup : Entity<int>
  {
    #region Fields
  
    [ValidateLength(0, 20)]
    private string _name;

    #endregion
    
    #region Field attribute and view names
    
    /// <summary>Identifies the Name entity attribute.</summary>
    public const string NameField = "Name";


    #endregion
    
    #region Relationships

    [ReverseAssociation("MenuGroup")]
    private readonly EntityCollection<Menu> _menus = new EntityCollection<Menu>();


    #endregion
    
    #region Properties

    [System.Diagnostics.DebuggerNonUserCode]
    public EntityCollection<Menu> Menus
    {
      get { return Get(_menus); }
    }


    [System.Diagnostics.DebuggerNonUserCode]
    public string Name
    {
      get { return Get(ref _name, "Name"); }
      set { Set(ref _name, value, "Name"); }
    }

    #endregion
  }


  [Serializable]
  [System.CodeDom.Compiler.GeneratedCode("LightSpeedModelGenerator", "1.0.0.0")]
  [System.ComponentModel.DataObject]
  [Table(IdentityMethod=IdentityMethod.IdentityColumn)]
  public partial class Menu : Entity<int>
  {
    #region Fields
  
    private string _name;
    [ValidateLength(0, 20)]
    private string _controller;
    [ValidateLength(0, 20)]
    private string _action;
    private int _sortOrder;
    private int _menuGroupId;

    #endregion
    
    #region Field attribute and view names
    
    /// <summary>Identifies the Name entity attribute.</summary>
    public const string NameField = "Name";
    /// <summary>Identifies the Controller entity attribute.</summary>
    public const string ControllerField = "Controller";
    /// <summary>Identifies the Action entity attribute.</summary>
    public const string ActionField = "Action";
    /// <summary>Identifies the SortOrder entity attribute.</summary>
    public const string SortOrderField = "SortOrder";
    /// <summary>Identifies the MenuGroupId entity attribute.</summary>
    public const string MenuGroupIdField = "MenuGroupId";


    #endregion
    
    #region Relationships

    [ReverseAssociation("Menus")]
    private readonly EntityHolder<MenuGroup> _menuGroup = new EntityHolder<MenuGroup>();
    [ReverseAssociation("Menu")]
    private readonly EntityCollection<RoleMenu> _roleMenus = new EntityCollection<RoleMenu>();

    private ThroughAssociation<RoleMenu, Role> _roles;

    #endregion
    
    #region Properties

    [System.Diagnostics.DebuggerNonUserCode]
    public MenuGroup MenuGroup
    {
      get { return Get(_menuGroup); }
      set { Set(_menuGroup, value); }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public EntityCollection<RoleMenu> RoleMenus
    {
      get { return Get(_roleMenus); }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public ThroughAssociation<RoleMenu, Role> Roles
    {
      get
      {
        if (_roles == null)
        {
          _roles = new ThroughAssociation<RoleMenu, Role>(_roleMenus);
        }
        return Get(_roles);
      }
    }
    

    [System.Diagnostics.DebuggerNonUserCode]
    public string Name
    {
      get { return Get(ref _name, "Name"); }
      set { Set(ref _name, value, "Name"); }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public string Controller
    {
      get { return Get(ref _controller, "Controller"); }
      set { Set(ref _controller, value, "Controller"); }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public string Action
    {
      get { return Get(ref _action, "Action"); }
      set { Set(ref _action, value, "Action"); }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public int SortOrder
    {
      get { return Get(ref _sortOrder, "SortOrder"); }
      set { Set(ref _sortOrder, value, "SortOrder"); }
    }

    /// <summary>Gets or sets the ID for the <see cref="MenuGroup" /> property.</summary>
    [System.Diagnostics.DebuggerNonUserCode]
    public int MenuGroupId
    {
      get { return Get(ref _menuGroupId, "MenuGroupId"); }
      set { Set(ref _menuGroupId, value, "MenuGroupId"); }
    }

    #endregion
  }


  [Serializable]
  [System.CodeDom.Compiler.GeneratedCode("LightSpeedModelGenerator", "1.0.0.0")]
  [System.ComponentModel.DataObject]
  public partial class SysUserRole : Entity<int>
  {
    #region Fields
  
    private int _sysUserId;
    private int _roleId;

    #endregion
    
    #region Field attribute and view names
    
    /// <summary>Identifies the SysUserId entity attribute.</summary>
    public const string SysUserIdField = "SysUserId";
    /// <summary>Identifies the RoleId entity attribute.</summary>
    public const string RoleIdField = "RoleId";


    #endregion
    
    #region Relationships

    [ReverseAssociation("SysUserRoles")]
    private readonly EntityHolder<SysUser> _sysUser = new EntityHolder<SysUser>();
    [ReverseAssociation("SysUserRoles")]
    private readonly EntityHolder<Role> _role = new EntityHolder<Role>();


    #endregion
    
    #region Properties

    [System.Diagnostics.DebuggerNonUserCode]
    public SysUser SysUser
    {
      get { return Get(_sysUser); }
      set { Set(_sysUser, value); }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public Role Role
    {
      get { return Get(_role); }
      set { Set(_role, value); }
    }


    [System.Diagnostics.DebuggerNonUserCode]
    public int SysUserId
    {
      get { return Get(ref _sysUserId, "SysUserId"); }
      set { Set(ref _sysUserId, value, "SysUserId"); }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public int RoleId
    {
      get { return Get(ref _roleId, "RoleId"); }
      set { Set(ref _roleId, value, "RoleId"); }
    }

    #endregion
  }


  [Serializable]
  [System.CodeDom.Compiler.GeneratedCode("LightSpeedModelGenerator", "1.0.0.0")]
  [System.ComponentModel.DataObject]
  public partial class RoleMenu : Entity<int>
  {
    #region Fields
  
    private int _roleId;
    private int _menuId;

    #endregion
    
    #region Field attribute and view names
    
    /// <summary>Identifies the RoleId entity attribute.</summary>
    public const string RoleIdField = "RoleId";
    /// <summary>Identifies the MenuId entity attribute.</summary>
    public const string MenuIdField = "MenuId";


    #endregion
    
    #region Relationships

    [ReverseAssociation("RoleMenus")]
    private readonly EntityHolder<Role> _role = new EntityHolder<Role>();
    [ReverseAssociation("RoleMenus")]
    private readonly EntityHolder<Menu> _menu = new EntityHolder<Menu>();


    #endregion
    
    #region Properties

    [System.Diagnostics.DebuggerNonUserCode]
    public Role Role
    {
      get { return Get(_role); }
      set { Set(_role, value); }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public Menu Menu
    {
      get { return Get(_menu); }
      set { Set(_menu, value); }
    }


    [System.Diagnostics.DebuggerNonUserCode]
    public int RoleId
    {
      get { return Get(ref _roleId, "RoleId"); }
      set { Set(ref _roleId, value, "RoleId"); }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public int MenuId
    {
      get { return Get(ref _menuId, "MenuId"); }
      set { Set(ref _menuId, value, "MenuId"); }
    }

    #endregion
  }




  /// <summary>
  /// Provides a strong-typed unit of work for working with the KendoWeb model.
  /// </summary>
  [System.CodeDom.Compiler.GeneratedCode("LightSpeedModelGenerator", "1.0.0.0")]
  public partial class KendoWebUnitOfWork : Mindscape.LightSpeed.UnitOfWork
  {

    public System.Linq.IQueryable<SysUser> SysUsers
    {
      get { return this.Query<SysUser>(); }
    }
    
    public System.Linq.IQueryable<Role> Roles
    {
      get { return this.Query<Role>(); }
    }
    
    public System.Linq.IQueryable<MenuGroup> MenuGroups
    {
      get { return this.Query<MenuGroup>(); }
    }
    
    public System.Linq.IQueryable<Menu> Menus
    {
      get { return this.Query<Menu>(); }
    }
    
    public System.Linq.IQueryable<SysUserRole> SysUserRoles
    {
      get { return this.Query<SysUserRole>(); }
    }
    
    public System.Linq.IQueryable<RoleMenu> RoleMenus
    {
      get { return this.Query<RoleMenu>(); }
    }
    
  }

}
