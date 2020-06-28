using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Book.Core.Model
{
    /// <summary>
    /// 路由菜单表
    /// </summary>
    [Table("Permission")]
    public class Permission : RootEntity
    {
        public Permission()
        {
            //this.ModulePermission = new List<ModulePermission>();
            //this.RoleModulePermission = new List<RoleModulePermission>();
        }
        [DisplayName("菜单执行Action名")]
        /// <summary>
        /// 菜单执行Action名
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 菜单显示名（如用户页、编辑(按钮)、删除(按钮)）
        /// </summary>
        [DisplayName("菜单显示名")]
        public string Name { get; set; }
        /// <summary>
        /// 是否是按钮
        /// </summary>
        [DisplayName("是否是按钮")]
        public bool IsButton { get; set; } = false;
        /// <summary>
        /// 是否是隐藏菜单
        /// </summary>
        [DisplayName("是否是隐藏菜单")]
        public bool? IsHide { get; set; } = false;
        /// <summary>
        /// 是否keepAlive
        /// </summary>
        [DisplayName("是否keepAlive")]

        public bool? IskeepAlive { get; set; } = false;
        /// <summary>
        /// 按钮事件
        /// </summary>
        [DisplayName("按钮事件")]
        public string Func { get; set; }
        /// <summary>
        /// 上一级菜单（0表示上一级无菜单）
        /// </summary>
        [DisplayName("上一级菜单")]

        public int Pid { get; set; }
        /// <summary>
        /// 接口api
        /// </summary>
        [DisplayName("接口api")]
        public int Mid { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        [DisplayName("排序")]
        public int OrderSort { get; set; }
        /// <summary>
        /// 菜单图标
        /// </summary>
        [DisplayName("菜单图标")]

        public string Icon { get; set; }
        /// <summary>
        /// 菜单描述    
        /// </summary>
        [DisplayName("菜单描述")]
        public string Description { get; set; }
        /// <summary>
        /// 激活状态
        /// </summary>
        [DisplayName("激活状态")]
        public bool Enabled { get; set; }
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

        /// <summary>
        ///获取或设置是否禁用，逻辑上的删除，非物理删除
        /// </summary>
        [DisplayName("逻辑删除")]
        public bool? IsDeleted { get; set; }
    }
}
