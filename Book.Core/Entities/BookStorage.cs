using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Book.Core.Entities
{
    /// <summary>
    ///  图书入库单表
    /// </summary>
    public class BookStorage
    {
        /// <summary>
        /// 入库编号
        /// </summary>
        [Key]
        [DisplayName("入库编号")]
        public int SNumber { get; set; }
        /// <summary>
        /// 入库日期
        /// </summary>
        [DisplayName("入库日期")]
        public DateTime SDate { get; set; }
        /// <summary>
        /// 经手职工编号
        /// </summary>
        [DisplayName("经手职工编号")]

        public int Sid { get; set; }
        /// <summary>
        /// 是否入库
        /// </summary>
        [DisplayName("是否入库")]
        public int IsWarehousing { get; set; }
    }
}
