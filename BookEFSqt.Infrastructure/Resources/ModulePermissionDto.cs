using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Book.Core.EntityFramWork.Resources
{
   public class ModulePermissionDto
    {
        /// <summary>
        ///获取或设置是否禁用，逻辑上的删除，非物理删除
        /// </summary>
        [DisplayName("逻辑上的删除")]
        public bool? IsDeleted { get; set; }
        /// <summary>
        /// 菜单ID
        /// </summary>
        [DisplayName("菜单ID")]
        public int ModuleId { get; set; }
        /// <summary>
        /// 按钮ID
        /// </summary>
        [DisplayName("按钮ID")]
        public int PermissionId { get; set; }
        /// <summary>
        /// 创建ID
        /// </summary>
        [DisplayName("创建ID")]
        public int? CreateId { get; set; }
        /// <summary>
        /// 创建者
        /// </summary>
        [DisplayName("创建者")]
        public string CreateBy { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [DisplayName("创建时间")]
        public DateTime? CreateTime { get; set; }
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
        ///修改时间
        /// </summary>
        [DisplayName("修改时间")]
        public DateTime? ModifyTime { get; set; }
    }
}
