using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Book.Core.Entities
{
    /// <summary>
    /// 借阅表
    /// </summary>
    public class Borrow
    {
        /// <summary>
        /// 借书证编号
        /// </summary>
        [Key]
        [DisplayName("借书证编号")]
        public int BNumber { get; set; }
        /// <summary>
        /// 图书编号
        /// </summary>
        [DisplayName("图书编号")]
        public string Bid { get; set; }
        /// <summary>
        /// 借书日期
        /// </summary>
        [DisplayName("借书日期")]
        public DateTime BorrowingDate { get; set; }
        /// <summary>
        /// 还书日期
        /// </summary>
        [DisplayName("还书日期")]
        public DateTime ReturnDate { get; set; }
        /// <summary>
        /// 罚款金额
        /// </summary>
        [DisplayName("罚款金额")]
        public double Moneys { get; set; }
        /// <summary>
        /// 是否续借
        /// </summary>
        [DisplayName("是否续借")]
        public int IsRenew { get; set; }
    }
}
