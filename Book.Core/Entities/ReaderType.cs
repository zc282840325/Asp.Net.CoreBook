using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Book.Core.Entities
{
    /// <summary>
    /// 读者类型
    /// </summary>
    public class ReaderType
    {
        /// <summary>
        /// 读者类型编号
        /// </summary>
        [Key]
        public string Rid { set; get; }
        /// <summary>
        /// 读者类型名
        /// </summary>
        public string ReaderTypeName { set; get; }
        /// <summary>
        /// 可借阅册数
        /// </summary>
        public int BorrowNumbers { get; set; }
        /// <summary>
        /// 借期天数
        /// </summary>
        public int BorrowDays { get; set; }
        /// <summary>
        /// 可续借天数
        /// </summary>
        public int RenewDays { get; set; }
    }
}
