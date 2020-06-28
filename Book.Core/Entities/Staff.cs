using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Book.Core.Entities
{
    /// <summary>
    ///  职工类
    /// </summary>
   public class Staff
    {
        [Key]
        [DisplayName("编号")]
        public int Sid { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        [DisplayName("职工名称")]
        public string SName { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        [DisplayName("性别")]
        public string Sex { get; set; }
        /// <summary>
        /// 生日
        /// </summary>
        [DisplayName("生日")]
        public DateTime Birthday { get; set; }
        /// <summary>
        /// 文化程度
        /// </summary>
        [DisplayName("文化程度")]
        public string Education { get; set; }
    }
}
