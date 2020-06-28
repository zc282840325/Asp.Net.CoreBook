using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Book.Core.EntityFramWork.Resources
{
   public class ModuleDto
    {
        /// <summary>
        ///获取或设置是否禁用，逻辑上的删除，非物理删除
        /// </summary>
        [DisplayName("逻辑上的删除")]
        public bool? IsDeleted { get; set; }
        /// <summary>
        /// 父ID
        /// </summary>
        [DisplayName("父ID")]
        public int? ParentId { get; set; }
        /// <summary>
        /// 名称
        [DisplayName("名称")]
        public string Name { get; set; }
        /// <summary>
        /// 菜单链接地址
        /// </summary>
        [DisplayName("菜单链接地址")]
        public string LinkUrl { get; set; }
        /// <summary>
        /// 区域名称
        /// </summary>
        [DisplayName("区域名称")]
        public string Area { get; set; }
        /// <summary>
        /// 控制器名称
        /// </summary>
        [DisplayName("控制器名称")]
        public string Controller { get; set; }
        /// <summary>
        /// Action名称
        /// </summary>
        [DisplayName("Action名称")]
        public string Action { get; set; }
        /// <summary>
        /// 图标
        /// </summary>
        [DisplayName("图标")]
        public string Icon { get; set; }
        /// <summary>
        /// 菜单编号
        /// </summary>
        [DisplayName("菜单编号")]
        public string Code { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        [DisplayName("排序")]
        public int OrderSort { get; set; }
        /// <summary>
        /// /描述
        /// </summary>
        [DisplayName("描述")]
        public string Description { get; set; }
        /// <summary>
        /// 是否是右侧菜单
        /// </summary>
        [DisplayName("是否是右侧菜单")]
        public bool IsMenu { get; set; }
        /// <summary>
        /// 是否激活
        /// </summary>
        [DisplayName("是否激活")]
        public bool Enabled { get; set; }
        /// <summary>
        /// 创建ID
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
        public DateTime CreateTime { get; set; } = DateTime.Now;
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
        [DisplayName("修改时间")]
        public DateTime? ModifyTime { get; set; } = DateTime.Now;
    }
}
