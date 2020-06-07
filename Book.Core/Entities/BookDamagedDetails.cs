using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Book.Core.Entities
{
    /// <summary>
    /// 图书报损单明细
    /// </summary>
    public class BookDamagedDetails
    {
        /// <summary>
        /// 图书报损单编号
        /// </summary>
        [Key]
        public int DNumber { get; set; }
        /// <summary>
        /// 图书编号
        /// </summary>
        public string Bid { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public int Counts { get; set; }
        /// <summary>
        /// 报损原因
        /// </summary>
        public string Result { get; set; }
    }
}
