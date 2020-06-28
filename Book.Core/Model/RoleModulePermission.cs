using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Book.Core.Model
{
    /// <summary>
    /// 按钮跟权限关联表
    /// </summary>
    [Table("RoleModulePermission")]
    public class RoleModulePermission : RootEntity
    {
        public RoleModulePermission()
        {
         

        }
        /// <summary>
        /// 创建ID
        /// </summary>
        [DisplayName("创建ID")]
        public int? CreateId { get; set; }


        /// <summary>
        /// 角色ID
        /// </summary>
        [DisplayName("角色ID")]
        public int RoleId { get; set; }
        /// <summary>
        /// 菜单ID
        /// </summary>
        [DisplayName("菜单ID")]
        public int ModuleId { get; set; }
        /// <summary>
        /// api ID
        /// </summary>
        [DisplayName("api ID")]
        public int? PermissionId { get; set; }

        /// <summary>
        /// 创建者
        /// </summary>
        [DisplayName("创建者")]
        public string CreateBy { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [DisplayName("创建时间")]
        public DateTime? CreateTime { get; set; } = DateTime.Now;
        /// <summary>
        /// 修改ID
        /// </summary>
        [DisplayName("修改ID")]
        public int? ModifyId { get; set; }
        /// <summary>
        /// 修改者
        /// </summary>
        [DisplayName("修改者")]
        public string ModifyBy { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        [DisplayName("修改时间")]
        public DateTime? ModifyTime { get; set; } = DateTime.Now;

        [DisplayName("逻辑上的删除")]
        /// <summary>
        ///获取或设置是否禁用，逻辑上的删除，非物理删除
        /// </summary>
        public bool? IsDeleted { get; set; }

        // 下边三个实体参数，只是做传参作用，所以忽略下
        public Role Role { get; set; }
        public Module Module { get; set; }
        public Permission Permission { get; set; }
    }
}
