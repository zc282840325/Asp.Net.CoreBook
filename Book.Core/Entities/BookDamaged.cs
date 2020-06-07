using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Book.Core.Entities
{
    /// <summary>
    /// 图书报损单表
    /// </summary>
    public class BookDamaged
    {
        /// <summary>
        /// 报损单编号
        /// </summary>
        [Key]
        public int DNumber { get; set; }
        /// <summary>
        /// 报损日期
        /// </summary>
        public DateTime DDateTime { get; set; }
        /// <summary>
        /// 经手人编号
        /// </summary>
        public int Sid { get; set; }
    }
}
