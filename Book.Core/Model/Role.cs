using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Book.Core.Model
{
    /// <summary>
    /// 角色表
    /// </summary>
    [Table("Role")]
    public class Role : RootEntity
    {
        public Role()
        {
            OrderSort = 1;
            CreateTime = DateTime.Now;
            ModifyTime = DateTime.Now;
            IsDeleted = false;
        }
        public Role(string name)
        {
            Name = name;
            Description = "";
            OrderSort = 1;
            Enabled = true;
            CreateTime = DateTime.Now;
            ModifyTime = DateTime.Now;

        }

        /// <summary>
        /// 角色名
        /// </summary>
        [DisplayName("角色名")]
        public string Name { get; set; }
        /// <summary>
        /// 角色租书的特权
        /// </summary>
        [DisplayName("特征")]
        public int FeatureId { get; set; }
        /// <summary>
        ///描述
        /// </summary>
        [DisplayName("描述")]
        public string Description { get; set; }
        /// <summary>
        ///排序
        /// </summary>
        [DisplayName("排序")]
        public int OrderSort { get; set; }
        /// <summary>
        /// 是否激活
        /// </summary>
        [DisplayName("是否激活")]
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
        [DisplayName("逻辑上的删除")]
        public bool? IsDeleted { get; set; }
    }
}
