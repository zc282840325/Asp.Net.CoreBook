using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [DisplayName("图书入库单编号")]
        public int Did { get; set; }
        /// <summary>
        /// 图书编号
        /// </summary>
        [DisplayName("图书编号")]
        public string SNumber { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        [DisplayName("数量")]
        public int Counts { get; set; }
    }
}
