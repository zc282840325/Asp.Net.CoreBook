using System;
using System.Collections.Generic;
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
        public int Sid { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string SName { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string Sex { get; set; }
        /// <summary>
        /// 生日
        /// </summary>
        public DateTime Birthday { get; set; }
        /// <summary>
        /// 文化程度
        /// </summary>
        public string Education { get; set; }
    }
}
