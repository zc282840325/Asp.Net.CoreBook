using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Book.Core.Entities
{
    /// <summary>
    /// 图书入库单明细表
    /// </summary>
    public class BookStorageDetails
    {
        /// <summary>
        /// 图书入库单编号
        /// </summary>
        [Key]
        public int Did { get; set; }
        /// <summary>
        /// 图书编号
        /// </summary>
        public string SNumber { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public int Counts { get; set; }
    }
}
