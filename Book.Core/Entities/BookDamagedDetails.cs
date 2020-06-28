using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [DisplayName("图书报损单编号")]
        public int DNumber { get; set; }
        /// <summary>
        /// 图书编号
        /// </summary>
        [Required]
        [DisplayName("图书编号")]
        public string Bid { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        [Required]
        [DisplayName("数量")]
        public int Counts { get; set; }
        /// <summary>
        /// 报损原因
        /// </summary>
        [DisplayName("报损原因")]
        public string Result { get; set; }
    }
}
